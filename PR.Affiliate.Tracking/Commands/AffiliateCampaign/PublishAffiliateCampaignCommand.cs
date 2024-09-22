using GoSell.Affiliate.Tracking.Models.Requests;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands.AffiliateCampaign
{
    public class PublishAffiliateCampaignCommand : IRequest<GenericResponse<int>>
    {
        public long? Id { get; set; }
        public long AffiliateStoreId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public List<CampaignProductRequest> Products { get; set; }
        public PublishAffiliateCampaignCommand() { }
    }
}
