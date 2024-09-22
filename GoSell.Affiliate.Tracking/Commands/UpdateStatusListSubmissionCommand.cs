using GoSell.Affiliate.Tracking.Commons.Enums;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    public class UpdateStatusListSubmissionCommand : IRequest<long>
    {
        public List<long> SubmissionIds { get; set; }
        public SubmissionStatusEnum SubmissionStatus { get; set; }
        public SubmissionTypeEnum SubmissionType { get; set; }
        public List<long> ExternalStoreIds { get; set; }
    }

}
