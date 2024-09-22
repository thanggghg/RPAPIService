namespace GoSell.Common.Models
{
    public class ProductCommissionReportResponse
    {
        public List<ProductCommissionReportModel> Data { get; set; }
        public bool isError { get; set; } = false;
        public int ErrrorCode { get; set; } = 0;
        public int Total { get; set; }
        public decimal SumOfRevenue { get; set; }
        public long SumOfQuantity { get; set; }
        public decimal SumOfCommission { get; set; }
    }
    public class ProductCommissionReportModel
    {
        public string RefProductId { get; set; }
        public string ImageUrl { get; set; }
        public string ProductName { get; set; }
        public decimal SoldRevenue { get; set; }
        public long SoldQuantity { get; set; }
        public decimal TotalCommission { get; set; }
        public decimal RevenueSpread { get; set; }
        //public decimal ApprovedCommission { get; set; }
        //public decimal InProgressCommission { get; set; }
        //public decimal RejectedCommission { get; set; }
    }

    public class CommissionReportModel
    {
        public string RefProductId { get; set; }
        public decimal TotalCommission { get; set; }
    }
}
