using System.Runtime.Serialization;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    [DataContract]
    public class CreateClickTrackingCommand : IRequest<bool>
    {
        [DataMember]
        public string ClickId { get; set; }
        [DataMember]
        public string GroupId { get; set; }
        [DataMember]
        public Guid TrackingId { get; set; } = Guid.NewGuid();
        [DataMember]
        public string PlatForm { get; set; }
        [DataMember]
        public string Device { get; set; }

        public CreateClickTrackingCommand(string clickId, Guid trackingId, string groupId, string platform, string device)
        {
            ClickId = clickId;
            TrackingId = trackingId;
            PlatForm = platform;
            Device = device;
            GroupId = groupId;
        }
    }
}
