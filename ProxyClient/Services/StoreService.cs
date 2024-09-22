using GoSell.Library.Helpers;
using GoSell.Library.Utils;
using ProxyClient.Constants.Uri;
using ProxyClient.Helpers;
using ProxyClient.Models.Responses.Store;

namespace ProxyClient.Services
{
    public interface IStoreService
    {
        Task<UserStoreModel> GetStoreByOwnerId(string baseUrl, long userId, string token);
        Task<UserStoreModel> GetStoreByOwnerId(string baseUrl, long userId);
        Task<StoreModel> GetStoreByStoreId(string baseUrl, long storeId, string token);
        Task<StoreModel> GetStoreByStoreId(string baseUrl, long storeId);
        Task<List<StaffBranchModel>> GetAllStaffBranches(string baseUrl);
        Task<List<StoreStaffModel>> FindStoreStaff(string baseUrl, long storeId, bool isActive = true);
    }

    public class StoreService : IStoreService
    {
        private readonly IHttpClientFactoryHelper _httpClientFactoryHelper;

        private readonly IHttpClientHelper _httpClientHelper;
        public StoreService(IHttpClientFactoryHelper httpClientFactoryHelper, IHttpClientHelper httpClientHelper)
        {
            _httpClientFactoryHelper = httpClientFactoryHelper;
            _httpClientHelper = httpClientHelper;
        }

        /// <summary>
        ///  Call to Java store service to get store by ownerId
        /// </summary>
        /// <param name="token"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserStoreModel> GetStoreByOwnerId(string baseUrl, long userId, string token)
        {
            var uri = new Uri($"{baseUrl}/storeservice/api/stores/user/{userId}");
            return await _httpClientFactoryHelper.SendGetAsync<UserStoreModel>(nameof(GetStoreByOwnerId), uri, token);
        }

        /// <summary>
        ///  Call to Java store service to get store by ownerId
        /// </summary>
        /// <param name="token"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserStoreModel> GetStoreByOwnerId(string baseUrl, long userId)
        {
            return await _httpClientHelper.SendServiceApiGetAsync<UserStoreModel>(baseUrl, string.Format(StoreEndpointConstants.GET_STORE_BY_OWNER, userId), ApiNameConstants.SUPPORT_SERVICE);
        }

        /// <summary>
        ///  Call to Java store service to get store by Id
        /// </summary>
        /// <param name="token"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<StoreModel> GetStoreByStoreId(string baseUrl, long storeId, string token)
        {
            var uri = new Uri($"{baseUrl}/storeservice/api/stores/{storeId}");
            return await _httpClientFactoryHelper.SendGetAsync<StoreModel>(nameof(GetStoreByStoreId), uri, token);
        }

        /// <summary>
        /// Call to Java store service to get store by Id 
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public async Task<StoreModel> GetStoreByStoreId(string baseUrl, long storeId)
        {
            return await _httpClientHelper.SendServiceApiGetAsync<StoreModel>(baseUrl, string.Format(StoreEndpointConstants.GET_STORE_BY_ID, storeId), ApiNameConstants.SUPPORT_SERVICE);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        public async Task<List<StaffBranchModel>> GetAllStaffBranches(string baseUrl)
        {
            return await _httpClientHelper.SendServiceApiGetAsync<List<StaffBranchModel>>(baseUrl, string.Format(StoreEndpointConstants.GET_ALL_STAFF_BRANCHES, 1, 1000), ApiNameConstants.SUPPORT_SERVICE);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        public async Task<List<StoreStaffModel>> FindStoreStaff(string baseUrl, long storeId, bool isActive = true)
        {
            return await _httpClientHelper.SendServiceApiGetAsync<List<StoreStaffModel>>(baseUrl, string.Format(StoreEndpointConstants.FIND_STORE_STAFF, storeId, isActive), ApiNameConstants.SUPPORT_SERVICE);
        }
    }
}
