using RP.Affiliate.Tracking.Commands.AffiliateCampaign;
using RP.Affiliate.Tracking.Functions.Interface;
using RP.Affiliate.Tracking.ViewModels;
using RP.Library.Helpers;
using MediatR;

namespace RP.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class PublishAffiliateCampaignCommandHandler : IRequestHandler<PublishAffiliateCampaignCommand, GenericResponse<int>>
    {
        private readonly IAffiliateCampaignFunctions _affiliateCampaignFunctions;

        public PublishAffiliateCampaignCommandHandler(IAffiliateCampaignFunctions affiliateCampaignFunctions)
        {
            _affiliateCampaignFunctions = affiliateCampaignFunctions;
        }

        public async Task<GenericResponse<int>> Handle(PublishAffiliateCampaignCommand command, CancellationToken cancellationToken)
        {
            return await _affiliateCampaignFunctions.PublishAffiliateCampaignAsync(command);
        }
    }
}
