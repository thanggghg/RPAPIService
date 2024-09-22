namespace GoSell.Affiliate.Tracking.Models.Requests
{
    public class AffiliateProductsRequest
    {
        public List<string> ProductIds { get; set; }
        public long AffiliateStoreId { get; set; }
    }
}
