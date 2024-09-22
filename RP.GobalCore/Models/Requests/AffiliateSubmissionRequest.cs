namespace GoSell.Affiliate.Tracking.Models.Requests
{
    public class AffiliateSubmissionRequest
    {
        public string ConversionId { get; set; }
        public List<Guid> TrackingIds { get; set; }
        public string ClickId { get; set; }
        public string GroupId { get; set; }
        public int SubmissionType { get; set; }
        public string ApiKey { get; set; }
        public long OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime? OrderCreatedDate { get; set; }
        public decimal SubTotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FeeAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal ShippingFee { get; set; }
        public decimal TotalAmount { get; set; }
        public List<AffiliateOrderDetailRequest> OrderItems { get; set; }
    }

    public class AffiliateOrderDetailRequest
    {
        public string CategoryId { get; set; }
        public string Sku { get; set; }
        public string ProductId { get; set; }
        public string ItemName { get; set; }
        public decimal? Price { get; set; } = 0;
        public decimal? SalePrice { get; set; } = 0;
        public decimal? TotalPrice { get; set; } = 0;
        public long? Quantity { get; set; } = 0;
    }

}
