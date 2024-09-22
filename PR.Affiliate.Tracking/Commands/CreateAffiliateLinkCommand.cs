using System.Runtime.Serialization;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    [DataContract]
    public class CreateAffiliateLinkCommand : IRequest<List<string>>
    {
        [DataMember]
        public long? CampaignId { get; set; }
        [DataMember]
        public List<string> OriginLinks { get; set; } = new List<string>();
        [DataMember]
        public string SubId1 { get; set; } = string.Empty;
        [DataMember]
        public string SubId2 { get; set; } = string.Empty;
        [DataMember]
        public string SubId3 { get; set; } = string.Empty;
        [DataMember]
        public string SubId4 { get; set; } = string.Empty;
        [DataMember]
        public string SubId5 { get; set; } = string.Empty;
    }
}
