using RP.Library.Helpers;
using MediatR;

namespace RP.Affiliate.Tracking.Commands.AffiliateCampaign
{
    public class TerminateAffiliateCampaignCommand : IRequest<GenericResponse<int>>
    {
        public long Id { get; set; }
        public TerminateAffiliateCampaignCommand() { }
    }
}
