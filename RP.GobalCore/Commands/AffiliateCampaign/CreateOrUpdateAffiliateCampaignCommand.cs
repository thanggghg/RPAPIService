using RP.Affiliate.Tracking.Models.Requests;
using RP.Library.Helpers;
using MediatR;

namespace RP.Affiliate.Tracking.Commands.AffiliateCampaign
{
    public class CreateOrUpdateAffiliateCampaignCommand : AffiliateCampaignRequest, IRequest<BaseResponseCode>
    {
        public long StoreId { get; set; }
        public string UserLogin { get; set; }

        public CreateOrUpdateAffiliateCampaignCommand() { }
    }
}
