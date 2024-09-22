namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class ProductCateInfoVM
    {
        public long Id { get; set; }
        public string RefProductId { get; set; }

        public string ProductName { get; set; }

        public long? CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string RefCategoryId { get; set; }

        public bool? IsActive { get; set; }
    }
}
