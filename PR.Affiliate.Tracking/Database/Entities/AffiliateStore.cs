using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Library.Seedwork;

namespace GoSell.Affiliate.Tracking.Database.Entities
{
    [Table("affiliate_store", Schema = "affiliate-tracking-services")]
    public class AffiliateStore : Entity, IAggregateRoot
    {
        public AffiliateStore() { }
        [Required]
        [Column("gosell_store_id")]
        public long GoSellStoreId { get; set; }
        [Required]
        [Column("name"), MaxLength(500)]
        public string Name { get; set; }
        [Required]
        [Column("logo"), MaxLength(500)]
        public string Logo { get; set; }
        [Required]
        [Column("website"), MaxLength(500)]
        public string Website { get; set; }
        [Column("allow_publisher_register")]
        public bool AllowPublisherRegister { get; set; }
        [Column("auto_approved")]
        public bool AutoApproved { get; set; }
        [Column("cookie_duration_day")]
        public int CookieDurationDay { get; set; }
        [Column("api_key"), MaxLength(50)]
        public string ApiKey { get; set; }
        [Column("auto_approved_date")]
        public DateTime? AutoApprovedDate { get; set; }
        [Required]
        [Column("business_id")]
        public long BusinessId { get; set; }
        [Column("allow_get_order_tracking")]
        public bool? AllowGetOrderTracking { get; set; }
        [Column("allow_get_order_tracking_url")]
        public bool? AllowGetOrderTrackingUrl { get; set; }
        [Column("allow_get_order_tracking_code")]
        public bool? AllowGetOrderTrackingCode { get; set; }
        [Column("key_word_by_url"), MaxLength(50)]
        public string KeyWordByUrl { get; set; }
        [Column("key_word_by_code"), MaxLength(50)]
        public string KeyWordByCode { get; set; }
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
        [Column("affiliate_store_currency_id")]
        public long? AffiliateStoreCurrencyId { get; set; }
        public AffiliateStoreCurrency AffiliateStoreCurrency { get; set; }
        public AffiliateBusiness AffiliateBusiness { get; set; }
        public ICollection<AffiliateCampaign> AffiliateCampaigns { get; set; }
        public ICollection<AffiliateProduct> AffiliateProducts { get; set; }
        public ICollection<AffiliateTheme> AffiliateThemes { get; set; }
        public ICollection<AffiliateMapping> AffiliateMappings { get; set; }
    }
}
