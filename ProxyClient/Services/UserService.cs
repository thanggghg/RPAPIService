using GoSell.Library.Helpers;
using GoSell.Library.Utils;
using ProxyClient.Constants.Uri;
using ProxyClient.Helpers;
using ProxyClient.Models.Responses.Store;
using ProxyClient.Models.Responses.User;

namespace ProxyClient.Services
{
    public interface IUserService
    {
        Task<Dictionary<string, object>> GetAllBcUserSettingValues(string baseUrl, long userId, DateTime? fromDate, string jwtToken);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="userId">Format ex: 1040,1182 id is long and separated by commas</param>
        /// <returns></returns>
        Task<List<UserModel>> GetUserByIds(string baseUrl, string userIds);
    }

    public class UserService : IUserService
    {
        private readonly IHttpClientFactoryHelper _httpClientFactoryHelper;
        private readonly IHttpClientHelper _httpClientHelper;
        public UserService(IHttpClientFactoryHelper httpClientFactoryHelper, IHttpClientHelper httpClientHelper)
        {
            _httpClientFactoryHelper = httpClientFactoryHelper;
            _httpClientHelper = httpClientHelper;
        }

        /// <summary>
        ///  Call to Java user service to get user setting
        /// </summary>
        /// <param name="token"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, object>> GetAllBcUserSettingValues(string baseUrl, long userId, DateTime? fromDate, string jwtToken)
        {
            var uri = new Uri($"{baseUrl}/userservices/api/bc-user-setting-values/users/{userId}?fromDate={fromDate}");
            return await _httpClientFactoryHelper.SendGetAsync<Dictionary<string, object>>(nameof(GetAllBcUserSettingValues), uri, jwtToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        public async Task<List<UserModel>> GetUserByIds(string baseUrl, string userIds)
        {
            return await _httpClientHelper.SendServiceApiGetAsync<List<UserModel>>(baseUrl, string.Format(UserEndpointConstants.GET_USER_BY_IDs, userIds), ApiNameConstants.HISTORY_SERVICE);
        }
    }
}
