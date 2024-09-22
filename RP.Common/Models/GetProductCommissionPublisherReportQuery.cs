using MediatR;

namespace GoSell.Common.Models
{
    public class GetProductPublisherCommissionReportQuery : IRequest<ProductPublisherCommissionReportResponse>
    {
        public long UserId { get; set; }
        public long AffiliateStoreId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string SearchType { get; set; }
        public string SearchKeyword { get; set; }
        public int Page { get; set; }
        public int Size { get; set; } = 20;
    }
}
