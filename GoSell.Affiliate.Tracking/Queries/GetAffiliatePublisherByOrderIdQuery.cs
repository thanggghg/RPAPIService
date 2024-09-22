using MediatR;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class GetAffiliatePublisherByOrderIdQuery : IRequest<long>
    {
        public long OrderId { get; }
        public bool IsLast { get; }
        public GetAffiliatePublisherByOrderIdQuery(long orderId, bool isLast)
        {
            OrderId = orderId;
            IsLast = isLast;
        }
    }
}
