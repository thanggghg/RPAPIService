using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries.AffiliateCampaign
{
    public class GetCampaignsHappeningForPublisherIncludeProductQuery : IRequest<List<CampaignsHappeningForPublisherIncludeProductModel>>
    {
        public long AffiliateStoreId { get; set; }
        public long? CampaignId { get; set; }
        public string Keyword { get; set; }
    }
}
