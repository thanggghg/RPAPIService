using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GoSell.Library.Seedwork;
using Newtonsoft.Json;

namespace GoSell.Affiliate.Tracking.Entities
{
    [Table("affiliate_order_tracking", Schema = "affiliate-tracking-services")]
    public class AffiliateOrderTracking : Entity, IAggregateRoot
    {
        [Required]
        [Column("order_id")]
        public string OrderId { get; set; }
        [Required]
        [Column("tracking_ids")]
        public string TrackingIds { get; set; }
        [Required]
        [Column("website")]
        public string Website { get; set; }
        [Column("order_create_time")]
        public DateTime OrderCreateTime { get; set; }
        [Required]
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
    }
}
