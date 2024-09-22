using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Library.Seedwork;

namespace GoSell.Affiliate.Tracking.Database.Entities
{
    [Table("affiliate_mapping", Schema = "affiliate-tracking-services")]
    public class AffiliateMapping : Entity, IAggregateRoot
    {
        [Required]
        [Column("mapping_key")]
        public string MappingKey { get; set; }
        [Required]
        [Column("column_index")]
        public int ColumnIndex { get; set; }
        [Required]
        [Column("row_index")]
        public int RowIndex { get; set; }
        [Required]
        [Column("label")]
        public string Label { get; set; }
        [Required]
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
        [Required]
        [Column("affiliate_store_id")]
        public long AffiliateStoreId { get; set; }

        public AffiliateStore AffiliateStore { get; set; }
    }
}
