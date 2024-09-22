namespace GoSell.Common.Models
{
    public class CampaignCommissionReportResponse
    {
        public List<CampaignCommissionReportModel> Data { get; set; }
        public bool isError { get; set; } = false;
        public int ErrrorCode { get; set; } = 0;
        public string ErrorMessage { get; set; }
        public int Total { get; set; } = 0;
        public long SumOfOrderQuantity { get; set; } = 0;
        public decimal SumOfOrderRevenue { get; set; } = 0;
        public long SumOfCampaignOrderQuantity { get; set; } = 0;
        public decimal SumOfCampaignRevenue { get; set; } = 0;
        public decimal SumOfCommission { get; set; } = 0;
    }
    public class CampaignCommissionReportModel
    {
        public long CampaignId { get; set; }
        public string CampaignName { get; set; }
        public long ProductCount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long OrderQuantity { get; set; }
        public decimal OrderRevenue { get; set; }
        public long CampaignOrderQuantity { get; set; }
        public decimal CampaignRevenue { get; set; }
        public decimal TotalCommission { get; set; }
        public decimal PaidCommission { get; set; }
        public decimal ApprovedCommission { get; set; }
        public decimal InProgressCommission { get; set; }
        public decimal RejectedCommission { get; set; }
        public decimal RevenueSpread { get; set; }
    }
}
