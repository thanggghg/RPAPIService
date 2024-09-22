using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Entities;

namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class AffiliateCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string RefCategoryId { get; set; }

        public bool Status { get; set; }

        public bool IsDeleted { get; set; }
        public long AffiliateStoreId { get; set; }
        public AffiliateStore AffiliateStore { get; set; }
        public ICollection<AffiliateProduct> AffiliateProducts { get; set; }
    }
}
