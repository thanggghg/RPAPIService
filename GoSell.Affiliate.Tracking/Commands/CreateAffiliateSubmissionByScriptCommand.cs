using GoSell.Affiliate.Tracking.Commons.Enums;
using GoSell.Affiliate.Tracking.Models.Requests;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    public class CreateAffiliateSubmissionByScriptCommand : IRequest<(int, string)>
    {
        public string ConversionId { get; set; }
        public List<Guid> TrackingIds { get; set; }
        public string ClickId { get; set; }
        public string GroupId { get; set; }
        public SubmissionTypeEnum SubmissionType { get; set; }
        public string ApiKey { get; set; }
        public dynamic OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime? CreatedSubmissionTime { get; set; }
        public decimal? SubTotalAmount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? FeeAmount { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? ShippingFee { get; set; }
        public decimal? TotalAmount { get; set; }
        public List<AffiliateOrderDetailRequest> OrderItems { get; set; } = new List<AffiliateOrderDetailRequest>();
    }

}
