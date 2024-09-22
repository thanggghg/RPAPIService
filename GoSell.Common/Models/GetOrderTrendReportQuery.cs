using GoSell.Common.Enums;
using MediatR;

namespace GoSell.Common.Models
{
    public class GetOrderTrendReportQuery : DashboardReportBaseQuery, IRequest<OrderTrendReportResponse>
    {
        public OrderTrendModeEnum OrderTrendMode { get; set; }
    }
}
