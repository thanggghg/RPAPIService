namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class AffiliateCampaignDetailViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public long AffiliateStoreId { get; set; }
        public string AffiliateStoreCurrencySymbol { get; set; }
        public IEnumerable<AffiliateCampaignProductViewModel> AffiliateCampaignProducts { get; set; }
    }

    public class AffiliateCampaignProductViewModel
    {
        public long Id {  set; get; }
        public long CampaignId { get; set; }
        public decimal CommissionPercent { get; set; }
        public decimal CommissionFix { get; set; }

        // product info
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductRefId { get; set; }
        public string ProductImageUrl { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public bool IsOutOfStock { get; set; }
        public bool IsStopSelling { get; set; }
        public bool IsDeleteProduct { get; set; }
        public int Status { get; set; }
    }
}
