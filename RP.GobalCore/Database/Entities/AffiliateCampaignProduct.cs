using GoSell.Library.Seedwork;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoSell.Affiliate.Tracking.Entities
{
    [Table("affiliate_campaign_product", Schema = "affiliate-tracking-services")]
    public class AffiliateCampaignProduct : Entity, IAggregateRoot
    {
        [Column("affiliate_campaign_id")]
        public long AffiliateCampaignId { get; set; }

        [Column("affiliate_product_id")]
        public long AffiliateProductId { get; set; }

        [Column("commission_percent", TypeName = "numeric(20,2)")]
        public decimal CommissionPercent { get; set; }

        [Column("commission_fix", TypeName = "numeric(20,2)")]
        public decimal CommissionFix { get; set; }

        public AffiliateCampaign AffiliateCampaign { get; set; }
        public AffiliateProduct AffiliateProduct { get; set; }
    }
}
