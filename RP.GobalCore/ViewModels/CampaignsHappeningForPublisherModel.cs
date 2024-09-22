namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class CampaignsHappeningForPublisherModel
    {
        public long CampaignId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public long AffiliateStoreId { get; set; }
    }

    public class CampaignsHappeningForPublisherIncludeProductModel : CampaignsHappeningForPublisherModel
    {
        public IEnumerable<AffiliateProductForCampaignModel> Products { get; set; }
    }

    public class AffiliateProductForCampaignModel
    {
        public long Id { get; set; }
        public string RefProductId { get; set; }
        public string Name { get; set; }
        public string ProductUrl { get; set; }
        public decimal? RegularPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public bool IsOutOfStock { get; set; }
        public bool IsStopSelling { get; set; }
        public decimal? Percentage { get; set; }
        public decimal? FixValue { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal EarnValue { get; set; }
    }
}
