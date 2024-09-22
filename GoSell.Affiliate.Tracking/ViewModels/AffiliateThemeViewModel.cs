namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class AffiliateThemeViewModel
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public long ColorId { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public bool IsPublished { get; set; }
        public string CoverImage { get; set; }
        public string ThumbnailImage { get; set; }
        public string Logo { get; set; }
    }
}
