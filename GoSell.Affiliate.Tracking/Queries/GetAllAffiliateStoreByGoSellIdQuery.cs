using GoSell.Affiliate.Tracking.Database.Entities;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class GetAllAffiliateStoreByGoSellIdQuery(bool? isDeleted = null) : IRequest<List<AffiliateStore>>
    {
        public bool? isDeleted { get; } = isDeleted;

        //Only use when call from BE
        public long? GoSellStoreId { get; set; }
    }
}
