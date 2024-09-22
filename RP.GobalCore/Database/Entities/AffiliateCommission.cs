using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RP.Library.Seedwork;

namespace RP.Affiliate.Tracking.Entities
{
    [Table("affiliate_commission", Schema = "affiliate-tracking-services")]
    public class AffiliateCommission : Entity, IAggregateRoot
    {
        [Column("product_id")]
        public long ProductId { get; set; }
        [Column("product_name"), MaxLength(500)]
        public string ProductName { get; set; }
        [Column("commission_name"), MaxLength(255)]

        public string CommissionName { get; set; }

        [Column("partner_id")]
        public long PartnerId { get; set; }

        [Required]
        [Column("start_date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Column("end_date")]
        public DateTime EndDate { get; set; }
        [Column("type"), MaxLength(255)]
        public string Type { get; set; }
        [Column("discount_percentage")]
        public int DiscountPercentage { get; set; }
        [Column("discount_amount")]
        public decimal DiscountAmount { get; set; }
        [Column("currency"), MaxLength(50)]
        public string Currency { get; set; }
        public AffiliateProduct AffiliateProduct { get; set; }
    }
}
