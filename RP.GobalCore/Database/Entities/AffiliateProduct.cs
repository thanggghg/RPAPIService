using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RP.Affiliate.Tracking.Database.Entities;
using RP.Library.Seedwork;

namespace RP.Affiliate.Tracking.Entities
{
    [Table("affiliate_product", Schema = "affiliate-tracking-services")]
    public class AffiliateProduct : Entity, IAggregateRoot
    {
        [Required]
        [Column("product_name"), MaxLength(500)]
        public string Name { get; set; }
        [Column("ref_product_id")]
        public string RefProductId { get; set; }
        [Column("category_id"), MaxLength(255)]
        public long? CategoryId { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("product_url")]
        public string ProductUrl { get; set; }
        [Column("regular_price")]
        public decimal? RegularPrice { get; set; }
        [Column("sale_price")]
        public decimal? SalePrice { get; set; }
        [Required]
        [Column("is_outof_stock")]
        public bool IsOutOfStock { get; set; }
        [Required]
        [Column("is_stop_selling")]
        public bool IsStopSelling { get; set; }
        [Column("is_percentage")]
        public bool IsPercentage { get; set; }
        [Column("percentage")]
        public decimal? Percentage { get; set; }
        [Column("is_fixed_value")]
        public bool IsFixValue { get; set; }
        [Column("fixed_value")]
        public decimal? FixValue { get; set; }
        [Column("affiliate_store_id")]
        public long AffiliateStoreId { get; set; }
        [Column("is_deleted")]
        public bool? IsDeleted { get; set; } = false;
        [Column("image_url")]
        public string ImageUrl { get; set; }
        [Column("collection_id"), MaxLength(255)]
        public long? CollectionId { get; set; }
        public AffiliateCommission AffiliateCommission { get; set; }
        public AffiliateStore AffiliateStore { get; set; }
        public AffiliateCategory AffiliateCategory { get; set; }
        public AffiliateCollection AffiliateCollection { get; set; }
        public ICollection<AffiliateTrackingManagement> AffiliateTrackingManagements { get; set; }
        public ICollection<AffiliateLink> AffiliateLinks { get; set; }
        public ICollection<AffiliateCampaignProduct> AffiliateCampaignProducts { get; set; }
    }
}
