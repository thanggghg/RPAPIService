using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    public class UpdatePartnerSubmissionCommand : IRequest<Tuple<bool, string>>
    {
        public long SubmissionId { get; set; }
        public long ExternalStoreId { get; set; }
        public long? PartnerId { get; set; }
        public string PartnerFullName { get; set;}
        public string PartnerPhoneNumber { get; set;}
    }

}
