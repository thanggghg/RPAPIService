using GoSell.Affiliate.Tracking.Commons.Enums;
using GoSell.Affiliate.Tracking.Models.Requests;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    public class CreateAffiliateSubmissionCommand : IRequest<(int, string)>
    {
        public string ConversionId { get; set; }
        public List<Guid> TrackingIds { get; set; } = new List<Guid>();
        public string ClickId { get; set; }
        public string GroupId { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public SubmissionTypeEnum? SubmissionType { get; set; } = SubmissionTypeEnum.ORDER;
        public string ApiKey { get; set; }
        public dynamic OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime? CreatedSubmissionTime { get; set; }
        public decimal? SubTotalAmount { get; set; } = 0;
        public decimal? DiscountAmount { get; set; } = 0;
        public decimal? FeeAmount { get; set; } = 0;
        public decimal? TaxAmount { get; set; } = 0;
        public decimal? ShippingFee { get; set; } = 0;
        public decimal? TotalAmount { get; set; } = 0;
        public List<AffiliateOrderDetailRequest> OrderItems { get; set; } = new List<AffiliateOrderDetailRequest>();
    }

}
