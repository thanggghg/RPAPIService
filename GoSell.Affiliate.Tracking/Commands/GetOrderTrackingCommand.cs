using System.Runtime.Serialization;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    [DataContract]
    public class GetOrderTrackingCommand : IRequest<List<AffiliateOrderTrackingViewModel>>
    {
        public long LatestId { get; set; } = 0;
        public GetOrderTrackingCommand(long latestId)
        {
            LatestId = latestId;
        }
    }

    [DataContract]
    public class UpdateAffiliateOrderTrackingToTestedCommand : IRequest<bool>
    {
        public List<long> Ids { get; set; }
        public UpdateAffiliateOrderTrackingToTestedCommand(List<long> ids)
        {
            Ids = ids;
        }
    }
}
