using System.Net;
using RP.Affiliate.Tracking.Commands.AffiliateCampaign;
using RP.Affiliate.Tracking.Commons.Enums;
using RP.Affiliate.Tracking.Functions.Interface;
using RP.Affiliate.Tracking.Repositories;
using RP.Affiliate.Tracking.Repositories.Interfaces;
using RP.Affiliate.Tracking.ViewModels;
using RP.Library.Helpers;
using MediatR;

namespace RP.Affiliate.Tracking.Handler.AffiliateProductHandler
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
