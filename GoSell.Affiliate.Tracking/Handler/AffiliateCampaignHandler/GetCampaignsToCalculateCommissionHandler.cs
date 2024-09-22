using GoSell.Affiliate.Tracking.Queries.AffiliateCampaign;
using GoSell.Affiliate.Tracking.Repositories.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateCampaignHandler
{
    public class GetCampaignsToCalculateCommissionHandler : IRequestHandler<GetCampaignsToCalculateCommissionQuery, List<CampaignToCalculateCommissionModel>>
    {
        private readonly IAffiliateCampaignRepository _affiliateCampaignRepository;

        public GetCampaignsToCalculateCommissionHandler(IAffiliateCampaignRepository affiliateCampaignRepository)
        {
            _affiliateCampaignRepository = affiliateCampaignRepository;
        }

        public async Task<List<CampaignToCalculateCommissionModel>> Handle(GetCampaignsToCalculateCommissionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _affiliateCampaignRepository.GetCampaignsToCommissionCalculateAsync(request.AffiliateStoreId, request.FromDate, request.ToDate);
                return data;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetCampaignsToCalculateCommissionHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
