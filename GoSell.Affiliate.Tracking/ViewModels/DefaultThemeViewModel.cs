namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class DefaultThemeViewModel
    {
        public long ColorId { get; set; }
        public string BusinessKey { get; set; }
        public long BusinessId { get; set; }
        public AffiliateThemeViewModel Theme { get; set; }
    }
}
