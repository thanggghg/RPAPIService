using RP.Library.Constants;
using RP.Library.Db;
using RP.Library.Helpers.Service.Model;
using RP.Library.Utils;
using Microsoft.Extensions.Configuration;

namespace RP.Library.Helpers.Service
{
    public class BaseService(IHttpClientHelper httpClientHelper
                          , IConfiguration configuration) : IBaseService
    {
        private readonly IHttpClientHelper _httpClientHelper = httpClientHelper;
        private readonly IConfiguration _configuration = configuration;

        public async Task<AffililateStoreReponse> GetAffiliateStoreById(long affiliateStoreId)
        {
            //var url = $"/api/v1/affiliate/store/by-id/{affiliateStoreId}";  // local
            var url = $"/netservice/api/v1/affiliate/store/by-id/{affiliateStoreId}";
            var response = await _httpClientHelper.SendServiceApiGetAsync<GenericResponse<AffililateStoreReponse>>(
                            _configuration.GetSectionValueWithEnvironment("ApiBaseUrl"),
                            url,
                            Utils.ApiNameConstants.AFFiLIAATE_TRACKING
                        );

            return response?.Data ?? null;
        }

        public bool isValidAffiliateStore(long affiliateStoreId, long storeId)
        {
            var affStore = GetAffiliateStoreById(affiliateStoreId).Result;
            return affStore?.GoSellStoreId == storeId;
        }

        public bool isInvalidAffiliateStore(long affiliateStoreId, long storeId)
        {
            var affStore = GetAffiliateStoreById(affiliateStoreId).Result;
            return affStore?.GoSellStoreId != storeId;
        }

        public async Task<List<PublisherBaseResponse>> GetPublisherFilter(long affiliateStoreId, List<long> publisherIds, List<string> publisherCodes, string publisherName, string publisherCode)
        {
            var input = new GetPublisherFilterRequest
            {
                AffiliateStoreId = affiliateStoreId,
                PublisherIds = publisherIds,
                PublisherCodes = publisherCodes,
                PublisherName = publisherName,
                PublisherCode = publisherCode
            };
            
            //var url = "/api/v1/affiliate/publishers/get-by-filter"; // local
            var url = "/netservice/api/v1/affiliate/publishers/get-by-filter";
            var response = await _httpClientHelper.SendServiceApiPostAsync<GetPublisherFilterRequest, GenericResponse<List<PublisherBaseResponse>>>(
                            _configuration.GetSectionValueWithEnvironment("ApiBaseUrl"),
                            url,
                            ApiNameConstants.PUBLISHER_SERVICE,
                            input
                        );

            return response?.Data ?? new List<PublisherBaseResponse>();
        }

        private async Task<List<long>> GetAffiliateStoreByIdForFilter(long storeId, bool? isDelete)
        {
            //var url = $"/api/v1/affiliate/store/by-gs-id";  // local
            var url = $"/netservice/api/v1/affiliate/store/by-gs-id";
            var response = await _httpClientHelper.SendServiceApiPostAsync<GetAllAffiliateStoreByGoSellIdRequest, GenericResponse<List<AffililateStoreReponse>>>(
                            _configuration.GetSectionValueWithEnvironment("ApiBaseUrl"),
                            url,
                            Utils.ApiNameConstants.AFFiLIAATE_TRACKING,
                            new GetAllAffiliateStoreByGoSellIdRequest
                            {
                                isDeleted = isDelete,
                                GoSellStoreId = storeId
                            }
                        );
            var result = response?.Data.Select(x => x.Id).ToList();
            return result;
        }

    }
}
