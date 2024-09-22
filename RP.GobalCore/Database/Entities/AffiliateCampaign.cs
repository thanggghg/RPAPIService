using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RP.Affiliate.Tracking.Database.Entities;
using RP.Library.Seedwork;

namespace RP.Affiliate.Tracking.Entities
{
    [Table("affiliate_campaign", Schema = "affiliate-tracking-services")]
    public class AffiliateCampaign : Entity, IAggregateRoot
    {
        [Column("campaign_name"), MaxLength(255)]
        public string Name { get; set; }

        [Column("start_date", TypeName = "timestamp without time zone")]
        public DateTime StartDate { get; set; }

        [Column("end_date", TypeName = "timestamp without time zone")]
        public DateTime EndDate { get; set; }

        [Column("terminated_by")]
        public string TerminatedBy { get; set; }
        
        [Column("terminated_date", TypeName = "timestamp without time zone")]
        public DateTime TerminatedDate { get; set; }

        [Column("note")]
        public string Note { get; set; }

        [Column("status")]
        public int Status { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        [Column("affiliate_store_id")]
        public long AffiliateStoreId { get; set; }

        public AffiliateStore AffiliateStore { get; set; }

        public ICollection<AffiliateLink> AffiliateLinks { get; set; }

        public ICollection<AffiliateCampaignProduct> AffiliateCampaignProducts { get; set; }
    }
}
