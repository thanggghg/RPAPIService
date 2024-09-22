using Newtonsoft.Json;

namespace GoSell.Common.Models
{
    public class SocialAuthResponseBase
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }

    public class AppleAuthResponse : SocialAuthResponseBase
    {
        [JsonProperty("id_token")]
        public string IdToken { get; set; }
    }

    public class GoogleAuthResponse : SocialAuthResponseBase
    {
        [JsonProperty("scope")]
        public string Scope { get; set; }
    }

    public class FaceBookExchangeAuthorizationResponse : SocialAuthResponseBase { }
}
