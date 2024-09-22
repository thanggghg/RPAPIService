using RP.Affiliate.Tracking.Functions.Interface;
using RP.Affiliate.Tracking.Queries.AffiliateCampaign;
using RP.Affiliate.Tracking.ViewModels;
using RP.Library.Helpers;
using MediatR;

namespace RP.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class ValidateAffiliateCampaignCommandHandler : IRequestHandler<ValidateAffiliateCampaignQuery, GenericResponse<int>>
    {
        private readonly IAffiliateCampaignFunctions _affiliateCampaignFunctions;

        public ValidateAffiliateCampaignCommandHandler(IAffiliateCampaignFunctions affiliateCampaignFunctions)
        {
            _affiliateCampaignFunctions = affiliateCampaignFunctions;
        }

        public async Task<GenericResponse<int>> Handle(ValidateAffiliateCampaignQuery command, CancellationToken cancellationToken)
        {
            return await _affiliateCampaignFunctions.ValidateAffiliateCampaignAsync(command);
        }
    }
}
