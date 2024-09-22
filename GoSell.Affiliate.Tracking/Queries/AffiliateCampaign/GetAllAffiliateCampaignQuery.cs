using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Pagination;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries.AffiliateCampaign
{
    public class GetAllAffiliateCampaignRequest : SearchAndPagingRequest, IRequest<PagingItems<AffiliateCampaignViewModel>>
    {
        public long AffiliateStoreId { get; set; }
        public string AffiliateStoreFilterStatus { get; set; }
        public int? Status { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public GetAllAffiliateCampaignRequest() { }
    }

    public class GetAllAffiliateCampaignQuery : GetAllAffiliateCampaignRequest
    {
        public long StoreId { get; set; }
        public GetAllAffiliateCampaignQuery() { }
    }
}
