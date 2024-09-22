using RP.Common.Enums;
using RP.Common.Models;
using RP.Common.Services.Interfaces;
using RP.Library.Enums.SocialAuthen;
using RP.Library.Extensions.Social;
using Microsoft.Extensions.Logging;
using ProxyClient.Helpers;

namespace RP.Common.Services.Implements.Facebook;

public class FacebookService : IProviderSocialServices
{
    private readonly ILogger<FacebookService> _logger;
    private readonly FacebookConfiguration _facebookSocialSettings;
    private readonly IHttpClientFactoryHelper _httpClient;
    private readonly string profileEndpoint = "/me?fields=id,name,email,languages,location,picture,last_name,first_name";
    public FacebookService(
        IHttpClientFactoryHelper httpClient,
        ILogger<FacebookService> logger,
            FacebookConfiguration facebookSocialSettings)
    {
        _httpClient = httpClient;
        _logger = logger;
        _facebookSocialSettings = facebookSocialSettings;
    }

    public async Task<SocialAuthInfo> ProcessAsync(AccountType providerId, string domain, SocialAuthRequest request, string platform)
    {
        if (request == null || request.Authorization.Id_Token == null)
        {
            _logger.LogWarning("Invalid IntegrationEvent - Authorization is missing - {@IntegrationEvent}", request);
            throw new ArgumentException("Authorization is missing");
        }

        try
        {
            Console.WriteLine($"Signin Facebook Data: {request} - ${platform}");
            var userInfo = await GetUserInf(request.Authorization.Id_Token);

            return new SocialAuthInfo
            {
                DisplayName = userInfo.Name,
                Email = userInfo.Email,
                LastName = userInfo.Last_name,
                FirstName = userInfo.First_name,
                Picture = userInfo.Picture?.Data?.Url,
                ProviderId = providerId,
                LocationCode = userInfo.Location,
                LangKey = userInfo.Languages,
                ProviderUserId = userInfo.Id,
                Domain = domain,
                Platform = platform
            };
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception FacebookService - ProcessAsync - {@IntegrationEvent}", ex.Message);
            throw new Exception($"{ex.Message}");
        }
    }

    private async Task<FacebookAuthResponse> GetUserInf(string accessToken)
    {
        var url = $"{_facebookSocialSettings.BaseUrl}{profileEndpoint}";
        return await _httpClient.SendGetAsync<FacebookAuthResponse>(HttpClientScopeEnum.SOCIAL.ToString(), new Uri(url), accessToken);
    }
}
