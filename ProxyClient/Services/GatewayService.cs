using GoSell.Library.Db;
using GoSell.Library.Extensions.JWT;
using GoSell.Library.Helpers;
using GoSell.Library.Utils;
using Microsoft.Extensions.Configuration;
using ProxyClient.Helpers;
using ProxyClient.Models.Requests.Getaways;
using ProxyClient.Models.Responses.Getaway;

namespace ProxyClient.Services
{
    public interface IGatewayService
    {
        Task<UserReponseModel> CreateUserByPhoneNumberAsync(CreateUserRequestModel request);
        Task<OauthClientDetailReponseModel> GetOauthClientDetailByClientIdAsync(string clientId);
        Task<UserReponseModel> GetUserByIdAsync(long id);
        Task<UserReponseModel> GetUserByLoginAsync(string login);
        Task<List<UserReponseModel>> GetUserListByLoginsAsync(List<string> logins);
        Task<UserReponseModel> GetUserByPhoneNumberAsync(string countryCode, string phoneNumber);
    }

    public class GatewayService : IGatewayService
    {
        private readonly IHttpClientFactoryHelper _httpClientFactoryHelper;
        private readonly string GETAWAY_API_DONET = "netservice";
        private readonly IConfiguration _configuration;
        private string baseUrl = null;
        private readonly JwtOptions _jwtOptions;

        public GatewayService(IHttpClientFactoryHelper httpClientFactoryHelper,
            IConfiguration configuration,
            JwtOptions jwtOptions)
        {
            _httpClientFactoryHelper = httpClientFactoryHelper;
            _configuration = configuration;
            baseUrl = $"{_configuration.GetSectionValueWithEnvironment("ApiBaseUrl")}/{GETAWAY_API_DONET}";
            _jwtOptions = jwtOptions;

        }

        /// <summary>
        ///  create jhi_user, jhi_user_authority, user_domain
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UserReponseModel> CreateUserByPhoneNumberAsync(CreateUserRequestModel request)
        {
            var uri = new Uri($"{baseUrl}/api/v1/getaway/create-user-by-phone-number");
            var token = GetTokenAsync();

            var result = await _httpClientFactoryHelper.SendPostAsync<GenericResponse<UserReponseModel>>(nameof(CreateUserByPhoneNumberAsync), uri, request, httpHeader: null, token);
            return result?.Data;
        }

        /// <summary>
        ///  Get OauthClientDetail by clientId
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public async Task<OauthClientDetailReponseModel> GetOauthClientDetailByClientIdAsync(string clientId)
        {
            var uri = new Uri($"{baseUrl}/api/v1/getaway/get-oauth-client-detail/{clientId}");
            var token = GetTokenAsync();

            var result = await _httpClientFactoryHelper.SendGetAsync<GenericResponse<OauthClientDetailReponseModel>>(nameof(GetOauthClientDetailByClientIdAsync), uri, httpHeader: null, token);
            return result?.Data;
        }

        /// <summary>
        ///  Get User by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserReponseModel> GetUserByIdAsync(long id)
        {
            var uri = new Uri($"{baseUrl}/api/v1/getaway/get-user/{id}");
            var token = GetTokenAsync();

            var result = await _httpClientFactoryHelper.SendGetAsync<GenericResponse<UserReponseModel>>(nameof(GetUserByIdAsync), uri, httpHeader: null, token);
            return result?.Data;
        }

        /// <summary>
        ///  Get user by login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public async Task<UserReponseModel> GetUserByLoginAsync(string login)
        {
            var uri = new Uri($"{baseUrl}/api/v1/getaway/get-user-by-login/{login}");
            var token = GetTokenAsync();

            var result = await _httpClientFactoryHelper.SendGetAsync<GenericResponse<UserReponseModel>>(nameof(GetUserByIdAsync), uri, httpHeader: null, token);
            return result?.Data;
        }

        /// <summary>
        ///  Get user by phoneNumber
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public async Task<UserReponseModel> GetUserByPhoneNumberAsync(string countryCode, string phoneNumber)
        {
            var uri = new Uri($"{baseUrl}/api/v1/getaway/get-user-by-phone-number");
            var token = GetTokenAsync();
            var body = new
            {
                CountryCode = countryCode,
                PhoneNumber = phoneNumber
            };

            var result = await _httpClientFactoryHelper.SendPostAsync<GenericResponse<UserReponseModel>>(nameof(GetUserByIdAsync), uri, body, httpHeader: null, token);
            return result?.Data;
        }

        /// <summary>
        ///  Get user list by login list
        /// </summary>
        /// <param name="logins"></param>
        /// <returns></returns>
        public async Task<List<UserReponseModel>> GetUserListByLoginsAsync(List<string> logins)
        {
            var uri = new Uri($"{baseUrl}/api/v1/getaway/get-user-list-by-logins");
            var token = GetTokenAsync();

            var result = await _httpClientFactoryHelper.SendPostAsync<GenericResponse<List<UserReponseModel>>>(nameof(GetUserListByLoginsAsync), uri, logins, httpHeader: null, token);
            return result?.Data;
        }

        private string GetTokenAsync()
        {
            var jwtVerifier = new JwtVerifier(_jwtOptions);
            var token = jwtVerifier.BuildToken("system", AuthoritiesConstants.ADMIN);
            return token;
        }
    }
}
