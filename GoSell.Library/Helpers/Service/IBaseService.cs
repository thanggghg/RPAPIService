using GoSell.Library.Helpers.Service.Model;

namespace GoSell.Library.Helpers.Service
{
    public interface IBaseService
    {
        Task<AffililateStoreReponse> GetAffiliateStoreById(long affiliateStoreId);
        bool isValidAffiliateStore(long affiliateStoreId, long storeId);
        bool isInvalidAffiliateStore(long affiliateStoreId, long storeId);
        Task<List<PublisherBaseResponse>> GetPublisherFilter(long affiliateStoreId, List<long> publisherIds, List<string> publisherCodes, string publisherName, string publisherCode);
        Task<List<long>> FilterGetAffiliateStoreByIds(long storeId, string filterStatus);
    }
}
