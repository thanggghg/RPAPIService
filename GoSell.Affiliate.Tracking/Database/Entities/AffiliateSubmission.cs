using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GoSell.Library.Seedwork;

namespace GoSell.Affiliate.Tracking.Entities
{
    [Table("affiliate_submission", Schema = "affiliate-tracking-services")]
    public class AffiliateSubmission : Entity, IAggregateRoot
    {
        [Column("conversion_id")]
        public string ConversionId { get; set; }

        [Column("tracking_ids")]
        public string TrackingIds { get; set; }

        [Column("click_id")]
        public string ClickId { get; set; }

        [Required]
        [Column("external_store_id")]
        public long ExternalStoreId { get; set; }
        [Column("group_id")]
        public string GroupId { get; set; }

        [Column("submission_type")]
        public int SubmissionType { get; set; }

        //Receive data from AFF client
        [Column("status")]
        public int Status { get; set; }

        [Column("partner_id")]
        public long? PartnerId { get; set; }

        [Required]
        [Column("order_id")]
        public string OrderId { get; set; }

        [Column("payment_method"), MaxLength(200)]
        public string PaymentMethod { get; set; }

        [Column("order_created_date", TypeName = "timestamp without time zone")]
        public DateTime OrderCreatedDate { get; set; }

        [Column("sub_total_amount")]
        public decimal SubTotalAmount { get; set; }

        [Column("discount_amount")]
        public decimal DiscountAmount { get; set; }

        [Column("fee_amount")]
        public decimal FeeAmount { get; set; }

        [Column("tax_amount")]
        public decimal TaxAmount { get; set; }

        [Column("shipping_fee")]
        public decimal ShippingFee { get; set; }

        [Column("total_amount")]
        public decimal TotalAmount { get; set; }
        [Column("customer_phone")]
        public string CustomerPhone { get; set; }
        [Column("customer_name")]
        public string CustomerName { get; set; }
        [Column("customer_address")]
        public string CustomerAddress { get; set; }

        [Required]
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        public ICollection<AffiliateOrderDetail> AffiliateOrderDetails { get; set; }
    }
}
