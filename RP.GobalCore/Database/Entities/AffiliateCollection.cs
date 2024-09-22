using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RP.Affiliate.Tracking.Entities;
using RP.Library.Seedwork;

namespace RP.Affiliate.Tracking.Database.Entities
{
    [Table("affiliate_collection", Schema = "affiliate-tracking-services")]
    public class AffiliateCollection : Entity, IAggregateRoot
    {
        [Required]
        [Column("category_name"), MaxLength(500)]
        public string Name { get; set; }

        [Required]
        [Column("enabled"), MaxLength(500)]
        public bool Enabled { get; set; }

        public ICollection<AffiliateProduct> AffiliateProducts { get; set; }

    }
}
