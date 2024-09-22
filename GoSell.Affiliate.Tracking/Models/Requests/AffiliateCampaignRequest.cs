namespace GoSell.Affiliate.Tracking.Models.Requests
{
    public class AffiliateCampaignRequest
    {
        public long? Id { get; set; }
        public long AffiliateStoreId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPublish { get; set; }
        
        public int? currentStatus { get; set; }
        public List<CampaignProductRequest> Products { get; set; }
    }

    public class CampaignProductRequest
    {
        public long ProductId { get; set; }
        public decimal CommissionPercent { get; set; } = 0;
        public decimal CommissionFix { get; set; } = 0;
    }
}
