using GoSell.Affiliate.Tracking.Commands.AffiliateCampaign;
using GoSell.Affiliate.Tracking.Functions.Interface;
using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Service;
using MediatR;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class DeleteAffiliateCampaignCommandHandler : IRequestHandler<DeleteAffiliateCampaignCommand, BaseResponse>
    {
        private readonly IAffiliateCampaignFunctions _affiliateCampaignFunctions;
        private readonly IBaseService _baseService;
        public DeleteAffiliateCampaignCommandHandler(IAffiliateCampaignFunctions affiliateCampaignFunctions, IBaseService baseService)
        {
            _affiliateCampaignFunctions = affiliateCampaignFunctions;
            _baseService = baseService;
        }

        public async Task<BaseResponse> Handle(DeleteAffiliateCampaignCommand request, CancellationToken cancellationToken)
        {
            return await _affiliateCampaignFunctions.DeleteAffiliateCampaign(request);
        }
    }
}
