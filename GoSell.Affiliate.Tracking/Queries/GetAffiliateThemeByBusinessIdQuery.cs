using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class GetAffiliateThemeByBusinessIdQuery : IRequest<AffiliateThemeViewModel>
    {
        public long BusinessId { get; }
        public long ExternalStoreId { get; }
        public GetAffiliateThemeByBusinessIdQuery(long businessId, long externalStoreId)
        {
            BusinessId = businessId;
            ExternalStoreId = externalStoreId;
        }
    }
}
