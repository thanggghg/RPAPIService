using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries.AffiliateProduct
{
    public class GetBaseSpecificAffiliateProductQuery : IRequest<AffiliateProductViewModel>
    {
        public long Id { get; }
        public GetBaseSpecificAffiliateProductQuery(long id)
        {
            Id = id;
        }
    }
}
