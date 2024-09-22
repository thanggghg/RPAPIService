namespace GoSell.Common.Models
{
    public class TopProductsReportResponse
    {
        public string AffiliateProductId { get; set; }
        public string ProductName { get; set; }
        public string ImgUrl { get; set; }
        public decimal Revenue { get; set; }
        public decimal QuantitySold { get; set; }
    }
}
