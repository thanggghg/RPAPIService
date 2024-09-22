using System.Security.Cryptography;
using System.Text.Json;
using RP.Common.Enums;
using RP.Library.Enums.SocialAuthen;
using RP.Library.Exceptions;
using RP.Library.Extensions.JWT;
using RP.Library.Extensions.Social;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using ProxyClient.Helpers;
using RP.Common.Services.Interfaces;
using RP.Common.Models;
using RP.Common.Constants;

namespace RP.Common.Services.Implements
{
    public class AppleServices : IProviderSocialServices
    {
        private readonly ILogger<AppleServices> _logger;
        private readonly IHttpClientFactoryHelper _httpClient;
        private readonly AppleSocialSettings _appleSocialSettings;
        private const int JWT_EXPIRED_TIME = 3; // expiry can be a maximum of 6 months - generate one per request or re-use until expiration

        public AppleServices(IHttpClientFactoryHelper httpClient, ILogger<AppleServices> logger, AppleSocialSettings appleSocialSettings)
        {
            _logger = logger;
            _httpClient = httpClient;
            _appleSocialSettings = appleSocialSettings;
        }

        public async Task<SocialAuthInfo> ProcessAsync(AccountType providerId, string domain, SocialAuthRequest request, string platform)
        {
            if (request == null || request.Authorization == null)
            {
                _logger.LogWarning("Invalid Authorization - Authorization is missing - {@IntegrationEvent}", request);
                throw new ArgumentException("Authorization is missing");
            }
            try
            {
                AppleJWTDecode jwtDecode = null;
                AppleAuthResponse authResponse = null;
                Authorization auth = request.Authorization;

                if (platform.Equals(DomainType.IOS.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    // platform = IOS
                    authResponse = new AppleAuthResponse { AccessToken = auth.Code };
                    jwtDecode = GetAppleJWTDecodeForIOS(auth.Id_Token);
                }
                else
                {
                    // platform = Web, Android
                    authResponse = await Authenticate(auth.Code, domain);
                    if (authResponse != null)
                    {
                        jwtDecode = DecodeJWT(authResponse);
                    }
                }

                if (jwtDecode == null)
                    return null;

                string sub = jwtDecode.Sub?[..^2];
                string firstName = request.User?.Name?.FirstName ?? "";
                string lastName = request.User?.Name?.LastName ?? "";
                string email = string.IsNullOrEmpty(jwtDecode.Email) ? request?.User?.Email : jwtDecode.Email;
                string displayName = string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName) ? "" : $"{firstName} {lastName}";

                return new SocialAuthInfo
                {
                    Domain = domain,
                    Platform = platform,
                    ProviderId = providerId,
                    ProviderUserId = sub,
                    FirstName = firstName,
                    LastName = lastName,
                    DisplayName = displayName,
                    Email = email,
                    AccessToken = authResponse.AccessToken,
                    RefreshToken = authResponse.RefreshToken,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception AppleServices - ProcessAsync - {@IntegrationEvent}", ex);
                return null;
            }
        }

        private async Task<AppleAuthResponse> Authenticate(string code, string domain)
        {
            try
            {
                if (String.IsNullOrEmpty(code))
                    return null;

                var clientSecret = AppleEncodeJwtToken(_appleSocialSettings);
                if (String.IsNullOrEmpty(clientSecret))
                    return null;

                var formData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("client_id", _appleSocialSettings.ClientId),
                    new KeyValuePair<string, string>("client_secret", clientSecret),
                    new KeyValuePair<string, string>("code", code),
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("redirect_uri", domain == SocialDomainUrlConstant.Affiliate ? _appleSocialSettings.AffiliateAppleRedirectUrl : _appleSocialSettings.AppleRedirectUrl)
                });

                return await _httpClient.PostAsync<AppleAuthResponse>(HttpClientScopeEnum.SOCIAL.ToString(), _appleSocialSettings.AppleAuthUrl, formData, setAccessToken: false);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception AppleServices - Authenticate - {@IntegrationEvent}", ex);
                return null;
            }
        }

        private AppleJWTDecode DecodeJWT(AppleAuthResponse model)
        {
            try
            {
                if (model == null) return null;

                AppleJWTDecode appleJWTDecode = null;
                var id_token = model?.IdToken;
                if (!string.IsNullOrEmpty(id_token))
                {
                    var jsonData = JwtVerifier.DecodeJwtPayload(id_token);
                    appleJWTDecode = JsonSerializer.Deserialize<AppleJWTDecode>(jsonData.Item2);
                }

                return appleJWTDecode;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception AppleServices - DecodeJWT - {@IntegrationEvent}", ex);
                return null;
            }
        }

        private static string AppleEncodeJwtToken(AppleSocialSettings appleSocialSettings)
        {
            if (appleSocialSettings != null)
            {
                try
                {
                    var iss = appleSocialSettings.TeamId;
                    var aud = appleSocialSettings.Audience;
                    int expiredDays = JWT_EXPIRED_TIME;
                    long timestampIat = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();
                    long timestampExp = ((DateTimeOffset)DateTime.UtcNow.AddDays(expiredDays)).ToUnixTimeSeconds();
                    var claims = new Dictionary<string, object>
                    {
                        { "iss", iss },
                        { "aud", aud },
                        { "sub", appleSocialSettings.ClientId },
                        { "iat", timestampIat },
                        { "exp", timestampExp }
                    };
                    var currentDate = DateTime.UtcNow;
                    var handler = new JsonWebTokenHandler();
                    var ecdsa = ECDsa.Create();
                    ecdsa?.ImportPkcs8PrivateKey(Convert.FromBase64String(appleSocialSettings.PrivateKey), out _);
                    return handler.CreateToken(new SecurityTokenDescriptor
                    {
                        Issuer = iss,
                        Audience = aud,
                        Claims = claims,
                        Expires = currentDate.AddDays(expiredDays),
                        IssuedAt = currentDate,
                        NotBefore = currentDate,
                        SigningCredentials = new SigningCredentials(new ECDsaSecurityKey(ecdsa), SecurityAlgorithms.EcdsaSha256)
                    });
                }
                catch (Exception ex)
                {
                    throw new JWTException($"Apple Encode Jwt Token failure", ex);
                }
            }
            return null;
        }

        public static AppleJWTDecode GetAppleJWTDecodeForIOS(string jwt)
        {
            AppleJWTDecode appleJWTDecode = new();

            string payload = jwt.Split('.')[1];
            byte[] jsonBytes = ParseBase64WithoutPadding(payload);
            Dictionary<string, object> keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            if (keyValuePairs.TryGetValue("sub", out object subValue) && subValue != null)
            {
                appleJWTDecode.Sub = subValue.ToString();
            }

            if (keyValuePairs.TryGetValue("email", out object emailValue) && emailValue != null)
            {
                appleJWTDecode.Email = emailValue.ToString();
            }

            return appleJWTDecode;
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
