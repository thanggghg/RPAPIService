using GoSell.Affiliate.Tracking.Commons.Enums;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class GetPublishersByAffStoreIdQuery : IRequest<List<TrackingOrderOfPublishersViewModel>>
    {
        public required long ExternalStoreId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TrackingPrioritizeEnum? TrackingPrioritize { get; set; } = 0;
        public long? PublisherId { get; set; }
        public GetPublishersByAffStoreIdQuery() { }
        public bool? IsRunCronJob { get; set; }
    }
}
