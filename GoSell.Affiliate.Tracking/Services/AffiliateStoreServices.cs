using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Config;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Repositories;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.Utils;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Api;
using GoSell.Library.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Services
{
    public class AffiliateStoreServices : IAffiliateStoreServices
    {
        private readonly ILogger<AffiliateStoreServices> _logger;
        private readonly IAffiliateRepository<AffiliateStore> _affiliateStoreRepository;
        private readonly IAffiliateRepository<AffiliateTheme> _affiliateThemeRepository;
        private readonly IAffiliateRepository<AffiliateBusiness> _affiliateBusinessRepository;
        private readonly IAffiliateRepository<AffiliateColorDefault> _affiliateColorRepository;
        private readonly IAffiliateRepository<AffiliateStoreCurrency> _affiliateStoreCurrencyRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AffiliateConfig _affiliateConfig;
        private readonly IMapper _mapper;
        private readonly IBaseApi _baseApi;
        public AffiliateStoreServices(
            ILogger<AffiliateStoreServices> logger,
            IAffiliateRepository<AffiliateStore> affiliateStoreRepository,
            IAffiliateRepository<AffiliateTheme> affiliateThemeRepository,
            IAffiliateRepository<AffiliateBusiness> affiliateBusinessRepository,
            IAffiliateRepository<AffiliateColorDefault> affiliateColorRepository,
            IAffiliateRepository<AffiliateStoreCurrency> affiliateStoreCurrencyRepository,
            IHttpClientFactory httpClientFactory,
            AffiliateConfig affiliateConfig,
            IMapper mapper,
            IBaseApi baseApi
        )
        {
            _logger = logger;
            _affiliateStoreRepository = affiliateStoreRepository;
            _affiliateThemeRepository = affiliateThemeRepository;
            _affiliateBusinessRepository = affiliateBusinessRepository;
            _affiliateColorRepository = affiliateColorRepository;
            _affiliateStoreCurrencyRepository = affiliateStoreCurrencyRepository;
            _httpClientFactory = httpClientFactory;
            _affiliateConfig = affiliateConfig;
            _mapper = mapper;
            _baseApi = baseApi;
        }

        public async Task<(bool, AffiliateStore)> CreateStoreAsync(AffiliateStore affiliateStore, CancellationToken cancellationToken)
        {
            try
            {
                var isCustomizeDomain = affiliateStore.Website.Contains(".");
                var domainBase = affiliateStore.Website;
                var domainConverted = isCustomizeDomain ? affiliateStore.Website : ConvertDomain(affiliateStore.Website);
                affiliateStore.ApiKey = CommonFunction.GenerateApiKey(32);
                affiliateStore.Website = domainConverted;

                await _affiliateStoreRepository.AddAsync(affiliateStore);
                var result = await _affiliateStoreRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                if (result)
                {
                    if (isCustomizeDomain)
                        await CallPublishDomainAsync(affiliateStore.Website, " ");
                    else
                        await CallPublishDomainAsync(domainBase);
                }
                _logger.LogInformation($"DONE {nameof(CreateStoreAsync)}");
                return (result, affiliateStore);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateStoreAsync)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAffiliateStore(AffiliateStore affiliateStore, CancellationToken cancellationToken)
        {
            try
            {
                _affiliateStoreRepository.Update(affiliateStore);
                var result = await _affiliateStoreRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                Log.Logger.Information($"DONE {nameof(UpdateAffiliateStore)}");
                return result;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateAffiliateStore)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateRangeAffiliateStoreAsync(List<AffiliateStore> affiliateStores, CancellationToken cancellationToken)
        {
            try
            {
                _affiliateStoreRepository.UpdateRange(affiliateStores);
                var result = await _affiliateStoreRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                Log.Logger.Information($"DONE {nameof(UpdateAffiliateStore)}");
                return result;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateAffiliateStore)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<AffiliateStore>> GetAllAffiliateStoreByGsId(long goSellStoreId)
        {
            try
            {
                var affiliateStores = await _affiliateStoreRepository.Filter(x => x.GoSellStoreId == goSellStoreId)
                    .Include(x => x.AffiliateStoreCurrency)
                    .OrderBy(x => x.Name).ThenBy(t => t.CreatedDate).ToListAsync();
                Log.Logger.Information($"DONE {nameof(GetAllAffiliateStoreByGsId)}");
                return affiliateStores;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateStoreByGsId)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<AffiliateStore>> GetAllAffiliateStore(CancellationToken cancellationToken)
        {
            try
            {
                var affiliateStores = await _affiliateStoreRepository.Filter(null).ToListAsync();
                Log.Logger.Information($"DONE {nameof(GetAllAffiliateStore)}");
                return affiliateStores;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateStore)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<AffiliateStore> GetSpecificAffiliateStoreByDomain(string domain, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateStore = await _affiliateStoreRepository.Filter(x => x.Website.Contains(domain) && !x.IsDeleted).FirstOrDefaultAsync();
                affiliateStore.AffiliateStoreCurrency = await _affiliateStoreCurrencyRepository.Filter(x => x.Id == affiliateStore.AffiliateStoreCurrencyId && !x.IsDeleted).FirstOrDefaultAsync();
                Log.Logger.Information($"DONE {nameof(GetSpecificAffiliateStoreByDomain)}");
                return affiliateStore;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetSpecificAffiliateStoreByDomain)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<AffiliateStore> GetSpecificAffiliateByStoreId(long storeId, CancellationToken cancellationToken = default)
        {
            try
            {
                var affiliateStore = await _affiliateStoreRepository.Filter(x => x.Id == storeId && x.GoSellStoreId == _baseApi.User.StoreId).FirstOrDefaultAsync();
                Log.Logger.Information($"DONE {nameof(GetSpecificAffiliateByStoreId)}");
                return affiliateStore;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetSpecificAffiliateByStoreId)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<AffiliateStore> GetBaseSpecificAffiliateByStoreId(long affiliateStoreId, CancellationToken cancellationToken = default)
        {
            try
            {
                var affiliateStore = await _affiliateStoreRepository.Filter(x => x.Id == affiliateStoreId).Include(x => x.AffiliateStoreCurrency).FirstOrDefaultAsync();
                Log.Logger.Information($"DONE {nameof(GetSpecificAffiliateByStoreId)}");
                return affiliateStore;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetSpecificAffiliateByStoreId)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public AffiliateStore GetStoreByApiKey(string apiKey)
        {
            var store = _affiliateStoreRepository.Filter(x => x.ApiKey == apiKey)
                .Include(x => x.AffiliateStoreCurrency)
                .FirstOrDefault();
            return store;
        }

        public async Task<List<AffiliateTheme>> GetAllAffiliateThemeByStoreId(long storeId, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateThemes = await _affiliateThemeRepository.Filter(filter: x => x.StoreId == storeId && !x.IsDeleted, includes: [x => x.AffiliateColorDefault]).OrderBy(x => x.Id).Include(x => x.AffiliateColorDefault).ToListAsync();
                Log.Logger.Information($"DONE {nameof(GetAllAffiliateThemeByStoreId)}");
                return affiliateThemes;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateThemeByStoreId)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<AffiliateTheme> GetAffiliateThemePublishedByStoreId(long storeId, CancellationToken cancellationToken)
        {
            try
            {

                var affiliateTheme = await _affiliateThemeRepository.Filter(x => x.StoreId == storeId && !x.IsDeleted && x.IsPublished).Include(x => x.AffiliateColorDefault).FirstOrDefaultAsync();
                Log.Logger.Information($"DONE {nameof(GetAffiliateThemePublishedByStoreId)}");
                return affiliateTheme;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateThemePublishedByStoreId)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<AffiliateTheme> GetAffiliateThemeById(long id, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateTheme = await _affiliateThemeRepository.Filter(x => x.Id == id).Include(x => x.AffiliateColorDefault).FirstOrDefaultAsync();
                Log.Logger.Information($"DONE {nameof(GetAffiliateThemeById)}");
                return affiliateTheme;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateThemeById)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> CreateApiKey(long storeId, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateStore = await _affiliateStoreRepository.Filter(x => x.Id == storeId && x.GoSellStoreId == _baseApi.User.StoreId).FirstOrDefaultAsync();
                affiliateStore.ApiKey = CommonFunction.GenerateApiKey(32);
                affiliateStore.UpdateLastModified(_baseApi.User.Sub);
                _affiliateStoreRepository.Update(affiliateStore);
                await _affiliateStoreRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                Log.Logger.Information($"DONE {nameof(CreateApiKey)}");
                return affiliateStore.ApiKey;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateApiKey)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<AffiliateStore> GetSpecificAffiliateByGoSellStoreId(long goSellStoreId, CancellationToken cancellationToken = default)
        {
            var affiliateStore = await _affiliateStoreRepository.Filter(x => x.GoSellStoreId == goSellStoreId).FirstOrDefaultAsync();
            return affiliateStore;
        }

        public async Task<bool> CreateThemeByStoreAsync(CreateAffiliateStoreCommand request, AffiliateStore store, CancellationToken cancellationToken)
        {
            var affBusiness = await _affiliateBusinessRepository.GetByIdAsync(request.BusinessId);

            if (affBusiness == null) return false;

            var theme = new AffiliateTheme()
            {
                StoreId = store.Id,
                ColorId = request.ColorId,
                Logo = request.Logo,
                CoverImage = affBusiness.CoverImagePath,
                IsDeleted = false,
                IsPublished = true,
                LastModifiedDate = store.LastModifiedDate,
                LastModifiedBy = store.LastModifiedBy,
                CreatedDate = store.CreatedDate,
                CreatedBy = store.CreatedBy
            };
            await _affiliateThemeRepository.AddAsync(theme);

            return await _affiliateThemeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

        public async Task<bool> CreateThemeAsync(AffiliateTheme affiliateTheme, CancellationToken cancellationToken)
        {
            await _affiliateThemeRepository.AddAsync(affiliateTheme);

            return await _affiliateThemeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
        public async Task<bool> UpdateThemeAsync(AffiliateTheme affiliateTheme, CancellationToken cancellationToken)
        {
            _affiliateThemeRepository.Update(affiliateTheme);
            var result = await _affiliateStoreRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            Log.Logger.Information($"DONE {nameof(UpdateAffiliateStore)}");
            return await _affiliateThemeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
        public async Task<bool> PublishThemeAsync(AffiliateTheme affiliateTheme, CancellationToken cancellationToken)
        {
            var themeActive = GetAffiliateThemePublishedByStoreId(affiliateTheme.StoreId, cancellationToken).Result;
            if (themeActive != null)
            {
                themeActive.IsPublished = false;
                _affiliateThemeRepository.Update(themeActive);
            }
            affiliateTheme.IsPublished = true;
            _affiliateThemeRepository.Update(affiliateTheme);
            var result = await _affiliateStoreRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            Log.Logger.Information($"DONE {nameof(UpdateAffiliateStore)}");
            return await _affiliateThemeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

        private async Task CallPublishDomainAsync(string newDomain, string oldDomain = null)
        {
            try
            {
                var url = string.Empty;

                if (string.IsNullOrEmpty(oldDomain))
                {
                    url = string.Format("{0}?DOMAIN_NAME={1}", _affiliateConfig.PublishDomainUrl, newDomain);
                }
                else
                {
                    url = string.Format("{0}?NEW_DOMAIN={1}&OLD_DOMAIN={2}", _affiliateConfig.UpdateDomainUrl, newDomain, oldDomain);
                }

                var httpClient = _httpClientFactory.CreateClient(ApiNameConstants.AFFiLIAATE_TRACKING.ToString());
                httpClient.DefaultRequestHeaders.Clear();

                var httpRequest = new HttpRequestMessage(HttpMethod.Post, url);

                var username = _affiliateConfig.Username;
                var password = _affiliateConfig.Password;
                var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")));
                httpClient.DefaultRequestHeaders.Authorization = authValue;
                if (!string.IsNullOrEmpty(_affiliateConfig.PublishDomainUrl))
                {
                    var temp = await httpClient.SendAsync(httpRequest);

                }

                Log.Logger.Information($"Log_CallPublishDomainAsync: url: ${url}");
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CallPublishDomainAsync)} : {ex.Message}");
                throw new Exception(ex.Message);
            }

        }
        private string ConvertDomain(string brandName)
        {
            return string.Format("{0}{1}", brandName, _affiliateConfig.SubDomainPublish);
        }

        public async Task<List<AffiliateColorDefault>> GetAllAffiliateColorDefaultAsync(bool isBusinessColor, CancellationToken cancellationToken)
        {
            Expression<Func<AffiliateColorDefault, bool>> filter = x => isBusinessColor ? x.BusinessId != 0 : x.BusinessId == 0;
            var colors = await _affiliateColorRepository.Filter(filter: filter, orderBy: x => x.OrderBy(x => x.Priority)).ToListAsync();
            return colors;
        }

        public async Task<List<AffiliateBusiness>> GetAllAffiliateBusinessAsync()
        {
            var listBusiness = await _affiliateBusinessRepository.Filter(null, orderBy: x => x.OrderBy(x => x.Priority)).ToListAsync();
            return listBusiness;
        }

        public async Task<bool> UpdateRangeThemeAsync(List<AffiliateTheme> affiliateThemes, CancellationToken cancellationToken)
        {
            _affiliateThemeRepository.UpdateRange(affiliateThemes);
            var result = await _affiliateStoreRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            Log.Logger.Information($"DONE {nameof(UpdateRangeThemeAsync)}");
            return await _affiliateThemeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

        public async Task<List<DefaultThemeViewModel>> GetThemesOfBusinessQueryAsync(long externalStoreId)
        {
            var listBusiness = await _affiliateBusinessRepository.Filter(null).ToListAsync();
            var listColor = await _affiliateColorRepository.Filter(x => x.BusinessId != 0).ToListAsync();
            var store = await _affiliateStoreRepository.GetByIdAsync(externalStoreId);
            var listTheme = new List<DefaultThemeViewModel>();

            foreach (var business in listBusiness)
            {
                var color = listColor.Where(x => x.BusinessId == business.Id).First();
                var theme = new AffiliateTheme
                {
                    StoreId = externalStoreId,
                    ColorId = color.Id,
                    IsPublished = false,
                    IsDeleted = false,
                    CoverImage = business.CoverImagePath,
                    Logo = store.Logo,
                    AffiliateColorDefault = color
                };
                var viewTheme = _mapper.Map<AffiliateThemeViewModel>(theme);
                viewTheme.ThumbnailImage = business.ThumbnailImagePath;

                listTheme.Add(new DefaultThemeViewModel
                {
                    ColorId = color.Id,
                    BusinessId = business.Id,
                    BusinessKey = business.LanguageKey,
                    Theme = viewTheme
                });
            }

            return listTheme;
        }

        public async Task<(AffiliateTheme, AffiliateBusiness)> GetAffiliateThemeByBusinessIdAsync(GetAffiliateThemeByBusinessIdQuery command, CancellationToken cancellationToken)
        {
            var store = await _affiliateStoreRepository.GetByIdAsync(command.ExternalStoreId);
            var business = await _affiliateBusinessRepository.Filter(x => x.Id == command.BusinessId).FirstOrDefaultAsync();
            var color = await _affiliateColorRepository.Filter(x => x.BusinessId == command.BusinessId).FirstOrDefaultAsync();
            var theme = new AffiliateTheme()
            {
                StoreId = store.Id,
                ColorId = color.Id,
                IsPublished = false,
                IsDeleted = false,
                CoverImage = business.CoverImagePath,
                Logo = store.Logo,
                AffiliateColorDefault = color
            };
            return (theme, business);
        }

        public async Task<bool> UpdateWebsiteOrIsDeletedOfExternalStoreAsync(UpdateWebsiteOrIsDeletedOfExternalStoreCommand request, CancellationToken cancellationToken)
        {
            var store = await _affiliateStoreRepository.Filter(x => x.Id == request.ExternalStoreId && x.GoSellStoreId == _baseApi.User.StoreId).FirstOrDefaultAsync();
            var currentWebsite = store.Website;
            var isSameDomain = currentWebsite == request.Website || string.IsNullOrEmpty(request.Website);

            if (store == null)
                return false;

            if (store.IsDeleted != request.IsDeleted)
                store.IsDeleted = request.IsDeleted;

            if (!isSameDomain)
                store.Website = request.Website;

            store.UpdateLastModified(_baseApi.User.Sub);

            _affiliateStoreRepository.Update(store);
            var result = await _affiliateStoreRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            if (result && !isSameDomain)
            {
                await CallPublishDomainAsync(request.Website, currentWebsite);
            }

            return result;
        }

        /// <summary>
        /// get from net service. used validate affiliate store when call api from client
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<AffiliateStore> GetAffiliateStoreById(long id, CancellationToken cancellationToken)
        {
            // Please not change this function

            return await _affiliateStoreRepository.GetByIdAsync(id);
        }

        public async Task<List<AffiliateStore>> GetAllAffiliateStoreByGoSellId(bool? isDeleted, long? goSellStoreId, CancellationToken cancellationToken = default)
        {
            Expression<Func<AffiliateStore, bool>> filter = x => x.GoSellStoreId == (_baseApi.User.StoreId == 0 ? goSellStoreId : _baseApi.User.StoreId);

            if (isDeleted != null)
            {
                filter = filter.And(x => x.IsDeleted == isDeleted);
            }

            return await _affiliateStoreRepository.Filter(filter).OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<List<AffiliateStoreCurrency>> GetAllAffiliateStoreCurrencyAsync()
        {
            var currencies = await _affiliateStoreCurrencyRepository.Filter(x => !x.IsDeleted).ToListAsync();
            return currencies;
        }

        public async Task<AffiliateStoreCurrencyViewModel> GetCurrencyUnitAsync(long id)
        {
            try
            {
                var affiliateStore = await _affiliateStoreRepository.Filter(x => x.Id == id && x.GoSellStoreId == _baseApi.User.StoreId)
                    .Include(x => x.AffiliateStoreCurrency).FirstOrDefaultAsync();

                if (affiliateStore?.AffiliateStoreCurrency == null)
                {
                    throw new Exception("Affiliate store does not have currency information.");
                }

                return _mapper.Map<AffiliateStoreCurrencyViewModel>(affiliateStore.AffiliateStoreCurrency);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetCurrencyUnitAsync)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<AffiliateStore> GetCurrencyUnitByIdAsync(long id)
        {
            try
            {
                var affiliateStore = await _affiliateStoreRepository.Filter(x => x.Id == id && x.GoSellStoreId == _baseApi.User.StoreId)
                    .Include(x => x.AffiliateStoreCurrency).FirstOrDefaultAsync();

                return affiliateStore;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetCurrencyUnitAsync)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<AffiliateStore>> GetListCurrencyUnitAsync(List<long> ids)
        {
            try
            {
                var affiliateStore = await _affiliateStoreRepository.Filter(x => ids.Contains(x.Id) && x.GoSellStoreId == _baseApi.User.StoreId)
                    .Include(x => x.AffiliateStoreCurrency).ToListAsync();

                return affiliateStore;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetListCurrencyUnitAsync)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
