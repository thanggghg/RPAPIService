using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RP.Library.Seedwork;

namespace RP.Affiliate.Tracking.Database.Entities
{
    [Table("affiliate_theme", Schema = "affiliate-tracking-services")]
    public class AffiliateTheme : Entity, IAggregateRoot
    {
        public AffiliateTheme() { }

        [Column("store_id")]
        public long StoreId { get; set; }
        [Required]
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
        [Required]
        [Column("color_id"), MaxLength(255)]
        public long ColorId { get; set; }
        [Required]
        [Column("logo"), MaxLength(500)]
        public string Logo { get; set; }
        [Required]
        [Column("cover_image"), MaxLength(500)]
        public string CoverImage { get; set; }
        [Required]
        [Column("is_published")]
        public bool IsPublished { get; set; }
        public AffiliateStore AffiliateStore { get; set; }
        public AffiliateColorDefault AffiliateColorDefault { get; set; }
    }
}
