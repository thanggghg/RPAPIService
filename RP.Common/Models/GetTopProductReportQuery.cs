using MediatR;

namespace GoSell.Common.Models
{
    public class GetTopProductReportQuery : TopSellingReportRequest, IRequest<List<TopProductsReportResponse>>
    {
    }
}
