using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Entities;

namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class AffiliateMappingViewModel
    {
        public string MappingKey { get; set; }
        public int ColumnIndex { get; set; }
        public int RowIndex { get; set; }
        public string Label { get; set; }
        public long AffiliateStoreId { get; set; }

    }
}
