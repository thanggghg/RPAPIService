using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries.AffiliateCampaign
{
    public class GetCampaignsToCalculateCommissionQuery : IRequest<List<CampaignToCalculateCommissionModel>>
    {
        public long AffiliateStoreId { get; set; }
        public DateTime FromDate { get; set; }  // need to transmit at utc time
        public DateTime ToDate { get; set; }    // need to transmit at utc time
    }
}
