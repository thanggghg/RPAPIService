using System.ComponentModel.DataAnnotations.Schema;

namespace RP.Library.Seedwork
{
    public interface IDeletedEntity
    {
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
    }
}
