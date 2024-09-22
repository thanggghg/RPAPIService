using GoSell.Affiliate.Tracking.Commons.Constants;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Queries.AffiliateCampaign;
using GoSell.Affiliate.Tracking.Repositories.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Pagination;
using GoSell.Library.Helpers.Service;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateCampaignHandler
{
    public class GetAllAffiliateCampaignQueryHandler : IRequestHandler<GetAllAffiliateCampaignQuery, PagingItems<AffiliateCampaignViewModel>>
    {
        private readonly IAffiliateCampaignRepository _affiliateCampaignRepository;
        private readonly IBaseService _baseService;

        public GetAllAffiliateCampaignQueryHandler(IAffiliateCampaignRepository affiliateCampaignRepository,
                                           IBaseService baseService)
        {
            _affiliateCampaignRepository = affiliateCampaignRepository;
            _baseService = baseService;
        }

        public async Task<PagingItems<AffiliateCampaignViewModel>> Handle(GetAllAffiliateCampaignQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var predicate = PredicateBuilder.New<AffiliateCampaign>(true);

                if (request.AffiliateStoreId == -1)
                {
                    var affStoreIds = await _baseService.FilterGetAffiliateStoreByIds(request.StoreId, request.AffiliateStoreFilterStatus);
                    predicate = predicate.And(x => affStoreIds.Contains(x.AffiliateStoreId));
                }
                else
                {
                    // Validate AffiliateStoreId
                    if (_baseService.isInvalidAffiliateStore(request.AffiliateStoreId, request.StoreId))
                    {
                        return new PagingItems<AffiliateCampaignViewModel>
                        {
                            PagingInfo = new PagingInfo
                            {
                                PageNumber = request.PageNumber ?? 0,
                                PageSize = request.PageSize ?? 0,
                                TotalItems = 0
                            },
                            Items = []
                        };
                    }

                    predicate = predicate.And(x => x.AffiliateStoreId == request.AffiliateStoreId);
                    var affStoreIds = await _baseService.FilterGetAffiliateStoreByIds(request.StoreId, request.AffiliateStoreFilterStatus);
                    predicate = predicate.And(x => affStoreIds.Contains(x.AffiliateStoreId));
                }

                var utcNow = DateTime.UtcNow;
                request.Keyword = request.Keyword?.ToLower();

                if (request.Status != null && request.Status != AffiliateCampaignStatus.ALL)
                {
                    if (request.Status == AffiliateCampaignStatus.ENDED)
                    {
                        predicate.And(x => x.Status == AffiliateCampaignStatus.ENDED || (x.Status == AffiliateCampaignStatus.PUBLISHED && x.EndDate < utcNow));
                    }
                    else if (request.Status == AffiliateCampaignStatus.PUBLISHED)
                    {
                        predicate.And(x => x.Status == AffiliateCampaignStatus.PUBLISHED && x.EndDate >= utcNow);
                    }
                    else
                    {
                        predicate.And(x => x.Status == request.Status);
                    }
                }

                if (request.FromDate != null && request.ToDate != null)
                {
                    predicate.And(x => x.StartDate <= request.ToDate && x.EndDate >= request.FromDate);
                }

                if (!string.IsNullOrEmpty(request.Keyword))
                {
                    // search with campaign name
                    if (request.SearchType == AffiliateCampaignSearchType.CAMPAIGN_NAME)
                    {
                        predicate.And(x => x.Name.ToLower().Contains(request.Keyword));
                    }
                    else if (request.SearchType == AffiliateCampaignSearchType.CAMPAIGN_CREATED_BY)
                    {
                        predicate.And(x => x.CreatedBy.ToLower().Contains(request.Keyword));
                    }
                }

                var query = _affiliateCampaignRepository.GetAsync(predicate);

                query.Include(f => f.AffiliateCampaignProducts)
                     .ThenInclude(f => f.AffiliateProduct);

                var dataModel = query.Select(s => new AffiliateCampaignViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    NumOfProduct = s.AffiliateCampaignProducts.Count(c => c.AffiliateProduct.IsDeleted != true),
                    Status = s.Status == AffiliateCampaignStatus.PUBLISHED && s.EndDate < utcNow ? AffiliateCampaignStatus.ENDED : s.Status,
                    StartDate = s.StartDate,
                    EndDate = s.EndDate,
                    CreatedDate = s.CreatedDate,
                    CreatedBy = s.CreatedBy,
                    LastModifiedDate = s.LastModifiedDate,
                    LastModifiedBy = s.LastModifiedBy,
                    TerminatedBy = s.TerminatedBy,
                    TerminatedDate = s.TerminatedDate,
                    AffiliateStoreId = s.AffiliateStoreId
                });

                dataModel = dataModel.OrderBy(x => x.Status).ThenByDescending(x => x.CreatedDate).ThenBy(x => x.Name);

                var data = await dataModel.PaginatedListAsync(request.PageSize.Value, request.PageNumber.Value, request.IsPaging);

                return data;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateCampaignQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
