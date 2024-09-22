using System.ComponentModel;
using GoSell.Common.Enums;

namespace GoSell.Common.Models
{
    public class BasePagination
    {
        [DefaultValue(0)]
        public int Page { get; set; }

        [DefaultValue(20)]
        public int Size { get; set; }

        [DefaultValue("CreatedDate")]
        public string SortColumnName { get; set; }

        [DefaultValue(SortDirection.DESC)]
        public SortDirection SortDirection { get; set; }
    }
}
