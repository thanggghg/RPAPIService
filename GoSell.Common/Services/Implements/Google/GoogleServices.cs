using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Oauth2.v2;
using Google.Apis.Services;
using GoSell.Library.Enums.SocialAuthen;
using GoSell.Library.Extensions.Social;
using MediatR;
using Microsoft.Extensions.Logging;
using GoSell.Common.Services.Interfaces;
using GoSell.Common.Models;

namespace GoSell.Common.Services.Implements
{
    public class GoogleServices : IProviderSocialServices
    {
        private readonly IMediator _mediator;
        private readonly ILogger<GoogleServices> _logger;
        private readonly GoogleSocialSettings _googleSocialSettings;
        public GoogleServices(IMediator mediator, ILogger<GoogleServices> logger, GoogleSocialSettings googleSocialSettings)
        {
            _mediator = mediator;
            _logger = logger;
            _googleSocialSettings = googleSocialSettings;
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
                Console.WriteLine($"Signin Google Data: {request} - ${platform}");
                if (platform.Equals(DomainType.ANDROID.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    return await ValidateForAndroidAsync(request, providerId, domain, platform);
                }

                var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = new ClientSecrets { ClientId = _googleSocialSettings.ClientId, ClientSecret = _googleSocialSettings.ClientSecret },
                    Scopes = _googleSocialSettings.Scopes
                });

                var tokenResponse = new TokenResponse
                {
                    AccessToken = request.Authorization.Id_Token,
                    ExpiresInSeconds = 3600,
                    IssuedUtc = DateTime.UtcNow,
                };

                var credential = new UserCredential(flow, "user", tokenResponse);
                var oauthService = new Oauth2Service(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = _googleSocialSettings.ApplicationName
                });

                var userInfo = await oauthService.Userinfo.Get().ExecuteAsync();

                return new SocialAuthInfo
                {
                    DisplayName = userInfo.Name,
                    Email = userInfo.Email,
                    LastName = userInfo.FamilyName,
                    FirstName = userInfo.GivenName,
                    Picture = userInfo.Picture,
                    ProviderId = providerId,
                    LocationCode = userInfo.Locale,
                    LangKey = request.LangKey,
                    ProviderUserId = userInfo.Id,
                    Domain = domain,
                    Platform = platform,
                    AccessToken = request.Authorization.Id_Token,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception GoogleServices - ProcessAsync - {@IntegrationEvent}", ex.Message);
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<SocialAuthInfo> ValidateForAndroidAsync(SocialAuthRequest request, AccountType providerId, string domain, string platform)
        {
            var validationSettings = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new[] { _googleSocialSettings.ClientId }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(request.Authorization.Id_Token, validationSettings);

            if (payload == null)
                return null;

            return new SocialAuthInfo
            {
                DisplayName = payload.Name,
                Email = payload.Email,
                LastName = payload.FamilyName,
                FirstName = payload.GivenName,
                Picture = payload.Picture,
                ProviderId = providerId,
                LocationCode = payload.Locale,
                LangKey = request.LangKey,
                ProviderUserId = payload.Subject,
                Domain = domain,
                Platform = platform,
                AccessToken = "Android env: Invalid token"
            };
        }
    }
}
