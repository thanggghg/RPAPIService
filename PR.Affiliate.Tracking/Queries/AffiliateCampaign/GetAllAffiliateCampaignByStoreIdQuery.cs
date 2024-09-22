using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Pagination;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries.AffiliateCampaign
{
    public class GetAllAffiliateCampaignByStoreIdQuery : SearchAndPagingRequest, IRequest<PagingItems<AffiliateCampaignViewModel>>
    {
        public long AffiliateStoreId { get; set; }
        public GetAllAffiliateCampaignByStoreIdQuery()
        {

        }
    }
}
