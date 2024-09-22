using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class GetAllAffiliateStoreCurrencyQuery : IRequest<List<AffiliateStoreCurrencyViewModel>>
    {

        public GetAllAffiliateStoreCurrencyQuery()
        {
        }
    }
}
