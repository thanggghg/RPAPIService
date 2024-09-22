using Newtonsoft.Json;

namespace ProxyClient.Models.Responses.Tel4vn
{
    public class Tel4vnResponseAuthModel
    {
        [JsonProperty("data")]
        public Tel4vnResponseData Data { get; set; }
    }

    public class Tel4vnResponseData
    {
        [JsonProperty("client_id")]
        public Guid ClientId { get; set; }
        [JsonProperty("domain_id")]
        public Guid DomainId { get; set; }
        [JsonProperty("domain_name")]
        public string DomainName { get; set; }
        [JsonProperty("expired_in")]
        public int ExpiredIn { get; set; }
        [JsonProperty("level")]
        public string Level { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("user_id")]
        public Guid UserId { get; set; }
    }

    public class Tel4vnBodyMessage
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        [JsonProperty("route_rule")]
        public List<string> RouterRule { get; set; }
        [JsonProperty("list_param")]
        public Tel4vnParams ListParam { get; set; }
        [JsonProperty("template_code")]
        public string TemplateCode { get; set; }
        [JsonProperty("plugin")]
        public string Plugin { get; set; }
    }

    public class Tel4vnParams
    {
        [JsonProperty("otp", NullValueHandling = NullValueHandling.Ignore)]
        public string OTP { get; set; }
        [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }
        [JsonProperty("shopname", NullValueHandling = NullValueHandling.Ignore)]
        public string ShopName { get; set; }
    }

    public class Tel4vnRequest
    {
        public string PhoneNumber { get; set; }
        public string AccessToken { get; set; }
        public string TemplateCode { get; set; }
    }

    public class Tel4vnSendMessageResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
