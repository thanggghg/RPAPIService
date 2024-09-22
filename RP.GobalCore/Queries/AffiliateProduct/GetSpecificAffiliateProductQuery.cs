using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries.AffiliateProduct
{
    public class GetSpecificAffiliateProductQuery : IRequest<AffiliateProductViewModel>
    {
        public long Id { get; }
        public GetSpecificAffiliateProductQuery(long id)
        {
            Id = id;
        }
    }
}
