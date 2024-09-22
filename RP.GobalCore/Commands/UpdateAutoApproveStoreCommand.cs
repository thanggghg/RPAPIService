using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    public class UpdateAutoApproveStoreCommand : IRequest<bool>
    {
        public long GosellStoreId { get; set; }
        public long? AffilateStoreId { get; set; }
    }
}
