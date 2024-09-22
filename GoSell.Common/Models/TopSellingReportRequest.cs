namespace GoSell.Common.Models
{
    public class TopSellingReportRequest : DashboardReportBaseQuery
    {
        public string SortType { get; set; }
        public string OrderBy { get; set; }
        public string ThenBy { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
