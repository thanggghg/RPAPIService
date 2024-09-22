using AutoMapper;
using GoSell.Affiliate.Tracking.Commons.Constants;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Constants;
using GoSell.Library.Extensions.JWT;
using MediatR;
using Microsoft.Extensions.Configuration;
using ProxyClient.Services;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class GetAffiliateStoreByAPIQueryHandler : IRequestHandler<GetAffiliateStoreByAPIQuery, AffiliateStoreSourceVNViewModel>
    {
        private readonly IAffiliateStoreServices _affiliateStoreService;

        public GetAffiliateStoreByAPIQueryHandler(IAffiliateStoreServices affiliateStoreServices)
        {
            _affiliateStoreService = affiliateStoreServices;
        }
        public Task<AffiliateStoreSourceVNViewModel> Handle(GetAffiliateStoreByAPIQuery request, CancellationToken cancellationToken)
        {
            var affStore = _affiliateStoreService.GetStoreByApiKey(request.ApiKey);

            if (affStore == null)
                throw new Exception("Store does not exist");

            var affStoreModel = new AffiliateStoreSourceVNViewModel();
            affStoreModel.StoreName = affStore.Name;
            affStoreModel.StoreCurrency = affStore?.AffiliateStoreCurrency != null ? affStore.AffiliateStoreCurrency.Code : CurrencyCodes.VND;
            affStoreModel.StoreLanguage = affStoreModel.StoreCurrency == CurrencyCodes.VND ? UtilsConstants.LANG_VI : UtilsConstants.LANG_EN;
            affStoreModel.CountryCode = UtilsConstants.DefaultTimeZone;

            return Task.FromResult(affStoreModel);
        }
    }
}
