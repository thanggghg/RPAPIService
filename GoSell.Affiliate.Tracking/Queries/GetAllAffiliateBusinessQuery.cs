using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class GetAllAffiliateBusinessQuery : IRequest<List<AffiliateKeyValueViewModel>>
    {
        public GetAllAffiliateBusinessQuery() { }
    }
}
