using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Database;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Library.Helpers.Api;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class CreateAffiliateStoreCommandHandler : IRequestHandler<CreateAffiliateStoreCommand, long>
    {
        private readonly ILogger<CreateAffiliateStoreCommandHandler> _logger;
        private readonly IBaseApi _baseApi;
        private readonly IMapper _mapper;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        private readonly AffiliateContext _affiliateContext;
        public CreateAffiliateStoreCommandHandler(
                ILogger<CreateAffiliateStoreCommandHandler> logger,
                IBaseApi baseApi,
                IMapper mapper,
                IAffiliateStoreServices affiliateStoreServices,
                AffiliateContext affiliateContext
        )
        {
            _logger = logger;
            _baseApi = baseApi;
            _mapper = mapper;
            _affiliateStoreServices = affiliateStoreServices;
            _affiliateContext = affiliateContext;
        }

        public async Task<long> Handle(CreateAffiliateStoreCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _affiliateContext.BeginTransactionAsync())
            {
                try
                {

                    var stores = await _affiliateStoreServices.GetAllAffiliateStoreByGsId(request.GoSellStoreId);
                    if (stores.Count() >= 5)
                    {
                        throw new Exception("OUT_OFLIMIT_PUBLISHER_PAGE");
                    }
                    var affiliateStore = _mapper.Map<AffiliateStore>(request);
                    affiliateStore.UpdateCreatedBy(_baseApi.User.Sub);
                    affiliateStore.LastModifiedBy = affiliateStore.CreatedBy;
                    affiliateStore.LastModifiedDate = affiliateStore.CreatedDate;
                    affiliateStore.AffiliateStoreCurrencyId = request.CurrencyId;

                    var (result, store) = await _affiliateStoreServices.CreateStoreAsync(affiliateStore, cancellationToken);
                    var themeIsCreated = await _affiliateStoreServices.CreateThemeByStoreAsync(request, store, cancellationToken);

                    if (themeIsCreated)
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                        Log.Logger.Error($"FAIL {nameof(CreateAffiliateStoreCommandHandler)}");
                        throw new Exception($"FAIL CreateThemeByStoreAsync");
                    }
                    Log.Logger.Information($"DONE {nameof(CreateAffiliateStoreCommandHandler)}");

                    return store.Id;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Log.Logger.Error(ex, $"FAIL {nameof(CreateAffiliateStoreCommandHandler)} : {ex.Message}");
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
