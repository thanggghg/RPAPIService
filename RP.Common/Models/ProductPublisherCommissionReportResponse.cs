namespace GoSell.Common.Models
{
    public class ProductPublisherCommissionReportResponse
    {
        public List<ProductPublisherCommissionReportModel> Data { get; set; } = new List<ProductPublisherCommissionReportModel>();
        public bool isError { get; set; } = false;
        public int ErrrorCode { get; set; } = 0;
        public int Total { get; set; }
        public decimal SumOfRevenue { get; set; }
        public long SumOfQuantity { get; set; }
        public decimal SumOfCommission { get; set; }
    }
    public class ProductPublisherCommissionReportModel
    {
        public string RefProductId { get; set; }
        public string ImageUrl { get; set; }
        public string ProductName { get; set; }
        public decimal SoldRevenue { get; set; }
        public long SoldQuantity { get; set; }
        public decimal Commission { get; set; }
        public decimal RevenueSpread { get; set; }
    }
}
