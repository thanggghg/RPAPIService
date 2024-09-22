using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoSell.Affiliate.Tracking.Database.Entities
{
    [Table("affiliate_business", Schema = "affiliate-tracking-services")]
    public class AffiliateBusiness
    {
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("language_key")]
        public string LanguageKey { get; set; }
        [Required]
        [Column("cover_image_path")]
        public string CoverImagePath { get; set; }
        [Required]
        [Column("thumbnail_image_path")]
        public string ThumbnailImagePath { get; set; }
        [Required]
        [Column("order_number")]
        public int Priority { get; set; }
        public ICollection<AffiliateStore> AffiliateStores { get; set; }
    }
}
