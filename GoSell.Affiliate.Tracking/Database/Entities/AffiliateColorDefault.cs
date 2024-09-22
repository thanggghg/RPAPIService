using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoSell.Affiliate.Tracking.Database.Entities
{
    [Table("affiliate_color_default", Schema = "affiliate-tracking-services")]
    public class AffiliateColorDefault
    {
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("primary_color")]
        public string PrimaryColor { get; set; }
        [Required]
        [Column("secondary_color")]
        public string SecondaryColor { get; set; }
        [Required]
        [Column("order_number")]
        public int Priority { get; set; }
        [Column("business_id")]
        public long BusinessId { get; set; }
        public ICollection<AffiliateTheme> AffiliateThemes { get; set; }
    }
}
