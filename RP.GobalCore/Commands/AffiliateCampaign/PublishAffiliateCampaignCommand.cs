using RP.Affiliate.Tracking.Models.Requests;
using RP.Affiliate.Tracking.ViewModels;
using RP.Library.Helpers;
using MediatR;

namespace RP.Affiliate.Tracking.Commands.AffiliateCampaign
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
