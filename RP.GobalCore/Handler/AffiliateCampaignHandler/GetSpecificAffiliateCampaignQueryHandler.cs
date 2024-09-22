using System.Net;
using RP.Affiliate.Tracking.Queries.AffiliateCampaign;
using RP.Affiliate.Tracking.Repositories.Interfaces;
using RP.Affiliate.Tracking.ViewModels;
using RP.Library.Helpers;
using RP.Library.Helpers.Service;
using MediatR;
using Serilog;

namespace RP.Affiliate.Tracking.Handler.AffiliateCampaignHandler
{
    public class GetSpecificAffiliateCampaignQueryHandler(IAffiliateCampaignRepository affiliateCampaignRepository,
                                        IBaseService baseService) : IRequestHandler<GetSpecificAffiliateCampaignQuery, GenericResponse<AffiliateCampaignDetailViewModel>>
    {
        private readonly IAffiliateCampaignRepository _affiliateCampaignRepository = affiliateCampaignRepository;
        private readonly IBaseService _baseService = baseService;

        public async Task<GenericResponse<AffiliateCampaignDetailViewModel>> Handle(GetSpecificAffiliateCampaignQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateCampaign = await _affiliateCampaignRepository.GetDetailViewModelByIdAsync(request.Id);

                if(affiliateCampaign == null || _baseService.isInvalidAffiliateStore(affiliateCampaign.AffiliateStoreId, request.StoreId))
                    return new GenericResponse<AffiliateCampaignDetailViewModel>(HttpStatusCode.NotFound, "Not found Affiliate Store");

                
                return new GenericResponse<AffiliateCampaignDetailViewModel>(HttpStatusCode.OK, "Campaign detail", affiliateCampaign);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetSpecificAffiliateCampaignQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
