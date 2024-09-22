namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class ExportOrderSubmissionViewModel
    {
        public string OrderId { get; set; }

        public string ProductName { get; set; }

        public string ProductId { get; set; }

        public decimal? Price { get; set; }

        public decimal? SalePrice { get; set; }

        public long Quantity { get; set; }

        public decimal? TotalPrice { get; set; }

        public decimal Tax { get; set; }

        public decimal ShippingFee { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal SubTotalAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public string PaymentMethod { get; set; }

        public string OrdateDate { get; set; }

        public string ApprovalStatus { get; set; }

        public DateTime? LastModifiedDateSubmission { get; set; }
        public string PartnerPhone { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public string CustomerAddress { get; set; }
    }
}
