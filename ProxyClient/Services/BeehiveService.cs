using ProxyClient.Helpers;
using ProxyClient.Models.Responses.Beehive;
using ProxyClient.Models.Beehive;
using ProxyClient.Models.Requests.Beehive;
using Nest;
using Newtonsoft.Json;
using DocumentFormat.OpenXml.Wordprocessing;
using Serilog;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ProxyClient.Services
{
    public interface IBeehiveService
    {
        Task<List<PlanExpireTimeModel>> GetAllPlanAndExpiryTime(string baseUrl, long userId, string token, string langKey = "vi");
        Task<BundlePlanExpireTimeResponse> GetAllBundlePlanAndExpiryTime(string baseUrl, long userId, string token, string langKey = "vi");
        Task<MobileConfigModel> GetMobileConfigByStoreId(string baseUrl, long userId, string jwtToken);
        Task<List<ReturnOrderResponse>> GetReturnOrders(string baseUrl, long orderId, string jwtToken, string langKey = "en");
        Task<BeeHiveOrderResponse> GetBeeHiveOrder(string baseUrl, long orderId, string jwtToken, string langKey = "en");
        Task<List<BeeHiveUserOrderResponse>> GetBeeHiveUserOrders(string baseUrl, BeeHiveUserOrderRequest request, string jwtToken, string langKey = "en");
        Task<CustomerProfileResult> GetCustomerProfiles(string baseUrl, CustomerProfileRequest request, string jwtToken, string staffToken, string langKey = "en");
        Task<CustomerProfileDetailResult> GetCustomerProfile(string baseUrl, long storeId, long profileId, string jwtToken, string langKey = "en");
    }

    public class BeehiveService : IBeehiveService
    {
        //private readonly string BaseUrl = "https://dev-api.mediastep.com/beehiveservices/{0}";
        private readonly IHttpClientFactoryHelper _httpClientFactoryHelper;

        public BeehiveService(IHttpClientFactoryHelper httpClientFactoryHelper)
        {
            _httpClientFactoryHelper = httpClientFactoryHelper;
        }

        /// <summary>
        /// Call to Java beehiveservices service to Mobile Config
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="jwtToken"></param>
        /// <returns></returns>
        public async Task<MobileConfigModel> GetMobileConfigByStoreId(string baseUrl, long userId, string jwtToken)
        {
            var uri = new Uri($"{baseUrl}/beehiveservices/api/mobile-configs/shop/validation?shopId={userId}");

            return await _httpClientFactoryHelper.SendGetAsync<MobileConfigModel>(nameof(GetMobileConfigByStoreId), uri, jwtToken);
        }

        /// <summary>
        /// Call to Java beehiveservices service to get plan
        /// </summary>
        /// <param name="token"></param>
        /// <param name="userId"></param>
        /// <param name="langKey"></param>
        /// <returns></returns>
        public async Task<List<PlanExpireTimeModel>> GetAllPlanAndExpiryTime(string baseUrl, long userId, string token, string langKey = "vi")
        {
            var uri = new Uri($"{baseUrl}/beehiveservices/api/user-features/user-ids/{userId}");
            var parameters = new Dictionary<string, string>
            {
                { "langKey", langKey }
            };

            return await _httpClientFactoryHelper.SendGetAsync<List<PlanExpireTimeModel>>(nameof(GetAllPlanAndExpiryTime), uri, token, parameters: parameters);
        }

        /// <summary>
        /// Call to Java beehiveservices service to get plan
        /// </summary>
        /// <param name="token"></param>
        /// <param name="userId"></param>
        /// <param name="langKey"></param>
        /// <returns></returns>
        public async Task<BundlePlanExpireTimeResponse> GetAllBundlePlanAndExpiryTime(string baseUrl, long userId, string token, string langKey = "vi")
        {
            var uri = new Uri($"{baseUrl}/beehiveservices/api/bundle-user-features/user-ids/{userId}");
            var parameters = new Dictionary<string, string>
            {
                { "langKey", langKey }
            };

            return await _httpClientFactoryHelper.SendGetAsync<BundlePlanExpireTimeResponse>(nameof(GetAllBundlePlanAndExpiryTime), uri, token, parameters: parameters);
        }

        public async Task<List<ReturnOrderResponse>> GetReturnOrders(string baseUrl, long orderId, string jwtToken, string langKey = "en")
        {
            var uri = new Uri($"{baseUrl}/orderservices2/api/return-orders/find-by-bc-order/{orderId}");
            return await _httpClientFactoryHelper.SendGetAsync<List<ReturnOrderResponse>>(nameof(GetReturnOrders), uri, jwtToken, httpHeader: LangKey(langKey));
        }
        public async Task<BeeHiveOrderResponse> GetBeeHiveOrder(string baseUrl, long orderId, string jwtToken, string langKey = "en")
        {
            var uri = new Uri($"{baseUrl}/orderservice3/api/gs/order-details/ids/{orderId}");
            return await _httpClientFactoryHelper.SendGetAsync<BeeHiveOrderResponse>(nameof(GetBeeHiveOrder), uri, jwtToken, httpHeader: LangKey(langKey));
        }
        public async Task<List<BeeHiveUserOrderResponse>> GetBeeHiveUserOrders(string baseUrl, BeeHiveUserOrderRequest request, string jwtToken, string langKey = "en")
        {
            var uri = new Uri($"{baseUrl}/beehiveservices/api/bc-orders/orders/storeId/{request.StoreId}?page={request.Page}&size={request.Size}&userId={request.UserId}&customerId={request.CustomerId}");
            return await _httpClientFactoryHelper.SendGetAsync<List<BeeHiveUserOrderResponse>>(nameof(GetBeeHiveUserOrders), uri, jwtToken, httpHeader: LangKey(langKey));
        }
        public async Task<CustomerProfileResult> GetCustomerProfiles(string baseUrl, CustomerProfileRequest request, string jwtToken, string staffToken, string langKey = "en")
        {
            var uri = new Uri($"{baseUrl}/beehiveservices/api/customer-profiles/{request.StoreId}/v2?page={request.Page}&size={request.PageSize}&keyword={request.Keyword}&sort={request.Sort}&branchIds={request.BranchIds}&ignoreBranch={request.IgnoreBranch}&searchField={request.SearchField}&operationDebtAmount={request.OperationDebtAmount}&debtAmountValue={request.DebtAmountValue}&langKey={langKey}&onlyContact={request.OnlyContact}&sortType={request.SortType}");
            var response = await _httpClientFactoryHelper.SendGetAsync(nameof(GetCustomerProfiles), uri, jwtToken, httpHeader: HeaderKey(langKey, staffToken));
            var jsonString = await response.Content.ReadAsStringAsync();
            var total = 0;
            foreach (var responseHeader in response.Headers.ToList())
            {
                if (responseHeader.Key.ToLower() == "X-Total-Count".ToLower())
                {
                    if (responseHeader.Value is not null)
                    {
                        total = int.Parse(responseHeader.Value.FirstOrDefault());
                    }
                    break;
                }
            }
            if (!response.IsSuccessStatusCode)
            {
                Log.Logger.Error($"GetAsync - apiName: {nameof(GetCustomerProfiles)} - apiUrl: {uri} - statusCode: {response.StatusCode} - message: {jsonString}");
                return null;
            }
            var customerProfiles = JsonConvert.DeserializeObject<List<CustomerProfileModel>>(jsonString);
            return new CustomerProfileResult
            {
                Total = total,
                CustomerProfiles = customerProfiles
            };
        }
        public async Task<CustomerProfileDetailResult> GetCustomerProfile(string baseUrl, long storeId, long profileId, string jwtToken, string langKey = "en")
        {
            var uri = new Uri($"{baseUrl}/beehiveservices/api/customer-profiles/detail/{storeId}/{profileId}");
            var response = await _httpClientFactoryHelper.SendGetAsync(nameof(GetCustomerProfile), uri, jwtToken, httpHeader: LangKey(langKey));
            var jsonString = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                Log.Logger.Error($"GetAsync - apiName: {nameof(GetCustomerProfile)} - apiUrl: {uri} - statusCode: {response.StatusCode} - message: {jsonString}");
                return null;
            }
            var customerProfile = JsonConvert.DeserializeObject<CustomerProfileDetailModel>(jsonString);
            return new CustomerProfileDetailResult { CustomerProfileDetail = customerProfile };
        }

        #region private
        private List<KeyValuePair<string, string>> LangKey(string lang)
        {
            var keyValuePairs = new List<KeyValuePair<string, string>>();
            keyValuePairs.Add(new KeyValuePair<string, string>(nameof(LangKey), lang));
            return keyValuePairs;
        }

        private List<KeyValuePair<string, string>> HeaderKey(string lang, string staffpermissionsToken)
        {
            var keyValuePairs = new List<KeyValuePair<string, string>>();
            keyValuePairs.Add(new KeyValuePair<string, string>(nameof(LangKey), lang));
            if (!string.IsNullOrEmpty(staffpermissionsToken))
            {
                keyValuePairs.Add(new KeyValuePair<string, string>("staffpermissions-token", staffpermissionsToken));
            }
            return keyValuePairs;
        }
        #endregion
    }
}
