using System.Net;
using GoSell.Affiliate.Tracking.Commands.AffiliateCampaign;
using GoSell.Affiliate.Tracking.Commons.Enums;
using GoSell.Affiliate.Tracking.Functions.Interface;
using GoSell.Affiliate.Tracking.Repositories;
using GoSell.Affiliate.Tracking.Repositories.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class CronJobUpdateAllExpriredCampaignHandler : IRequestHandler<UpdateAllExpriredCampaignCommand, GenericResponse<int>>
    {
        private readonly IAffiliateCampaignRepository _affiliateCampaignRepository;

        public CronJobUpdateAllExpriredCampaignHandler(IAffiliateCampaignRepository affiliateCampaignRepository)
        {
            _affiliateCampaignRepository = affiliateCampaignRepository;
        }

        public async Task<GenericResponse<int>> Handle(UpdateAllExpriredCampaignCommand query, CancellationToken cancellationToken)
        {
            var res = 0;
            try
            {
                res = await _affiliateCampaignRepository.CronJobUpdateAllExpriredCampaignAsync(query.AffiliateStoreId);
                return new GenericResponse<int>(HttpStatusCode.OK, "CronJob Update Exprired CampaignAsync Successfully", res);
            }
            catch
            {
                return new GenericResponse<int>(HttpStatusCode.NoContent, "Error CronJob Update Exprired CampaignAsync", res);
            }
        }
    }
}
