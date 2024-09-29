using RP.Library.Enums;
using RP.Library.Utils;

namespace RP.Library.Extensions.JWT
{
    public class ResultJWTVerify
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
    public class HeaderJWT
    {
        public string Alg { get; set; }
    }
    public class PayloadJWT
    {
        public string Sub { get; set; }
        public string Auth { get; set; }
        public string DisplayName { get; set; }
        public long UserId { get; set; }
        public string LocationCode { get; set; }
        public string TimeZone { get; set; }
        public string LangKey { get; set; }
        public long StoreId { get; set; }
        public long AffiliateStoreId { get; set; }
        public List<string> Features { get; set; }
        public long NextExpiryPackageTime { get; set; }
        public bool PartnerEnabled { get; set; }
        public bool HasPartnerPackage { get; set; }
        public long Exp { get; set; }
        public UserStoreStatusEnum Status { get; set; }
        public long userAffiliateStoreId { get; set; }
        public bool CheckPermission(string permission)
        {
            var userAsGuest = new List<string> { AuthoritiesConstants.USER, AuthoritiesConstants.GUEST, AuthoritiesConstants.GUEST_CHECKOUT };

            if (this.Roles.Contains(AuthoritiesConstants.ADMIN))
            {
                return true;
            }
            else if (this.Roles.Contains(AuthoritiesConstants.USER) && userAsGuest.Contains(permission))
            {
                return true;
            }
            else if (this.Roles.Contains(AuthoritiesConstants.GUEST) && userAsGuest.Contains(permission))
            {
                return true;
            }
            else if (this.Roles.Contains(AuthoritiesConstants.GUEST_CHECKOUT) && userAsGuest.Contains(permission))
            {
                return true;
            }
            else if (permission == AuthoritiesConstants.DEFAULT)
            {
                return true;
            }
            return false;
        }
        public bool VerifyExpireDate()
        {
            DateTime currentTimeUtc = DateTime.UtcNow;
            DateTime expireDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(this.Exp);
            int comparisonResult = DateTime.Compare(currentTimeUtc, expireDate);
            return comparisonResult <= 0;
        }
        public string APIKey { get; set; }
        public List<string> Roles => String.IsNullOrEmpty(this.Auth) ? new List<string>() : this.Auth.Split(",").ToList();
    }
}
