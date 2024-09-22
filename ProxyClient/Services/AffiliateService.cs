using Newtonsoft.Json;
using ProxyClient.Helpers;
using ProxyClient.Models.Responses.Affiliate;
using ProxyClient.Models.Responses.Tel4vn;

namespace ProxyClient.Services
{
    public interface IAffiliateService
    {
        Task<PartnerModel> FindPartnerReseller(string baseUrl, long storeId, long userId, string token);
        Task<Tel4vnResponseAuthModel> GetAccessTokenTel4vnAsync();
        Task<Tel4vnSendMessageResponse> SendOTPToPhoneNumber(Tel4vnRequest request, Tel4vnParams tel4VnParams);
        Task<PackageAffiliateInfoModel> GetLastOrderOfStoreAffiliate(string baseUrl, long storeId, string serviceType, string token);
    }

    public class AffiliateService : IAffiliateService
    {
        //private readonly string BaseUrl = "https://dev-api.mediastep.com/affiliateservice/{0}";
        private readonly IHttpClientFactoryHelper _httpClientFactoryHelper;
        private readonly Tel4vnConfigurations _tel4vnConfigurations;

        public AffiliateService(IHttpClientFactoryHelper httpClientFactoryHelper, Tel4vnConfigurations tel4vnConfigurations)
        {
            _httpClientFactoryHelper = httpClientFactoryHelper;
            _tel4vnConfigurations = tel4vnConfigurations;
        }

        /// <summary>
        ///  Call to Java affiliateservice service to get partner
        /// </summary>
        /// <param name="token"></param>
        /// <param name="storeId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<PartnerModel> FindPartnerReseller(string baseUrl, long storeId, long userId, string token)
        {
            var uri = new Uri($"{baseUrl}/affiliateservice/api/partners/{storeId}/user/{userId}");
            return await _httpClientFactoryHelper.SendGetAsync<PartnerModel>(nameof(FindPartnerReseller), uri, token);
        }

        public async Task<Tel4vnResponseAuthModel> GetAccessTokenTel4vnAsync()
        {
            var url = $"{_tel4vnConfigurations.BaseUrl}/auth/token";
            var body = new
            {
                api_key = _tel4vnConfigurations.APIKey
            };
            var rawBody = JsonConvert.SerializeObject(body);
            return await _httpClientFactoryHelper.PostRawAsync<Tel4vnResponseAuthModel>(nameof(GetAccessTokenTel4vnAsync), url, rawBody, string.Empty);
        }

        public async Task<Tel4vnSendMessageResponse> SendOTPToPhoneNumber(Tel4vnRequest request, Tel4vnParams tel4VnParams)
        {
            var url = $"{_tel4vnConfigurations.BaseUrl}/crm-hook/inbox-marketing";
            var body = new Tel4vnBodyMessage
            {
                Username = _tel4vnConfigurations.Username,
                Password = _tel4vnConfigurations.Password,
                PhoneNumber = request.PhoneNumber,
                RouterRule = _tel4vnConfigurations.RouterRule.Split(',').ToList(),
                ListParam = tel4VnParams,
                TemplateCode = request.TemplateCode,
                Plugin = _tel4vnConfigurations.Plugin
            };
            var rawBody = JsonConvert.SerializeObject(body);
            return await _httpClientFactoryHelper.PostRawAsync<Tel4vnSendMessageResponse>(nameof(GetAccessTokenTel4vnAsync), url, rawBody, request.AccessToken);
        }

        public async Task<PackageAffiliateInfoModel> GetLastOrderOfStoreAffiliate(string baseUrl, long storeId, string serviceType, string jwtToken)
        {
            var uri = new Uri($"{baseUrl}/affiliateservice/api/order-packages/get-last-package/{storeId}?serviceType={serviceType}");
            return await _httpClientFactoryHelper.SendGetAsync<PackageAffiliateInfoModel>(nameof(GetLastOrderOfStoreAffiliate), uri, jwtToken);
        }
    }
}
