using RP.Affiliate.Tracking.Queries.AffiliateCampaign;
using RP.Affiliate.Tracking.Repositories.Interfaces;
using RP.Affiliate.Tracking.ViewModels;
using MediatR;
using Serilog;

namespace RP.Affiliate.Tracking.Handler.AffiliateCampaignHandler
{
    public class GetCampaignsHappeningForPublisherIncludeProductHandler(IAffiliateCampaignRepository affiliateCampaignRepository) : IRequestHandler<GetCampaignsHappeningForPublisherIncludeProductQuery, List<CampaignsHappeningForPublisherIncludeProductModel>>
    {
        private readonly IAffiliateCampaignRepository _affiliateCampaignRepository = affiliateCampaignRepository;

        public async Task<List<CampaignsHappeningForPublisherIncludeProductModel>> Handle(GetCampaignsHappeningForPublisherIncludeProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _affiliateCampaignRepository.GetCampaignsHappeningForPublisherIncludeProductAsync(request);
                return data;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetCampaignsHappeningForPublisherIncludeProductHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
