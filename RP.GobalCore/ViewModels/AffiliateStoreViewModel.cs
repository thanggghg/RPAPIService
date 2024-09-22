namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class AffiliateStoreViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Website { get; set; }
        public bool AllowPublisherRegister { get; set; }
        public bool AutoApproved { get; set; }
        public int CookieDurationDay { get; set; }
        public string ApiKey { get; set; }
        public long BusinessId { get; set; }
        public long GoSellStoreId { get; set; }
        public bool AllowGetOrderTrackingUrl { get; set; }
        public bool AllowGetOrderTrackingCode { get; set; }
        public string KeyWordByUrl { get; set; }
        public string KeyWordByCode { get; set; }
        public bool IsDeleted { get; set; }
        public long? CurrencyId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string AffiliateStoreCurrencySymbol { get;set; }
    }

    public class AffiliateStoreByDomainViewModel
    {
        public long Id { get; set; }
        public string Logo { get; set; }
        public long GoSellStoreId { get; set; }
        public string Name { get; set; }
        public string AffiliateStoreCurrencySymbol { get; set; }
    }

    public class AffiliateKeyValueViewModel
    {
        public long Id { get; set; }
        public string Value { get; set; }
    }

    public class AffiliateStoreValidateViewModel
    {
        public long Id { get; set; }

        public long GoSellStoreId { get; set; }
    }
}
