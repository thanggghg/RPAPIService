using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands.AffiliateCampaign
{
    public class TerminateAffiliateCampaignCommand : IRequest<GenericResponse<int>>
    {
        public long Id { get; set; }
        public TerminateAffiliateCampaignCommand() { }
    }
}
