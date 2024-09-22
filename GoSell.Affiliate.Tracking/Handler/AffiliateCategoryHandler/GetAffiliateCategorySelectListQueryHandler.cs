using AutoMapper;
using GoSell.Affiliate.Tracking.Commons.Constants;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Queries.AffiliateCategory;
using GoSell.Affiliate.Tracking.Repositories.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Api;
using GoSell.Library.Helpers.Pagination;
using LinqKit;
using MediatR;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateCategoryHandler
{
    public class GetAffiliateCategorySelectListQueryHandler : IRequestHandler<GetAffiliateCategorySelectListQuery, PagingItems<AffiliateCategoryViewModel>>
    {
        private readonly IAffiliateCategoryRepository _AffiliateCategoryRepository;
        private readonly IAffiliateProductRepository _AffiliateProductRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBaseApi _baseApi;
        public GetAffiliateCategorySelectListQueryHandler(IAffiliateCategoryRepository AffiliateCategoryRepository,
                                            IAffiliateProductRepository AffiliateProductRepository,
                                            IMediator mediator,
                                            IMapper mapper,
                                            IBaseApi baseApi)
        {
            _AffiliateCategoryRepository = AffiliateCategoryRepository;
            _AffiliateProductRepository = AffiliateProductRepository;
            _mediator = mediator;
            _mapper = mapper;
            _baseApi = baseApi;
        }
        public async Task<PagingItems<AffiliateCategoryViewModel>> Handle(GetAffiliateCategorySelectListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var predicate = PredicateBuilder.New<AffiliateCategory>(true);

                predicate = predicate.And(x => x.AffiliateStoreId == request.AffiliateStoreId);
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


                if(request.AffiliateProductId.HasValue && request.AffiliateProductId > 0)
                {
                    var product = await _AffiliateProductRepository.GetByIdAsync(request.AffiliateProductId.Value, request.AffiliateStoreId);
                    if(product != null)
                    {
                        predicate.Or(x => x.Id == product.CategoryId);
                    }
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
