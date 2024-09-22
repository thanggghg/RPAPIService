using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class GetAllAffiliateThemeByStoreIdQuery : IRequest<List<AffiliateThemeViewModel>>
    {
        public long StoreId { get; }
        public GetAllAffiliateThemeByStoreIdQuery(long storeId)
        {
            StoreId = storeId;
        }
    }
}
