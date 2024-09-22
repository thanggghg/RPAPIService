using AutoMapper;
using GoSell.Affiliate.Tracking.Commons.Constants;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Queries.AffiliateCategory;
using GoSell.Affiliate.Tracking.Repositories.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Api;
using GoSell.Library.Helpers.Pagination;
using GoSell.Library.Helpers.Service;
using LinqKit;
using MediatR;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateCategoryHandler
{
    public class GetAllAffiliateCategoryQueryHandler : IRequestHandler<GetAllAffiliateCategoryQuery, PagingItems<AffiliateCategoryViewModel>>
    {
        private readonly IAffiliateCategoryRepository _AffiliateCategoryRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBaseApi _baseApi;
        private readonly IBaseService _baseService;
        public GetAllAffiliateCategoryQueryHandler(IAffiliateCategoryRepository AffiliateCategoryRepository,
                                            IMediator mediator,
                                            IMapper mapper,
                                            IBaseApi baseApi,
                                            IBaseService baseService)
        {
            _AffiliateCategoryRepository = AffiliateCategoryRepository;
            _mediator = mediator;
            _mapper = mapper;
            _baseApi = baseApi;
            _baseService = baseService;
        }
        public async Task<PagingItems<AffiliateCategoryViewModel>> Handle(GetAllAffiliateCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var predicate = PredicateBuilder.New<AffiliateCategory>(true);

                if (request.AffiliateStoreId != 0)
                {
                    predicate = predicate.And(x => x.AffiliateStoreId == request.AffiliateStoreId);
                    var affStoreIds = await _baseService.FilterGetAffiliateStoreByIds(_baseApi.User.StoreId, request.StoreStatus);
                    predicate = predicate.And(x => affStoreIds.Contains(x.AffiliateStoreId));
                }
                else
                {
                    var affStoreIds = await _baseService.FilterGetAffiliateStoreByIds(_baseApi.User.StoreId, request.StoreStatus);
                    predicate = predicate.And(x => affStoreIds.Contains(x.AffiliateStoreId));
                }

                predicate = predicate.And(x => x.IsDeleted != true);
                request.Keyword = request.Keyword?.ToLower();

                if (request.SearchType == AffiliateCategorySearchType.CATEGORY_NAME)
                {
                    predicate.And(x => x.Name.ToLower().Contains(request.Keyword));
                }
                else if (request.SearchType == AffiliateCategorySearchType.CATEGORY_REF_ID)
                {
                    predicate.And(x => x.RefCategoryId.ToLower().Contains(request.Keyword));
                }

                if (!string.IsNullOrEmpty(request.Status) && request.Status != AffiliateCategoryStatusSearchType.ALL)
                {
                    var status = request.Status == AffiliateCategoryStatusSearchType.ACTIVE;
                    predicate.And(x => x.Status == status);
                }

                var query = _AffiliateCategoryRepository.GetAllAsync(predicate);
                var affiliateCategorys = await query.PaginatedListAsync(request.PageSize.Value, request.PageNumber.Value, request.IsPaging);
                Log.Logger.Information($"DONE {nameof(GetAllAffiliateCategoryQueryHandler)}");
                return affiliateCategorys != null ? _mapper.Map<PagingItems<AffiliateCategoryViewModel>>(affiliateCategorys) : null;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateCategoryQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
