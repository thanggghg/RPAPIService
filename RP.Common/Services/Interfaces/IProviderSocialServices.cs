using GoSell.Library.Enums.SocialAuthen;
using GoSell.Common.Models;

namespace GoSell.Common.Services.Interfaces
{
    public interface IProviderSocialServices
    {
        Task<SocialAuthInfo> ProcessAsync(AccountType providerId, string domain, SocialAuthRequest request, string platform);
    }
}
