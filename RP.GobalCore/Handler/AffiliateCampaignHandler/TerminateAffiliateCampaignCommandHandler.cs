using RP.Affiliate.Tracking.Commands.AffiliateCampaign;
using RP.Affiliate.Tracking.Functions.Interface;
using RP.Affiliate.Tracking.ViewModels;
using RP.Library.Helpers;
using MediatR;

namespace RP.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class TerminateAffiliateCampaignCommandHandler : IRequestHandler<TerminateAffiliateCampaignCommand, GenericResponse<int>>
    {
        private readonly IAffiliateCampaignFunctions _affiliateCampaignFunctions;

        public TerminateAffiliateCampaignCommandHandler(IAffiliateCampaignFunctions affiliateCampaignFunctions)
        {
            _affiliateCampaignFunctions = affiliateCampaignFunctions;
        }

        public async Task<GenericResponse<int>> Handle(TerminateAffiliateCampaignCommand command, CancellationToken cancellationToken)
        {
            return await _affiliateCampaignFunctions.TerminateAffiliateCampaignAsync(command);
        }
    }
}
