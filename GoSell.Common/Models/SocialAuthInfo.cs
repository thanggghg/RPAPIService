using GoSell.Library.Enums.SocialAuthen;

namespace GoSell.Common.Models
{
    public class SocialAuthInfo
    {
        public SocialAuthInfo() { }

        public long Id { get; set; }

        public string Domain { get; set; }

        public string LangKey { get; set; }

        public string LocationCode { get; set; }

        public string Login { get; set; }

        public List<string> Authorities { get; set; }

        public AccountType ProviderId { get; set; }

        public string ProviderUserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Picture { get; set; }
        public string Platform { get; set; }
    }
}
