using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class GetAffiliateStoreByIdQuery(long id = default) : IRequest<AffiliateStoreValidateViewModel>
    {
        public long Id { get; } = id;
    }
}
