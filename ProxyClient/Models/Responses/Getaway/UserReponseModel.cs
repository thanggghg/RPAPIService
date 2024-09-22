using GoSell.Library.Enums.SocialAuthen;

namespace ProxyClient.Models.Responses.Getaway
{
    public class UserReponseModel
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarUrl { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public bool Deleted { get; set; }
        public bool IsUsing { get; set; }
        public AccountType AccountType { get; set; }
        public List<UserAuthorityReponseModel> UserAuthorities { get; set; } = new List<UserAuthorityReponseModel>();
    }
}
