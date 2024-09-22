using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries.AffiliateProduct
{
    public class GetAffiliateProductLinkTrackingQuery : IRequest<GenericResponse<string>>
    {
        public string OriginLinks { get; set; }
        public string RefProductId { get; set; }
        public string UserLogin { get; set; }
        public long UserId { get; set; }
        public bool IsPublisher { get; set; }
        public GetAffiliateProductLinkTrackingQuery()
        {

        }
    }
}
