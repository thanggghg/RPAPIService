using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Database;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Services;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Library.Helpers.Api;
using MediatR;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class DeleteAffiliateMappingCommandHandler : IRequestHandler<DeleteAffiliateMappingCommand, bool>
    {
        private readonly ILogger<CreateAffiliateStoreCommandHandler> _logger;
        private readonly IBaseApi _baseApi;
        private readonly IMapper _mapper;
        private readonly IAffiliateMappingServices _affiliateMappingServices;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        private readonly AffiliateContext _affiliateContext;
        public DeleteAffiliateMappingCommandHandler(
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

        public async Task<bool> Handle(DeleteAffiliateMappingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var externalStoreIds = _affiliateStoreServices.GetAllAffiliateStoreByGsId(_baseApi.User.StoreId).Result.Where(x => !x.IsDeleted).ToList();
                if (externalStoreIds.FindIndex(x => x.Id == request.AffiliateStoreId) < 0)
                {
                    throw new Exception("Store is not exist");
                }

                var result = await _affiliateMappingServices.RemoveAllMapingByAffiliateStoreId(request.AffiliateStoreId, cancellationToken);

                Log.Logger.Information($"DONE {nameof(CreateAffiliateMappingCommandHandler)}");

                return result;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateAffiliateMappingCommandHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
