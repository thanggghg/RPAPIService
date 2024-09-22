using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Pagination;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries.AffiliateProduct
{
    public class GetAffiliateProductViewPublisherQuery : SearchAndPagingRequest, IRequest<PagingItems<AffiliateProductViewModel>>
    {
        public long? AffiliateStoreId { get; set; }
        public long? CampaignId { get; set; }
        public string Status { get; set; }
        public string LinkRefId { get; set; }
        public long? CategoryId {  get; set; }
        public GetAffiliateProductViewPublisherQuery() { }
    }
}
