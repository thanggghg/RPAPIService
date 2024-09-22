using System.Globalization;
using AutoMapper;
using RP.Affiliate.Tracking.Commons.Constants;
using RP.Affiliate.Tracking.Database.Entities;
using RP.Affiliate.Tracking.Entities;
using RP.Affiliate.Tracking.Queries.AffiliateProduct;
using RP.Affiliate.Tracking.Repositories.Interfaces;
using RP.Affiliate.Tracking.Services.Interfaces;
using RP.Affiliate.Tracking.ViewModels;
using RP.Library.Constants;
using RP.Library.Helpers.Api;
using RP.Library.Helpers.Pagination;
using RP.Library.Helpers.Service;
using LinqKit;
using MediatR;
using Nest;
using Serilog;
using RP.Common.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using RP.Affiliate.Tracking.Utils;

namespace RP.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class GetAllAffiliateProductQueryHandler : IRequestHandler<GetAllAffiliateProductQuery, PagingItems<AffiliateProductViewModel>>
    {
        private readonly IAffiliateProductRepository _affiliateProductRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBaseApi _baseApi;
        private readonly IBaseService _baseService;
        private readonly IAffiliateStoreServices _affiliateStoreServices;

        public GetAllAffiliateProductQueryHandler(IAffiliateProductRepository affiliateProductRepository,
                                           IMediator mediator,
                                           IMapper mapper,
                                           IBaseApi baseApi,
                                           IBaseService baseService,
                                           IAffiliateStoreServices affiliateStoreServices)
        {
            _affiliateProductRepository = affiliateProductRepository;
            _mediator = mediator;
            _mapper = mapper;
            _baseApi = baseApi;
            _baseService = baseService;
            _affiliateStoreServices = affiliateStoreServices;
        }

        public async Task<PagingItems<AffiliateProductViewModel>> Handle(GetAllAffiliateProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var predicate = PredicateBuilder.New<AffiliateProduct>(true);

                if(request.AffiliateStoreId == -1)
                {
                    var affStoreIds = await _baseService.FilterGetAffiliateStoreByIds(_baseApi.User.StoreId, request.AffiliateStoreFilterStatus);
                    predicate = predicate.And(x => affStoreIds.Contains(x.AffiliateStoreId));
                }
                else
                {
                    predicate = predicate.And(x => x.AffiliateStoreId == request.AffiliateStoreId);
                    var affStoreIds = await _baseService.FilterGetAffiliateStoreByIds(_baseApi.User.StoreId, request.AffiliateStoreFilterStatus);
                    predicate = predicate.And(x => affStoreIds.Contains(x.AffiliateStoreId));
                }

                request.Keyword = request.Keyword?.ToLower();

                if (request.SearchType == AffiliateProductSearchType.PRODUCT_NAME)
                {
                    predicate.And(x => EF.Functions.ILike(EF.Functions.Unaccent(x.Name), EF.Functions.Unaccent($"%{CommonFunction.EscapeSpecialCharacters(request.Keyword)}%"), "\\"));
                }
                else if (request.SearchType == AffiliateProductSearchType.PRODUCT_REF_ID)
                {
                    predicate.And(x => x.RefProductId.ToLower().Contains(request.Keyword));
                }

                if (request.Status != null && request.Status != AffiliateProductStatusSearchType.ALL)
                {
                    switch (request.Status)
                    {
                        case AffiliateProductStatusSearchType.STOP_SELLING:
                            predicate.And(x => x.IsStopSelling == true);
                            break;
                        case AffiliateProductStatusSearchType.SELLING:
                            predicate.And(x => x.IsStopSelling == false && x.IsOutOfStock == false);
                            break;
                        case AffiliateProductStatusSearchType.OUT_OF_STOCK:
                            predicate.And(x => x.IsStopSelling == false && x.IsOutOfStock == true);
                            break;
                        case AffiliateProductStatusSearchType.ALL_PREVIEW:
                            predicate.And(x => x.IsStopSelling == false);
                            break;
                        default:
                            break;
                    }
                }
                else if (request.Status == AffiliateProductStatusSearchType.ALL_PREVIEW)
                {
                    predicate.And(x => x.IsStopSelling == false);
                }

                if (request.CategoryId != null)
                {
                    predicate.And(x => x.CategoryId == request.CategoryId);
                }
                var allAffilateStore = await _affiliateStoreServices.GetAllAffiliateStoreByGoSellId(null, _baseApi.User.StoreId, cancellationToken);

                var query = _affiliateProductRepository.GetAsync(predicate);

                var affiliateProducts = await query.PaginatedListAsync(request.PageSize.Value, request.PageNumber.Value, request.IsPaging);
                var lstaffiliateProducts = affiliateProducts != null ? _mapper.Map<PagingItems<AffiliateProductViewModel>>(affiliateProducts) : null;
                var listAffiliateCurrency = await _affiliateStoreServices.GetListCurrencyUnitAsync(lstaffiliateProducts.Items.Select(x => x.AffiliateStoreId).ToList());
                foreach (var item in lstaffiliateProducts.Items )
                {
                    item.AffiliateStoreName = allAffilateStore.Where(x=>x.Id.Equals(item.AffiliateStoreId)).FirstOrDefault().Name;

                    var affiliateCurrency = listAffiliateCurrency.FirstOrDefault(x => x.Id == item.AffiliateStoreId);
                    var currencyCode = affiliateCurrency?.AffiliateStoreCurrency != null ? affiliateCurrency.AffiliateStoreCurrency.Code : CurrencyCodes.VND;
                    var currencySymbol = affiliateCurrency?.AffiliateStoreCurrency != null ? affiliateCurrency.AffiliateStoreCurrency.Symbol : "đ";

                    item.SalePriceCurrency = Helpers.FormatCurrency(item.SalePrice.GetValueOrDefault(), currencyCode, currencySymbol);
                    item.RegularPriceCurrency = Helpers.FormatCurrency(item.RegularPrice.GetValueOrDefault(), currencyCode, currencySymbol);
                }

                return lstaffiliateProducts;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateProductQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
