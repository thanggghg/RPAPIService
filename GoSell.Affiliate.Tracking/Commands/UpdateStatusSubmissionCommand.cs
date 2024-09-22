using GoSell.Affiliate.Tracking.Commons.Enums;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    public class UpdateStatusSubmissionCommand : IRequest<Tuple<bool, string>>
    {
        public long SubmissionId { get; set; }
        public SubmissionStatusEnum SubmissionStatus { get; set; }
        public SubmissionTypeEnum SubmissionType { get; set; }
        public long ExternalStoreId { get; set; }
    }

}
