using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class GetBaseSpecificAffiliateStoreByIdQuery : IRequest<AffiliateStoreViewModel>
    {
        public long Id { get; }
        public GetBaseSpecificAffiliateStoreByIdQuery(long id = default)
        {
            Id = id;
        }
    }
}
