namespace GoSell.Affiliate.Tracking.Models.Requests
{
    public class CreateThemeRequest
    {
        public long StoreId { get; set; }
        public long ColorId { get; set; }
        public string Logo { get; set; }
        public string CoverImage { get; set; }
        public bool IsPublished { get; set; } = false;
        public long BusinessId { get; set; }
    }
    public class UpdateThemeRequest : CreateThemeRequest
    {
        public long Id { get; set; }
    }
    public class DeleteThemeRequest
    {
        public long Id { get; set; }
    }
    public class PublishThemeRequest
    {
        public long Id { get; set; }
    }
}
