using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoSell.Library.Seedwork
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            CreatedDate = DateTime.UtcNow;
        }
        [Column("id")]
        [Key]
        public virtual long Id { get; set; }

        [Column("created_by")]
        [MaxLength(150)]
        public virtual string CreatedBy { get; set; }

        [Column("created_date")]
        public virtual DateTimeOffset CreatedDate { get; set; }

        [Column("last_modified_by")]
        [MaxLength(150)]
        public virtual string LastModifiedBy { get; set; }

        [Column("last_modified_date")]
        public virtual DateTimeOffset? LastModifiedDate { get; set; }
    }
}
