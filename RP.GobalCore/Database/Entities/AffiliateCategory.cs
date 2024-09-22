using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Library.Seedwork;

namespace GoSell.Affiliate.Tracking.Database.Entities
{
    [Table("affiliate_category", Schema = "affiliate-tracking-services")]
    public class AffiliateCategory : Entity, IAggregateRoot
    {
        [Required]
        [Column("category_name"), MaxLength(500)]
        public string Name { get; set; }
        [Column("ref_category_id")]
        public string RefCategoryId { get; set; }
        [Column("status")]
        public bool Status { get; set; }
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
        [Column("affiliate_store_id")]
        public long AffiliateStoreId { get; set; }
        public AffiliateStore AffiliateStore { get; set; }
        public ICollection<AffiliateProduct> AffiliateProducts { get; set; }
    }
}
