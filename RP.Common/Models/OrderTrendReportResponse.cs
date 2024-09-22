namespace GoSell.Common.Models
{
    public class OrderTrendReportResponse
    {
        public List<OrderTrendModel> Data { get; set; }
    }
    public class OrderTrendModel
    {
        public string TimeFormat { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalOrders { get; set; }
    }
}
