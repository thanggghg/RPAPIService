using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries.AffiliateCampaign
{
    public class GetCampaignsHappeningForPublisherQuery : IRequest<List<CampaignsHappeningForPublisherModel>>
    {
        public long AffiliateStoreId { get; set; }
    }
}
