using ProxyClient.Models.Responses.Store;

namespace ProxyClient.Models.Responses.Beehive
{
    public class MobileConfigModel
    {
        public long Id { get; set; }
        public string ShopName { get; set; }
        public long ShopId { get; set; }
        public string ColorPrimary { get; set; }
        public string ColorSecondary { get; set; }
        public ImageModel ShopLogo { get; set; }
        public string BundleId { get; set; }
        public string FirebaseDatabaseUrl { get; set; }
        public string FirebaseAppIdAndroid { get; set; }
        public string FirebaseApiKeyAndroid { get; set; }
        public string FirebaseAppIdIos { get; set; }
        public string FirebaseApiKeyIos { get; set; }
        public string FirebaseSenderIdIos { get; set; }
        public string FirebaseClientIdIos { get; set; }
    }
}
