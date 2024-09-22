using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class GetAllAffiliateColorDefaultQuery : IRequest<List<AffiliateKeyValueViewModel>>
    {
        public bool IsBusinessColor { get; set; }
        public GetAllAffiliateColorDefaultQuery(bool isBusinessColor)
        {
            IsBusinessColor = isBusinessColor;
        }
    }
}
