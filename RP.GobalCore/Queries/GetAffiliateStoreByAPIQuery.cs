using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class GetAffiliateStoreByAPIQuery : IRequest<AffiliateStoreSourceVNViewModel>
    {
        public string ApiKey { get; set; }
    }
}
