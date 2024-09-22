namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class OrderDetailsViewModel
    {
        public List<string> TrackingIds { get; set; }
        public string ClickId { get; set; }
        public long ExternalStoreId { get; set; }
        public string GroupId { get; set; }
        public int SubmissionType { get; set; }
        public int Status { get; set; }
        public string OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public long? PartnerId { get; set; }
        public DateTime OrderCreatedDate { get; set; }
        public decimal SubTotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FeeAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal ShippingFee { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencyCode { get; set; }

        public List<AffiliateOrderViewModel> AffiliateOrderDetails { get; set; }
    }

    public class AffiliateOrderViewModel
    {
        public string CategoryId { get; set; }
        public string Sku { get; set; }
        public string ProductId { get; set; }
        public long SubmissionId { get; set; }
        public string ItemName { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public long Quantity { get; set; }
    }
}
