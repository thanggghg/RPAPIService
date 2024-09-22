namespace GoSell.Library.Extensions.Social
{
    public record class AppleSocialSettings
    {
        public string ClientId { get; set; }
        public string Audience { get; set; }
        public string TeamId { get; set; }
        public string KeyId { get; set; }
        public string PrivateKey { get; set; }
        public string AppleRedirectUrl { get; set; }
        public string AppleRedirectUrlBiz { get; set; }
        public string AffiliateAppleRedirectUrl { get; set; }
        public string AppleAuthUrl { get; set; }
    }
}
