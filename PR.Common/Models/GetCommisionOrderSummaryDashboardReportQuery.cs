using MediatR;

namespace GoSell.Common.Models
{
    public class GetCommisionOrderSummaryDashboardReportQuery : DashboardReportBaseQuery, IRequest<SummaryDashboardReportResponse>
    {
    }
}
