using GoSell.Common.Enums;

namespace GoSell.Common.Models
{
    public class DashboardReportBaseQuery
    {
        public long GoSellStoreId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public StoreStatusEnum StoreStatus { get; set; }
        public long AffiliateStoreId { get; set; }
    }
}
