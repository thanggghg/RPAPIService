using MediatR;
using Microsoft.Extensions.Logging;

namespace GoSell.Affiliate.Tracking.Services
{
    public class AffiliateCampaignServices
    {
        public IMediator Mediator { get; set; }
        public ILogger<AffiliateCampaignServices> Logger { get; }
        public AffiliateCampaignServices(IMediator mediator, ILogger<AffiliateCampaignServices> logger)
        {
            Mediator = mediator;
            Logger = logger;
        }
    }
}
