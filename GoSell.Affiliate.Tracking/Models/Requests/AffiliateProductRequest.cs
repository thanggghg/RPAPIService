namespace GoSell.Affiliate.Tracking.Models.Requests
{
    public class AffiliateProductRequest
    {
        public long Id { get; set; }
        public string ImageUrl { get; set; }
        public string RefProductId { get; set; }
        public string Name { get; set; }
        public long? CategoryId { get; set; }
        public string Description { get; set; }
        public string ProductUrl { get; set; }
        public decimal? RegularPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public bool IsOutOfStock { get; set; }
        public bool IsStopSelling { get; set; }
        public bool IsPercentage { get; set; }
        public decimal? Percentage { get; set; }
        public bool IsFixValue { get; set; }
        public decimal? FixValue { get; set; }
        public bool? IsActive { get; set; }
        public long AffiliateStoreId { get; set; }
        public long? CollectionId { get; set; }
        public bool? IsDelete { get; set; }
        public string TokenAPI { get; set; }
        
    }
}
