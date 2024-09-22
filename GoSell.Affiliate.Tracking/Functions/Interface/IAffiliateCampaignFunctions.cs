using GoSell.Affiliate.Tracking.Commands.AffiliateCampaign;
using GoSell.Affiliate.Tracking.Queries.AffiliateCampaign;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers;

namespace GoSell.Affiliate.Tracking.Functions.Interface
{
    public interface IAffiliateCampaignFunctions
    {
        Task<BaseResponse> DeleteAffiliateCampaign(DeleteAffiliateCampaignCommand request);
        Task<GenericResponse<int>> PublishAffiliateCampaignAsync(PublishAffiliateCampaignCommand command);
        Task<GenericResponse<int>> TerminateAffiliateCampaignAsync(TerminateAffiliateCampaignCommand command);
        Task<GenericResponse<int>> ValidateAffiliateCampaignAsync(ValidateAffiliateCampaignQuery command);        
    }
}
