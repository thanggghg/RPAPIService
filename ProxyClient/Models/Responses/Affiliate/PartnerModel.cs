using Newtonsoft.Json;

namespace ProxyClient.Models.Responses.Affiliate
{
    public class PartnerModel
    {

        [JsonProperty("partner")]
        public PartnerDetail Partner { get; set; }

        [JsonProperty("hasPackagePlan")]
        public bool HasPackagePlan { get; set; }

        [JsonProperty("enabledReseller")]
        public bool EnabledReseller { get; set; }

        [JsonProperty("storeName")]
        public string StoreName { get; set; }
    }

    public class PartnerDetail
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("storeId")]
        public long StoreId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("plainPassword")]
        public string PlainPassword { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("wardCode")]
        public string WardCode { get; set; }

        [JsonProperty("districtCode")]
        public string DistrictCode { get; set; }

        [JsonProperty("CityCode")]
        public string cityCode { get; set; }

        [JsonProperty("allowUpdatePrice")]
        public bool AllowUpdatePrice { get; set; }

        [JsonProperty("partnerCode")]
        public string PartnerCode { get; set; }

        [JsonProperty("partnerType")]
        public PartnerType PartnerType { get; set; }

        [JsonProperty("paymentId")]
        public long PaymentId { get; set; }

        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("resellerStoreId")]
        public long ResellerStoreId { get; set; }

        [JsonProperty("partnerStatus")]
        public PartnerStatus PartnerStatus { get; set; }

        [JsonProperty("totalRevenue")]
        public double TotalRevenue { get; set; }
    }

    public enum PartnerType
    {
        RESELLER,
        DROP_SHIP
    }

    public enum PartnerStatus
    {
        REJECTED,
        PENDING,
        DEACTIVATED,
        ACTIVATED
    }
}
