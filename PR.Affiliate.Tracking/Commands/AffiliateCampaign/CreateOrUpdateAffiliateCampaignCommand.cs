using GoSell.Affiliate.Tracking.Models.Requests;
using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands.AffiliateCampaign
{
    public class CreateOrUpdateAffiliateCampaignCommand : AffiliateCampaignRequest, IRequest<BaseResponseCode>
    {
        public long StoreId { get; set; }
        public string UserLogin { get; set; }

        public CreateOrUpdateAffiliateCampaignCommand() { }
    }
}
