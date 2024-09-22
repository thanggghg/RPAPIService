using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class GetSpecificAffiliateStoreByDomainQuery : IRequest<AffiliateStoreByDomainViewModel>
    {
        public string Domain { get; }
        public GetSpecificAffiliateStoreByDomainQuery(string domain)
        {
            Domain = domain;
        }
    }
}
