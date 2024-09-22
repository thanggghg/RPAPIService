using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Queries
{
    public class GetSpecificAffiliateSubmissionBySubmisstionIdQuery : IRequest<OrderDetailsViewModel>
    {
        public long SubmissionId { get; set; }
        public GetSpecificAffiliateSubmissionBySubmisstionIdQuery(long submissionId)
        {
            SubmissionId = submissionId;
        }
    }
}
