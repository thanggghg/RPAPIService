using RP.Affiliate.Tracking.Commons.Enums;

namespace RP.Affiliate.Tracking.ViewModels
{
    public class TrackingOrderOfPublishersViewModel
    {
        public long PublisherId { get; set; }
        public List<OrderDetailsOfPublisherViewModel> Orders { get; set; } = new List<OrderDetailsOfPublisherViewModel>();
    }

    public class OrderDetailsOfPublisherViewModel
    {
        public DateTime CreatedDate { get; set; }
        public SubmissionStatusEnum OrderStatus { get; set; }
        public string OrderId { get; set; }
        public string Platform { get; set; }
        public decimal Total { get; set; }
        public decimal TaxFee { get; set; }
        public decimal ShippingFee { get; set; }
        public decimal DiscountFee { get; set; }
        public List<ProductDetailsViewModel> Products { get; set; } = new List<ProductDetailsViewModel>();
    }

    public class ProductDetailsViewModel
    {
        public string ProductId { get; set; }
        public long Quantity { get; set; }
        public decimal Total { get; set; }
        public string CategoryId { get; set; }
    }
}
