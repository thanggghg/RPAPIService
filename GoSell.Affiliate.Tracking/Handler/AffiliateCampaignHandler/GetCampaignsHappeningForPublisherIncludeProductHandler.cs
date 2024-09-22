using GoSell.Affiliate.Tracking.Queries.AffiliateCampaign;
using GoSell.Affiliate.Tracking.Repositories.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateCampaignHandler
{
    public class GetCampaignsHappeningForPublisherHandler(IAffiliateCampaignRepository affiliateCampaignRepository) : IRequestHandler<GetCampaignsHappeningForPublisherQuery, List<CampaignsHappeningForPublisherModel>>
    {
        private readonly IAffiliateCampaignRepository _affiliateCampaignRepository = affiliateCampaignRepository;
        private readonly int _size = 3;

        public async Task<List<CampaignsHappeningForPublisherModel>> Handle(GetCampaignsHappeningForPublisherQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _affiliateCampaignRepository.GetCampaignsHappeningForPublisherAsync(request.AffiliateStoreId, _size);
                return data;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetCampaignsHappeningForPublisherHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
