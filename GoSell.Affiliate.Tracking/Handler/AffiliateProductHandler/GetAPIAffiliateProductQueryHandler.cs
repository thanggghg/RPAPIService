using AutoMapper;
using GoSell.Affiliate.Tracking.Commons.Constants;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Queries.AffiliateProduct;
using GoSell.Affiliate.Tracking.Repositories.Interfaces;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Constants;
using GoSell.Library.Helpers.Api;
using GoSell.Library.Helpers.Pagination;
using GoSell.Library.Helpers.Service;
using LinqKit;
using MediatR;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class GetAPIAffiliateProductQueryHandler : IRequestHandler<GetAPIAffiliateProductQuery, PagingItems<AffiliateProductViewModel>>
    {
        private readonly IAffiliateProductRepository _affiliateProductRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBaseApi _baseApi;
        private readonly IBaseService _baseService;
        private readonly IAffiliateStoreServices _affiliateStoreServices;

        public GetAPIAffiliateProductQueryHandler(IAffiliateProductRepository affiliateProductRepository,
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

        public async Task<PagingItems<AffiliateProductViewModel>> Handle(GetAPIAffiliateProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var predicate = PredicateBuilder.New<AffiliateProduct>(true);

                if (request.AffiliateStoreId == -1)
                {
                    var affStoreIds = await _baseService.FilterGetAffiliateStoreByIds(_baseApi.User.StoreId, AffiliateStoreFilterStatus.ALL);
                    predicate = predicate.And(x => affStoreIds.Contains(x.AffiliateStoreId));
                }
                else
                {
                    predicate = predicate.And(x => x.AffiliateStoreId == request.AffiliateStoreId);
                }
                if (request.CategoryId != null)
                {
                    predicate.And(x => x.CategoryId == request.CategoryId);
                }
                if (request.isOutOfStock != null)
                {
                    predicate.And(x => x.IsOutOfStock == request.isOutOfStock);
                }
                if (request.IsDeleted != null)
                {
                    predicate.And(x => x.IsDeleted == request.IsDeleted);
                }
                var allAffilateStore = await _affiliateStoreServices.GetAllAffiliateStore(cancellationToken);

                var query = _affiliateProductRepository.GetProductAPIAsync(predicate);
                var lstProduct = query.ToList();
                var affiliateProducts = await query.PaginatedListAsync(request.PageSize.Value, request.PageNumber.Value, request.IsPaging);
                var lstaffiliateProducts = affiliateProducts != null ? _mapper.Map<PagingItems<AffiliateProductViewModel>>(affiliateProducts) : null;
                foreach ( var item in lstaffiliateProducts.Items)
                { 
                    item.Category = item.CategoryId != null ? lstProduct.Where(x=>x.Id == item.Id).FirstOrDefault().AffiliateCategory.Name : "";
                    item.AffiliateStoreName = allAffilateStore.Where(x => x.Id.Equals(item.AffiliateStoreId)).FirstOrDefault().Name; ;
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
