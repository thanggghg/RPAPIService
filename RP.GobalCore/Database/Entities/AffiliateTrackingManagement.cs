using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RP.Library.Seedwork;

namespace RP.Affiliate.Tracking.Entities
{
    [Table("affiliate_tracking_management", Schema = "affiliate-tracking-services")]
    public class AffiliateTrackingManagement : Entity, IAggregateRoot
    {
        [Required]
        [Column("tracking_id")]
        public Guid TrackingId { get; set; } = Guid.NewGuid();
        [Required]
        [Column("group_id"), MaxLength(50)]
        public string GroupId { get; set; }

        [Column("product_id")]
        public long? ProductId { get; set; }
        [Required]
        [Column("partner_id")]
        public long PartnerId { get; set; }
        [Column("campaign_id")]
        public long? CampaignId { get; set; }
        [Required]
        [Column("total_clicks")]
        public long TotalClicks { get; set; }
        [Required]
        [Column("total_hits")]
        public long TotalHits { get; set; }
        public AffiliateLink AffiliateLink { get; set; }
        public AffiliateProduct AffiliateProduct { get; set; }
    }
}
