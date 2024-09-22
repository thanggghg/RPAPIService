namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class AffiliateProductAddCampaignViewModel
    {
        public long Id { get; set; }

        public string RefProductId { get; set; }        

        public string Name { get; set; }

        public decimal RegularPrice { get; set; }

        public decimal? SalePrice { get; set; }

        public string ImageUrl { get; set; }
    }
}
