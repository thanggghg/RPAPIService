using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class GetAllAffiliateStoreByGsIdQuery : IRequest<List<AffiliateStoreViewModel>>
    {

        public long GoSellStoreId { get; }
        public GetAllAffiliateStoreByGsIdQuery(long goSellStoreId = default)
        {
            GoSellStoreId = goSellStoreId;
        }
    }
}
