using GoSell.Affiliate.Tracking.Entities;

namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class BuildedAffiliateProductResult
    {
        public List<AffiliateProduct> SucceededAffiliateProducts { get; set; }
        public List<int> IndexRowsSucceeded { get; set; }
        public List<int> IndexRowsFailed { get; set; }
        public Dictionary<int, string> ErrorData { get; set; }

        public BuildedAffiliateProductResult()
        {
            this.SucceededAffiliateProducts = new List<AffiliateProduct>();
            this.IndexRowsSucceeded = new List<int>();
            this.IndexRowsFailed = new List<int>();
            this.ErrorData = new Dictionary<int, string>();
        }
    }
}
