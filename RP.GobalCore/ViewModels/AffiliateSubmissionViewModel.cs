namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class AffiliateSubmissionViewModel
    {
        public long Id { get; set; }
        public string ConversionId { get; set; }

        public string TrackingIds { get; set; }

        public string ClickId { get; set; }

        public long ExternalStoreId { get; set; }

        public string GroupId { get; set; }

        public string ReferId { get; set; }

        public int SubmissionType { get; set; }

        public DateTime OrderCreatedDate { get; set; }

        public decimal OrderValue { get; set; }

        public decimal OrderDiscount { get; set; }

        public int Status { get; set; }

        public string OrderId { get; set; }

        public string OrderCode { get; set; }

        public string StringCode { get; set; }

        public string PaymentMethod { get; set; }

        public string PaymentMethodName { get; set; }

        public string OrderSessionId { get; set; }

        public decimal SubTotalAmount { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal FeeAmount { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal ShippingFee { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal Cash { get; set; }

        public decimal Refunds { get; set; }
        public string AffiliateStoreName { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
