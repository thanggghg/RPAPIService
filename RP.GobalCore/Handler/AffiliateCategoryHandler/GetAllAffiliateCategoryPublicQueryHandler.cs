using AutoMapper;
using RP.Affiliate.Authentication.Domain.Entities.Affiliate;
using RP.Affiliate.Tracking.Commons.Constants;
using RP.Affiliate.Tracking.Database.Entities;
using RP.Affiliate.Tracking.Queries.AffiliateCategory;
using RP.Affiliate.Tracking.Repositories.Interfaces;
using RP.Affiliate.Tracking.Services.Interfaces;
using RP.Affiliate.Tracking.ViewModels;
using RP.Library.Helpers.Api;
using RP.Library.Helpers.Pagination;
using RP.Library.Helpers.Service;
using LinqKit;
using MediatR;
using Serilog;

namespace RP.Affiliate.Tracking.Handler.AffiliateCategoryHandler
{
    public class GetAllAffiliateCategoryPublicQueryHandler : IRequestHandler<GetAllAffiliateCategoryPublicQuery, PagingItems<AffiliateCategoryPublicViewModel>>
    {
        private readonly IAffiliateCategoryRepository _AffiliateCategoryRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBaseApi _baseApi;
        private readonly IBaseService _baseService;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        public GetAllAffiliateCategoryPublicQueryHandler(IAffiliateCategoryRepository AffiliateCategoryRepository,
                                            IMediator mediator,
                                            IMapper mapper,
                                            IBaseApi baseApi,
                                            IBaseService baseService,
                                            IAffiliateStoreServices affiliateStoreServices)
        {
            _AffiliateCategoryRepository = AffiliateCategoryRepository;
            _mediator = mediator;
            _mapper = mapper;
            _baseApi = baseApi;
            _baseService = baseService;
            _affiliateStoreServices = affiliateStoreServices;
        }
        public async Task<PagingItems<AffiliateCategoryPublicViewModel>> Handle(GetAllAffiliateCategoryPublicQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var predicate = PredicateBuilder.New<AffiliateCategory>(true);

                if (request.AffiliateStoreId != 0)
                {
                    predicate = predicate.And(x => x.AffiliateStoreId == request.AffiliateStoreId);
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

                var affiliateStore = await _affiliateStoreServices.GetAffiliateStoreById(request.AffiliateStoreId, cancellationToken);

                var query = _AffiliateCategoryRepository.GetAllAsync(predicate);
                var affiliateCategorys = await query.PaginatedListAsync(request.PageSize.Value, request.PageNumber.Value, request.IsPaging);
                
                Log.Logger.Information($"DONE {nameof(GetAllAffiliateCategoryPublicQueryHandler)}");

                var result = affiliateCategorys != null ? _mapper.Map<PagingItems<AffiliateCategoryPublicViewModel>>(affiliateCategorys) : null;

                if (result.Items.Any())
                {
                    foreach (var aff in result.Items)
                    {
                        aff.AffiliateStoreName = affiliateStore.Name;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateCategoryPublicQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
