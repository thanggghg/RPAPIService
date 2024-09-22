using GoSell.Affiliate.Tracking.Commands.AffiliateCampaign;
using GoSell.Affiliate.Tracking.Models.Requests;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries.AffiliateCampaign
{
    public class ValidateAffiliateCampaignQuery : IRequest<GenericResponse<int>>
    {
        public long? Id { get; set; }
        public long AffiliateStoreId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public List<CampaignProductRequest> Products { get; set; }
        public ValidateAffiliateCampaignQuery() { }

        public ValidateAffiliateCampaignQuery(PublishAffiliateCampaignCommand affiliateCampaignCommand)
        {
            Id = affiliateCampaignCommand.Id;
            AffiliateStoreId = affiliateCampaignCommand.AffiliateStoreId;
            Name = affiliateCampaignCommand.Name;
            StartDate = affiliateCampaignCommand.StartDate;
            EndDate = affiliateCampaignCommand.EndDate;
            Status = affiliateCampaignCommand.Status;
            Products = affiliateCampaignCommand.Products;            
        }
    }
}
