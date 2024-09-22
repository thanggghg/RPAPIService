using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Entities;

namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class AffiliateCategoryPublicViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string RefCategoryId { get; set; }

        public bool Status { get; set; }

        public bool IsDeleted { get; set; }
        public long AffiliateStoreId { get; set; }
        public string AffiliateStoreName { get; set; }
    }
}
