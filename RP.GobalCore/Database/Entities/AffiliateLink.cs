using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GoSell.Library.Seedwork;

namespace GoSell.Affiliate.Tracking.Entities
{
    [Table("affiliate_link", Schema = "affiliate-tracking-services")]
    public class AffiliateLink : Entity, IAggregateRoot
    {
        [Required]
        [Column("tracking_id")]
        public Guid TrackingId { get; set; } = Guid.NewGuid();

        [Column("product_id")]
        public long? ProductId { get; set; }
        [Required]
        [Column("partner_id")]
        public long PartnerId { get; set; }

        [Column("campaign_id")]
        public long? CampaignId { get; set; }
        [Column("origin_link"), MaxLength(500)]
        public string OriginLink { get; set; }
        [Column("target_link"), MaxLength(500)]
        public string TargetLink { get; set; }
        [Column("sub_id_1"), MaxLength(255)]
        public string SubId1 { get; set; }
        [Column("sub_id_2"), MaxLength(255)]
        public string SubId2 { get; set; }
        [Column("sub_id_3"), MaxLength(255)]
        public string SubId3 { get; set; }
        [Column("sub_id_4"), MaxLength(255)]
        public string SubId4 { get; set; }
        [Column("sub_id_5"), MaxLength(255)]
        public string SubId5 { get; set; }
        public AffiliateProduct AffiliateProduct { get; set; }
        public AffiliateCampaign AffiliateCampaign { get; set; }
        public ICollection<AffiliateTrackingManagement> AffiliateTrackingManagements { get; set; }
    }
}
