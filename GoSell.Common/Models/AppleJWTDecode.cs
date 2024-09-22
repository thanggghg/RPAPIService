using System.Text.Json.Serialization;

namespace GoSell.Common.Models
{
    public class AppleJWTDecode
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("email_verified")]
        public bool EmailVerified { get; set; }

        [JsonPropertyName("is_private_email")]
        public bool IsPrivateEmail { get; set; }

        [JsonPropertyName("sub")]
        public string Sub { get; set; }
    }
}
