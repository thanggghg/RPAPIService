using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RP.Library.Seedwork;
using Newtonsoft.Json;

namespace RP.Affiliate.Tracking.Entities
{
    [Table("affiliate_click_tracking", Schema = "affiliate-tracking-services")]
    public class AffiliateClickTracking : Entity, IAggregateRoot
    {
        [Required]
        [Column("click_id"), MaxLength(50)]
        public string ClickId { get; set; }
        [Required]
        [Column("tracking_id")]
        public Guid TrackingId { get; set; } = Guid.NewGuid();
        [Required]
        [Column("group_id"), MaxLength(50)]
        public string GroupId { get; set; }
        [Column("platform")]
        public string PlatForm { get; set; }
        [Column("device"), MaxLength(50)]
        public string Device { get; set; }
    }
}
