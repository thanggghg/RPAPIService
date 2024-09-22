using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class GetAllAffiliateStoreByGoSellIdQueryHandler(ILogger<GetAllAffiliateStoreByGoSellIdQuery> logger,
                                       IAffiliateStoreServices affiliateStoreServices) : IRequestHandler<GetAllAffiliateStoreByGoSellIdQuery, List<AffiliateStore>>
    {
        private readonly ILogger<GetAllAffiliateStoreByGoSellIdQuery> _logger = logger;
        private readonly IAffiliateStoreServices _affiliateStoreServices = affiliateStoreServices;

        public async Task<List<AffiliateStore>> Handle(GetAllAffiliateStoreByGoSellIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateStores = await _affiliateStoreServices.GetAllAffiliateStoreByGoSellId(request.isDeleted, request.GoSellStoreId, cancellationToken);
                return affiliateStores;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateStoreByGoSellIdQuery)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
