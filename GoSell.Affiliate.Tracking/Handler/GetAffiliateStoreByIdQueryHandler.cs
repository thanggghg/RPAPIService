using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class GetAffiliateStoreByIdQueryHandler(ILogger<GetAffiliateStoreByIdQueryHandler> logger,
                                       IAffiliateStoreServices affiliateStoreServices) : IRequestHandler<GetAffiliateStoreByIdQuery, AffiliateStoreValidateViewModel>
    {
        private readonly ILogger<GetAffiliateStoreByIdQueryHandler> _logger = logger;
        private readonly IAffiliateStoreServices _affiliateStoreServices = affiliateStoreServices;

        public async Task<AffiliateStoreValidateViewModel> Handle(GetAffiliateStoreByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateStore = await _affiliateStoreServices.GetAffiliateStoreById(request.Id, cancellationToken);
                return affiliateStore != null ? new AffiliateStoreValidateViewModel { Id = affiliateStore.Id, GoSellStoreId = affiliateStore.GoSellStoreId } : null;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateStoreByIdQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
