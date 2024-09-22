using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Database;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Services;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Library.Helpers.Api;
using MediatR;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class CreateAffiliateMappingCommandHandler : IRequestHandler<CreateAffiliateMappingCommand, bool>
    {
        private readonly ILogger<CreateAffiliateStoreCommandHandler> _logger;
        private readonly IBaseApi _baseApi;
        private readonly IMapper _mapper;
        private readonly IAffiliateMappingServices _affiliateMappingServices;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        private readonly AffiliateContext _affiliateContext;
        public CreateAffiliateMappingCommandHandler(
                ILogger<CreateAffiliateStoreCommandHandler> logger,
                IBaseApi baseApi,
                IMapper mapper,
                IAffiliateMappingServices affiliateMappingServicesiate,
                IAffiliateStoreServices affiliateStoreServices,
                AffiliateContext affiliateContext
        )
        {
            _logger = logger;
            _baseApi = baseApi;
            _mapper = mapper;
            _affiliateMappingServices = affiliateMappingServicesiate;
            _affiliateStoreServices = affiliateStoreServices;
            _affiliateContext = affiliateContext;
        }

        public async Task<bool> Handle(CreateAffiliateMappingCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _affiliateContext.BeginTransactionAsync())
            {
                try
                {
                    var externalStoreIds = _affiliateStoreServices.GetAllAffiliateStoreByGsId(_baseApi.User.StoreId).Result.Where(x => !x.IsDeleted).ToList();
                    if (externalStoreIds.FindIndex(x => x.Id == request.AffiliateStoreId) < 0)
                    {
                        throw new Exception("Store is not exist");
                    }
                    var affiliateMappings = _mapper.Map<List<AffiliateMapping>>(request.ListAffiliateMapping);


                    affiliateMappings.ForEach(x =>
                    {
                        x.UpdateCreatedBy(_baseApi.User.Sub);
                        x.LastModifiedBy = x.CreatedBy;
                        x.LastModifiedDate = x.CreatedDate;
                        x.AffiliateStoreId = request.AffiliateStoreId;
                        x.IsDeleted = false;
                    });

                    await _affiliateMappingServices.RemoveAllMapingByAffiliateStoreId(request.AffiliateStoreId, cancellationToken);
                    var result = await _affiliateMappingServices.CreateListMapping(affiliateMappings, cancellationToken);
                    if (result)
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                    }
                    Log.Logger.Information($"DONE {nameof(CreateAffiliateMappingCommandHandler)}");

                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Log.Logger.Error(ex, $"FAIL {nameof(CreateAffiliateMappingCommandHandler)} : {ex.Message}");
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
