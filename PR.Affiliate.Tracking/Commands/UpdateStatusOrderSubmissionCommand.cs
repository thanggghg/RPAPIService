using GoSell.Affiliate.Tracking.Commons.Enums;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    public class UpdateStatusOrderSubmissionCommand : IRequest<bool>
    {
        public List<long> submissionOrderIds { get; set; }
        public SubmissionStatusEnum submissionStatus { get; set; }
        public SubmissionTypeEnum submissionType { get; set; }
        public long externalStoreId { get; set; }
    }

}
