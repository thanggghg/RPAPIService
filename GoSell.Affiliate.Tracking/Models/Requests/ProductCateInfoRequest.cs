namespace GoSell.Affiliate.Tracking.Models.Requests
{
    public class ProductCateInfoRequest
    {
        public long AffiliateStoreId { get; set; }
        public List<string> AffiliateProductIds { get; set; } = new List<string>();
    }
}
