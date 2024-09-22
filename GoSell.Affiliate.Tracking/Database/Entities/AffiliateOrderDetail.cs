using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GoSell.Library.Seedwork;

namespace GoSell.Affiliate.Tracking.Entities
{
    [Table("affiliate_order_detail", Schema = "affiliate-tracking-services")]
    public class AffiliateOrderDetail : Entity, IAggregateRoot
    {
        [Column("category_id")]
        public string CategoryId { get; set; }

        [Column("sku")]
        public string Sku { get; set; }

        [Required]
        [Column("product_id"), MaxLength(50)]
        public string ProductId { get; set; }

        [Column("submission_id")]
        public long SubmissionId { get; set; }

        [Column("item_name")]
        public string ItemName { get; set; }

        [Column("sale_price")]
        public decimal SalePrice { get; set; }
        [Column("price")]
        public decimal Price { get; set; }

        [Column("total_price")]
        public decimal TotalPrice { get; set; }

        [Column("quantity")]
        public long Quantity { get; set; } = 1;

        [Column("is_deleted")]
        public bool IsDeleted { get; set; }


        public AffiliateSubmission AffiliateSubmission { get; set; }
    }
}
