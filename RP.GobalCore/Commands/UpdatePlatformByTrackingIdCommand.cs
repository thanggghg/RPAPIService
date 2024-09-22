using GoSell.Affiliate.Tracking.Commons.Enums;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    public class UpdatePlatformByTrackingIdCommand : IRequest<bool>
    {
        public Guid TrackingId { get; set; }
        public PlatformEnum Platform { get; set; }
        public UpdatePlatformByTrackingIdCommand() { }
        public string Sub02 { get; set; }
        public string Sub03 { get; set; }
        public string Sub04 { get; set; }
        public string Sub05 { get; set; }
    }
}
