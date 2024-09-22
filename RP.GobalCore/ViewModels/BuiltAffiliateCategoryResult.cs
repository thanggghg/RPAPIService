using GoSell.Affiliate.Tracking.Database.Entities;

namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class BuiltAffiliateCategoryResult
    {
        public List<AffiliateCategory> SucceededCategory { get; set; }
        public List<int> IndexRowsSucceeded { get; set; }
        public List<int> IndexRowsFailed { get; set; }
        public Dictionary<int, string> ErrorData { get; set; }

        public BuiltAffiliateCategoryResult()
        {
            this.SucceededCategory = [];
            this.IndexRowsSucceeded = [];
            this.IndexRowsFailed = [];
            this.ErrorData = [];
        }
    } 
}
