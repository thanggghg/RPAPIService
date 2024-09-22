namespace GoSell.Affiliate.Tracking.Models.Requests
{
    public class AffiliateCategoryRequest
    {
        public long Id {  get; set; }
        public string Name { get; set; }
        public string RefCategoryId { get; set; }
        public bool Status { get; set; }
        public long StoreId { get; set; }
        public long AffiliateStoreId { get; set; }
        public bool IsDelete { get; set; }
    }
}
