using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GoSell.Library.Seedwork;

namespace GoSell.Affiliate.Tracking.Database.Entities
{
    [Table("affiliate_store_currency", Schema = "affiliate-tracking-services")]
    public class AffiliateStoreCurrency: Entity, IAggregateRoot
    {
        [Required]
        [Column("name"), MaxLength(500)]
        public string Name { get; set; }
        [Required]
        [Column("code"), MaxLength(500)]
        public string Code { get; set; }
        [Required]
        [Column("symbol"), MaxLength(500)]
        public string Symbol { get; set; }
        [Column("is_default")]
        public bool IsDefault { get; set; }
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
        public ICollection<AffiliateStore> AffiliateStores { get; set; }
    }
}
