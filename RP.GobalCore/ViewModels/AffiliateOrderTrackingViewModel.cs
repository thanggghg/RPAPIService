namespace GoSell.Affiliate.Tracking.ViewModels
{

    public class AffiliateOrderTrackingViewModel
    {
        public long Id { get; set; }
        public string OrderId { get; set; }
        public string Website { get; set; }
        public DateTime OrderCreateTime { get; set; }
    }
}
