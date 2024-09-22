namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class AffiliateUrlReportViewModel
    {
        public List<AffiliateUrlModel> Data { get; set; } = new List<AffiliateUrlModel>();
        public decimal SumTotalClick { get; set; }
        public decimal SumTotalOfOrder { get; set; }
        public int TotalCount { get; set; }
        public AffiliateUrlReportViewModel() { }
        public AffiliateUrlReportViewModel(List<AffiliateUrlModel> data,
            decimal sumTotalOfOrder,
            decimal sumTotalClick,
            int totalCount)
        {
            Data = data;
            SumTotalOfOrder = sumTotalOfOrder;
            SumTotalClick = sumTotalClick;
            TotalCount = totalCount;
        }
    }

    public class AffiliateUrlModel
    {
        public Guid TrachkingUrlId { get; set; }
        public string TrackingUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ProductImageUrl { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string CampaignName { get; set; }
        public long CampaignId { get; set; }
        public string SubId01 { get; set; }
        public string SubId02 { get; set; }
        public string SubId03 { get; set; }
        public string SubId04 { get; set; }
        public string SubId05 { get; set; }
        public decimal TotalOfOrder { get; set; } // Document not require
        public decimal TotalClick { get; set; }

    }
}
