using RP.Library.Helpers;
using MediatR;

namespace RP.Affiliate.Tracking.Commands.AffiliateCampaign
{
    public class UpdateAllExpriredCampaignCommand : IRequest<GenericResponse<int>>
    {
        public long AffiliateStoreId { get; set; }
    }
}
