namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class AffiliateCampaignViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int NumOfProduct { get; set; }
        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string TerminatedBy { get; set; }
        public DateTime? TerminatedDate { get; set; }
        public long AffiliateStoreId { get; set; }
    }
}
