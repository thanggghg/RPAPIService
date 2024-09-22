using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class GetAffiliateThemePublishedByStoreIdQuery : IRequest<AffiliateThemeViewModel>
    {
        public long StoreId { get; }
        public GetAffiliateThemePublishedByStoreIdQuery(long storeId)
        {
            StoreId = storeId;
        }
    }
}
