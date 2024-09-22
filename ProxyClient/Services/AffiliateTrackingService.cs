using GoSell.Library.Helpers;
using ProxyClient.Helpers;
using ProxyClient.Models.Requests.AffiliateTrackings;
using ProxyClient.Models.Responses.Affiliate;
namespace ProxyClient.Services
{
    public interface IAffiliateTrackingService
    {
        Task<List<AffiliateStoreModel>> GetAllAffiliateStoreByGsStoreId(string baseUrl, long goSellStoreId, string accessToken);
        Task<bool> UpdateAutoApproveStore(string baseUrl, UpdateAutoApproveRequestModel request, string accessToken);
    }

    public class AffiliateTrackingService : IAffiliateTrackingService
    {
        private readonly IHttpClientFactoryHelper _httpClientFactoryHelper;
        private readonly string GETAWAY_API_DONET = "netservice";
        public AffiliateTrackingService(IHttpClientFactoryHelper httpClientFactoryHelper)
        {
            _httpClientFactoryHelper = httpClientFactoryHelper;
        }

        /// <summary>
        ///  Call to gosell affiliate tracking service to get all affiliate store
        /// </summary>
        /// <param name="goSellStoreId"></param>
        /// <returns></returns>
        public async Task<List<AffiliateStoreModel>> GetAllAffiliateStoreByGsStoreId(string baseUrl, long goSellStoreId, string accessToken)
        {
            var uri = new Uri($"{baseUrl}/{GETAWAY_API_DONET}/api/v1/affiliate/store/get-all-by-gs-store-id/{goSellStoreId}");
            var result = await _httpClientFactoryHelper.SendGetAsync<GenericResponse<List<AffiliateStoreModel>>>(nameof(GetAllAffiliateStoreByGsStoreId), uri, accessToken);
            return result.Data;
        }

        /// <summary>
        ///  Call to gosell affiliate tracking service to update auto approve of affiliate store
        /// </summary>
        /// <param name="goSellStoreId"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAutoApproveStore(string baseUrl, UpdateAutoApproveRequestModel request, string accessToken)
        {
            var uri = new Uri($"{baseUrl}/{GETAWAY_API_DONET}/api/v1/affiliate/store/update-auto-approve");

            var result = await _httpClientFactoryHelper.SendPostAsync<GenericResponse<bool>>(nameof(UpdateAutoApproveStore), uri, request, null, accessToken);
            return result.Data;
        }
    }
}
