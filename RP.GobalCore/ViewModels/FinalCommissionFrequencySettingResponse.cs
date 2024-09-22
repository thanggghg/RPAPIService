using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Entities;

namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class FinalCommissionFrequencySettingResponse
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CutOffDate { get; set; }
    }
}
