using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands.AffiliateCampaign
{
    public class UpdateAllExpriredCampaignCommand : IRequest<GenericResponse<int>>
    {
        public long AffiliateStoreId { get; set; }
    }
}
