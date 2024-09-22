using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class GetAllAffiliateStoreQuery : IRequest<List<AffiliateStoreViewModel>>
    {

        public GetAllAffiliateStoreQuery()
        {
        }
    }
}
