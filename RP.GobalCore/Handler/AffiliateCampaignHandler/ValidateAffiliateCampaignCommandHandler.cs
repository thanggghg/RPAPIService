using GoSell.Affiliate.Tracking.Functions.Interface;
using GoSell.Affiliate.Tracking.Queries.AffiliateCampaign;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateProductHandler
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
