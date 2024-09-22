using System.Runtime.Serialization;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    [DataContract]
    public class CreateOrderTrackingCommand : IRequest<bool>
    {
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public string TrackingIds { get; set; }
        [DataMember]
        public string Website { get; set; }

        public CreateOrderTrackingCommand(string orderId, string trackingIds, string website)
        {
            OrderId = orderId;
            TrackingIds = trackingIds;
            Website = website;
        }
    }
}
