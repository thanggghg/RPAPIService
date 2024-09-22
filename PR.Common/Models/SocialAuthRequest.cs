namespace GoSell.Common.Models
{
    public class SocialAuthRequest
    {
        public Authorization Authorization { get; set; }
        public UserModel User { get; set; }
        public string LangKey { get; set; }
        public long AffiliateStoreId { get; set; }
        public SocialAuthRequest() { }
    }

    public class Authorization
    {
        public string Code { get; set; }
        public string Id_Token { get; set; }
        public string State { get; set; }
    }

    public class UserModel
    {
        public UserInfo Name { get; set; }
        public string Email { get; set; }
    }

    public class UserInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
