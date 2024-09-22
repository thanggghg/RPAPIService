using MediatR;

namespace GoSell.Common.Models
{
    public class GetTopPublishersReportQuery : TopSellingReportRequest, IRequest<List<TopPublishersReportResponse>>
    {
    }
}
