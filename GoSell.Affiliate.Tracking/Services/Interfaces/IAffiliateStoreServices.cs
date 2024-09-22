using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.ViewModels;

namespace GoSell.Affiliate.Tracking.Services.Interfaces
{
    public interface IAffiliateStoreServices
    {
        Task<(bool, AffiliateStore)> CreateStoreAsync(AffiliateStore affiliateStore, CancellationToken cancellationToken);
        Task<bool> UpdateAffiliateStore(AffiliateStore affiliateStore, CancellationToken cancellationToken);
        Task<bool> UpdateRangeAffiliateStoreAsync(List<AffiliateStore> affiliateStores, CancellationToken cancellationToken);
        Task<bool> UpdateWebsiteOrIsDeletedOfExternalStoreAsync(UpdateWebsiteOrIsDeletedOfExternalStoreCommand request, CancellationToken cancellationToken);
        Task<List<AffiliateStore>> GetAllAffiliateStore(CancellationToken cancellationToken);
        Task<List<AffiliateStore>> GetAllAffiliateStoreByGsId(long goSellStoreId);
        Task<AffiliateStore> GetSpecificAffiliateStoreByDomain(string domain, CancellationToken cancellationToken);
        Task<AffiliateStore> GetSpecificAffiliateByStoreId(long storeId, CancellationToken cancellationToken = default);
        Task<AffiliateStore> GetSpecificAffiliateByGoSellStoreId(long goSellStoreId, CancellationToken cancellationToken = default);
        AffiliateStore GetStoreByApiKey(string apiKey);
        Task<List<AffiliateTheme>> GetAllAffiliateThemeByStoreId(long storeId, CancellationToken cancellationToken);
        Task<(AffiliateTheme, AffiliateBusiness)> GetAffiliateThemeByBusinessIdAsync(GetAffiliateThemeByBusinessIdQuery command, CancellationToken cancellationToken);
        Task<List<DefaultThemeViewModel>> GetThemesOfBusinessQueryAsync(long externalStoreId);
        Task<AffiliateTheme> GetAffiliateThemePublishedByStoreId(long storeId, CancellationToken cancellationToken);
        Task<string> CreateApiKey(long storeId, CancellationToken cancellationToken);
        Task<bool> CreateThemeByStoreAsync(CreateAffiliateStoreCommand request, AffiliateStore store, CancellationToken cancellationToken);
        Task<bool> CreateThemeAsync(AffiliateTheme affiliateTheme, CancellationToken cancellationToken);
        Task<bool> UpdateThemeAsync(AffiliateTheme affiliateTheme, CancellationToken cancellationToken);
        Task<bool> UpdateRangeThemeAsync(List<AffiliateTheme> affiliateThemes, CancellationToken cancellationToken);
        Task<List<AffiliateColorDefault>> GetAllAffiliateColorDefaultAsync(bool isBusinessColor, CancellationToken cancellationToken);
        Task<List<AffiliateBusiness>> GetAllAffiliateBusinessAsync();
        Task<AffiliateTheme> GetAffiliateThemeById(long id, CancellationToken cancellationToken);
        Task<bool> PublishThemeAsync(AffiliateTheme affiliateTheme, CancellationToken cancellationToken);
        Task<AffiliateStore> GetAffiliateStoreById(long id, CancellationToken cancellationToken);
        Task<List<AffiliateStore>> GetAllAffiliateStoreByGoSellId(bool? isDeleted, long? goSellStoreId, CancellationToken cancellationToken = default);
        Task<AffiliateStore> GetBaseSpecificAffiliateByStoreId(long id, CancellationToken cancellationToken);
        Task<List<AffiliateStoreCurrency>> GetAllAffiliateStoreCurrencyAsync();
        Task<AffiliateStoreCurrencyViewModel> GetCurrencyUnitAsync(long id);
        Task<AffiliateStore> GetCurrencyUnitByIdAsync(long id);
        Task<List<AffiliateStore>> GetListCurrencyUnitAsync(List<long> ids);
    }
}
