using GoSell.Affiliate.Tracking.Commands.AffiliateCampaign;
using GoSell.Affiliate.Tracking.Functions.Interface;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateProductHandler
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
