namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class AffiliateProductViewModel
    {
        public long Id { get; set; }

        public string RefProductId { get; set; }

        public string Name { get; set; }

        public long? CategoryId { get; set; }

        public string Category { get; set; }

        public string ProductUrl { get; set; }

        public decimal? RegularPrice { get; set; }

        public decimal? SalePrice { get; set; }

        public string SalePriceCurrency { get; set; }

        public string RegularPriceCurrency { get; set; }

        public bool IsOutOfStock { get; set; }

        public bool IsStopSelling { get; set; }

        public decimal? Percentage { get; set; }

        public decimal? FixValue { get; set; }

        public decimal EarnValue { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; }

        public long AffiliateStoreId { get; set; }

        public string AffiliateStoreName { get; set; }

        public bool? IsShowLink { get; set; }
    }
}
