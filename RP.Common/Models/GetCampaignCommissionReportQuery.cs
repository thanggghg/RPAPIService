using GoSell.Common.Enums;
using MediatR;

namespace GoSell.Common.Models
{
    public class GetCampaignCommissionReportQuery : IRequest<CampaignCommissionReportResponse>
    {
        public long GoSellStoreId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string SearchKeyword { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public StoreStatusEnum StoreStatus { get; set; }
        public long AffiliateStoreId { get; set; }
    }
}
