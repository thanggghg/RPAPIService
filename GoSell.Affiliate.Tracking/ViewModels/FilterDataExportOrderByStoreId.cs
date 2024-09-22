namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class FilterDataExportOrderByStoreId
    {
        public int TypeId { get; set; }
        public List<long> ExternalStoreIds { get; set; } = new List<long>();
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string SearchString { get; set; } = null;
        public int? SearchType { get; set; } = null;
        public int? ApprovalStatus { get; set; } = null;
        public DateTime? FromDate { get; set; } = null;
        public DateTime? ToDate { get; set; } = null;
        public string ClientTimeZone { get; set; } = null;
    }
}
