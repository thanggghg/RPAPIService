using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands.AffiliateCategory
{
    public class ChangeStatusAffiliateCategoryCommand : IRequest<BaseResponse>
    {
        public long Id { get; set; }
        public bool Status { get; set; }
        public ChangeStatusAffiliateCategoryCommand() { }

        public ChangeStatusAffiliateCategoryCommand(long id, bool status) {
            Id = id;
            Status = status;
        }
    }
}
