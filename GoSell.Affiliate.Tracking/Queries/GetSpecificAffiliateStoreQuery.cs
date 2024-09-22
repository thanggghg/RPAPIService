using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class GetSpecificAffiliateStoreByIdQuery : IRequest<AffiliateStoreViewModel>
    {
        public long Id { get; }
        public GetSpecificAffiliateStoreByIdQuery(long id = default)
        {
            Id = id;
        }
    }

    public class GetSpecificAffiliateStoreByGoSellStoreIdQuery : IRequest<AffiliateStoreViewModel>
    {
        public long GoSellStoreId { get; }
        public GetSpecificAffiliateStoreByGoSellStoreIdQuery(long goSellStoreId = default)
        {
            GoSellStoreId = goSellStoreId;
        }
    }
}
