using RP.Library.Enums.SocialAuthen;
using RP.Common.Models;

namespace RP.Common.Services.Interfaces
{
    public interface IProviderSocialServices
    {
        Task<SocialAuthInfo> ProcessAsync(AccountType providerId, string domain, SocialAuthRequest request, string platform);
    }
}
