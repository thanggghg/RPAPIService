namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class CampaignToCalculateCommissionModel
    {
        public long CampaignId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public long AffiliateStoreId { get; set; }
        public IEnumerable<AffiliateProductForCommissionModel> Products { get; set; }
    }

    public class AffiliateProductForCommissionModel
    {
        public long ProductId { get; set; }
        public string ProductRefId { get; set; }
        public decimal CommissionPercent { get; set; }
        public decimal CommissionFix { get; set; }
    }
}
