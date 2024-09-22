using RP.Affiliate.Tracking.Commands.AffiliateCampaign;
using RP.Affiliate.Tracking.Queries.AffiliateCampaign;
using RP.Affiliate.Tracking.ViewModels;
using RP.Library.Helpers;

namespace RP.Affiliate.Tracking.Functions.Interface
{
    public interface IAffiliateCampaignFunctions
    {
        Task<BaseResponse> DeleteAffiliateCampaign(DeleteAffiliateCampaignCommand request);
        Task<GenericResponse<int>> PublishAffiliateCampaignAsync(PublishAffiliateCampaignCommand command);
        Task<GenericResponse<int>> TerminateAffiliateCampaignAsync(TerminateAffiliateCampaignCommand command);
        Task<GenericResponse<int>> ValidateAffiliateCampaignAsync(ValidateAffiliateCampaignQuery command);        
    }
}
