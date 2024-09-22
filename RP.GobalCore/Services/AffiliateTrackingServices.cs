using System.Linq.Expressions;
using System.Web;
using RP.Affiliate.Tracking.Commands;
using RP.Affiliate.Tracking.Database;
using RP.Affiliate.Tracking.Entities;
using RP.Affiliate.Tracking.Handler;
using RP.Affiliate.Tracking.Queries;
using RP.Affiliate.Tracking.Repositories;
using RP.Affiliate.Tracking.Services.Interfaces;
using RP.Affiliate.Tracking.Utils;
using RP.Affiliate.Tracking.ViewModels;
using RP.Common.Constants;
using RP.Common.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace RP.Affiliate.Tracking.Services
{
    public class AffiliateTrackingServices : IAffiliateTrackingServices
    {
        private ILogger<AffiliateTrackingServices> Logger;
        private readonly IAffiliateRepository<AffiliateClickTracking> _affiliateClickTrackingRepository;
        private readonly IAffiliateRepository<AffiliateLink> _affiliateLinkRepository;
        private readonly IAffiliateRepository<AffiliateTrackingManagement> _affiliateTrackingManagementRepository;
        private readonly IAffiliateRepository<AffiliateProduct> _affiliateProductRepository;
        private readonly IAffiliateRepository<AffiliateOrderTracking> _affiliateOrderTrackingRepository;
        private readonly AffiliateContext _affiliateDbContext;
        public AffiliateTrackingServices(
            ILogger<AffiliateTrackingServices> logger,
            IAffiliateRepository<AffiliateClickTracking> affiliateClickTrackingRepository,
            IAffiliateRepository<AffiliateLink> affiliateLinkRepository,
            IAffiliateRepository<AffiliateTrackingManagement> affiliateTrackingManagementRepository,
            IAffiliateRepository<AffiliateProduct> affiliateProductRepository,
            IAffiliateRepository<AffiliateOrderTracking> affiliateOrderTrackingRepository,
            AffiliateContext affiliateDbContext
           )
        {
            Logger = logger;
            _affiliateClickTrackingRepository = affiliateClickTrackingRepository;
            _affiliateLinkRepository = affiliateLinkRepository;
            _affiliateTrackingManagementRepository = affiliateTrackingManagementRepository;
            _affiliateProductRepository = affiliateProductRepository;
            _affiliateOrderTrackingRepository = affiliateOrderTrackingRepository;
            _affiliateDbContext = affiliateDbContext;
        }

        public async Task<bool> CreateAffiliateClickTracking(AffiliateClickTracking clickTracking, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateLink = await _affiliateLinkRepository.Filter(x => x.TrackingId == clickTracking.TrackingId).FirstOrDefaultAsync();
                if (affiliateLink == null)
                {
                    return false;
                }
                var newAffiliateClickTracking = await _affiliateClickTrackingRepository.AddAsync(clickTracking);

                var result = await _affiliateClickTrackingRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                if (result)
                {
                    await CalculateAffiliateManagementAsync(newAffiliateClickTracking, affiliateLink);
                    result = await _affiliateClickTrackingRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                }
                Log.Logger.Information($"DONE {nameof(CreateClickTrackingCommandHandler)}");
                return result;

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateClickTrackingCommandHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }



        public async Task<List<string>> CreateAffiliateLinkTracking(List<AffiliateLink> affiliateLinks, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _affiliateProductRepository.Filter(null).FirstOrDefaultAsync();
                var reponses = new List<string>();
                affiliateLinks?.ForEach(item =>
                {
                    item.TrackingId = Guid.NewGuid();
                    // item.ProductId = product != null ? product.Id : 1;
                    GenerateTargetLink(item);
                    reponses.Add(item.TargetLink);
                });

                _affiliateLinkRepository.AddRange(affiliateLinks);
                await _affiliateLinkRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                return reponses;

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateClickTrackingCommandHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        private async Task CalculateAffiliateManagementAsync(AffiliateClickTracking newAffiliateClickTracking, AffiliateLink affiliateLink)
        {
            var affiliateTrackingManagement = await _affiliateTrackingManagementRepository.Filter(x => x.TrackingId == newAffiliateClickTracking.TrackingId && x.GroupId == newAffiliateClickTracking.GroupId)
                                                                                                  .FirstOrDefaultAsync();
            if (affiliateTrackingManagement != null)
            {
                var affiliateClickTrackings = await _affiliateClickTrackingRepository.Filter(x => x.TrackingId == newAffiliateClickTracking.TrackingId && x.GroupId == newAffiliateClickTracking.GroupId)
                                                                                     .ToListAsync();

                affiliateTrackingManagement.TotalClicks = affiliateClickTrackings.Select(x => (x.CreatedDate.GetValueOrDefault()).Date)
                                                                               .Distinct()
                                                                               .Count();// Will update when has setting from user
                affiliateTrackingManagement.TotalHits = affiliateClickTrackings.Count();

                affiliateTrackingManagement.UpdateLastModified(newAffiliateClickTracking.CreatedBy);

                _affiliateTrackingManagementRepository.Update(affiliateTrackingManagement);
            }
            else
            {
                var newAffiliateTrackingManagement = new AffiliateTrackingManagement()
                {
                    TrackingId = newAffiliateClickTracking.TrackingId,
                    GroupId = newAffiliateClickTracking.GroupId,
                    ProductId = affiliateLink.ProductId,
                    PartnerId = affiliateLink.PartnerId,
                    TotalClicks = 1,
                    TotalHits = 1,
                    CreatedBy = "Admin",
                    CampaignId = affiliateLink.CampaignId,
                };
                await _affiliateTrackingManagementRepository.AddAsync(newAffiliateTrackingManagement);
            }
        }

        public async Task<string> CreateAffiliateProductLinkTracking(AffiliateLink affiliateLink, CancellationToken cancellationToken)
        {
            try
            {
                affiliateLink.TrackingId = Guid.NewGuid();
                GenerateTargetLink(affiliateLink);
                var reponses = affiliateLink.TargetLink;
                await _affiliateLinkRepository.AddAsync(affiliateLink);
                await _affiliateLinkRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                return reponses;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateAffiliateProductLinkTracking)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }


        private void GenerateTargetLink(AffiliateLink affiliateLink)
        {
            if (!CommonFunction.IsValidUri(affiliateLink.OriginLink))
            {
                throw new Exception("Something went wrong: Invalid uri");
            }
            var baseUri = new UriBuilder(affiliateLink.OriginLink);
            var queryParams = HttpUtility.ParseQueryString(baseUri.Query);
            var hasTrackingId = false;
            foreach (string key in queryParams.Keys)
            {
                if (key != null && key.Contains("trackingId"))
                    hasTrackingId = true;
            }

            if (!hasTrackingId)
            {
                var queryToAppend = string.Format("trackingId={0}", affiliateLink.TrackingId);

                if (baseUri.Query != null && baseUri.Query.Length > 1)
                    baseUri.Query = string.Format("{0}&{1}", baseUri.Query.Substring(1), queryToAppend);
                else
                    baseUri.Query = queryToAppend;
            }
            else
            {
                queryParams["trackingId"] = affiliateLink.TrackingId.ToString();
                baseUri.Query = queryParams.ToString();
            }

            affiliateLink.TargetLink = baseUri.Uri.ToString();
        }

        public async Task<bool> CreateAffiliateOrderTracking(AffiliateOrderTracking orderTracking, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateOrder = await _affiliateOrderTrackingRepository.Filter(x => x.OrderId == orderTracking.OrderId && x.Website == orderTracking.Website).FirstOrDefaultAsync();
                if (affiliateOrder != null)
                {
                    return false;
                }

                var newAffiliateClickTracking = await _affiliateOrderTrackingRepository.AddAsync(orderTracking);
                var result = await _affiliateOrderTrackingRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

                Log.Logger.Information($"DONE {nameof(CreateAffiliateOrderTracking)}");
                return result;

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateAffiliateOrderTracking)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<AffiliateOrderTracking>> GetAffiliateOrderTracking(long LatestId)
        {
            try
            {
                List<AffiliateOrderTracking> affiliateOrders = new List<AffiliateOrderTracking>();
                if (LatestId == 0)
                {
                    affiliateOrders = await _affiliateOrderTrackingRepository.Filter(x => !x.IsDeleted).OrderByDescending(x => x.Id).Take(1).ToListAsync();
                }
                else
                {
                    affiliateOrders = await _affiliateOrderTrackingRepository.Filter(x => !x.IsDeleted && x.Id > LatestId).ToListAsync();
                }

                Log.Logger.Information($"DONE {nameof(GetAffiliateOrderTracking)}");
                return affiliateOrders;

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateOrderTracking)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdatePlatformByTrackingId(UpdatePlatformByTrackingIdCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var affiliateLink = await _affiliateLinkRepository.Filter(x => x.TrackingId == request.TrackingId).FirstOrDefaultAsync();
                if (affiliateLink == null)
                {
                    return false;
                }
                if ((int)request.Platform > -1) affiliateLink.SubId1 = request.Platform.GetDescription().ToString();
                affiliateLink.LastModifiedDate = DateTime.UtcNow;
                if (!string.IsNullOrEmpty(request.Sub02)) affiliateLink.SubId2 = request.Sub02;
                if (!string.IsNullOrEmpty(request.Sub03)) affiliateLink.SubId3 = request.Sub03;
                if (!string.IsNullOrEmpty(request.Sub04)) affiliateLink.SubId4 = request.Sub04;
                if (!string.IsNullOrEmpty(request.Sub05)) affiliateLink.SubId5 = request.Sub05;
                _affiliateLinkRepository.Update(affiliateLink);
                var reponses = await _affiliateLinkRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

                Log.Logger.Information($"DONE {nameof(UpdatePlatformByTrackingId)}");
                return reponses > 0 ? true : false;

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdatePlatformByTrackingId)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<AffiliateUrlReportViewModel> GetAffiliateUrlReport(GetAffiliateUrlReportQuery request, CancellationToken cancellationToken)
        {
            try
            {
                int totalCount = 0;
                var data = new List<AffiliateUrlModel>();
                var searchKeywordLower = request.Request.SearchKeyword?.ToLower();
                var searchTypeLower = request.Request.SearchType?.ToLower();
                bool isSearchCampaignName = AffUrlReportConstants.CAMPAIGN_NAME.Equals(searchTypeLower);

                var conditions = CreateUrlReportExpression(
                    request.Request.PublisherId,
                    request.AffiliateStoreId,
                    searchKeywordLower,
                    searchTypeLower,
                    request.Request.FromDate,
                    request.Request.ToDate);

                var trackingManagements = _affiliateTrackingManagementRepository.BuildQuery(conditions).AsNoTracking();

                var campaigns = _affiliateDbContext.AffiliateCampaigns.Where(x => !x.IsDeleted);
                if (!string.IsNullOrWhiteSpace(searchKeywordLower) && isSearchCampaignName)
                {
                    campaigns = campaigns.Where(x => x.Name.ToLower().Contains(searchKeywordLower));
                }

                var queryResult = from atm in trackingManagements
                                  join ac in campaigns
                                  on atm.CampaignId equals ac.Id into acGroup
                                  from ac in acGroup.DefaultIfEmpty()
                                  group new { atm, ac } by new { atm.TrackingId, atm.CampaignId, atm.ProductId } into g
                                  select new AffiliateUrlModel
                                  {
                                      TrachkingUrlId = g.Key.TrackingId,
                                      ProductId = g.Key.ProductId ?? 0,
                                      CampaignId = g.Key.CampaignId ?? 0,
                                      TotalClick = g.Sum(m => m.atm.TotalClicks)
                                  };

                queryResult = queryResult.OrderByDescending(x => x.TotalClick).ThenByDescending(x => x.TrachkingUrlId);
                totalCount = await queryResult.CountAsync();
                if (totalCount == 0)
                {
                    return new AffiliateUrlReportViewModel();
                }

                (decimal sumTotalOfOrder, decimal sumTotalClick) = GetSumDashboard(queryResult);

                if (request.Request.isExport)
                {
                    data = await queryResult.Take(ExportCommonConstant.SIZE_LIMIT).ToListAsync();
                }
                else
                {
                    data = await queryResult
                   .Skip(request.Request.Size * request.Request.Page)
                   .Take(request.Request.Size)
                   .ToListAsync();
                }

                data = await BuildData(data);

                var result = new AffiliateUrlReportViewModel
                {
                    Data = data,
                    TotalCount = totalCount,
                    SumTotalOfOrder = sumTotalOfOrder,
                    SumTotalClick = sumTotalClick,
                };

                return result;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAffiliateUrlReport)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        private async Task<List<AffiliateUrlModel>> BuildData(List<AffiliateUrlModel> data)
        {
            var campaignIds = data.Select(x => x.CampaignId).ToList();
            var campaigns = await _affiliateDbContext.AffiliateCampaigns.Where(x => campaignIds.Contains(x.Id))
                .ToDictionaryAsync(x => x.Id, x => x.Name);

            data.ForEach(x =>
            {
                x.CampaignName = campaigns.GetValueOrDefault(x.CampaignId);
            });

            var productIds = data.Select(x => x.ProductId).ToList();
            var products = await _affiliateDbContext.AffiliateProducts.Where(x => productIds.Contains(x.Id))
                 .ToDictionaryAsync(x => x.Id, x => new { x.Name, x.ImageUrl });
            data.ForEach(x =>
            {
                x.ProductName = products.GetValueOrDefault(x.ProductId)?.Name;
                x.ProductImageUrl = products.GetValueOrDefault(x.ProductId)?.ImageUrl;
            });

            var trachkingIds = data.Select(x => x.TrachkingUrlId).ToList();
            var trachkings = await _affiliateDbContext.AffiliateLinks.Where(x => trachkingIds.Contains(x.TrackingId))
                 .ToDictionaryAsync(x => x.TrackingId, x => x);
            data.ForEach(x =>
            {
                x.TrackingUrl = trachkings.GetValueOrDefault(x.TrachkingUrlId)?.TargetLink;
                x.CreatedDate = trachkings.GetValueOrDefault(x.TrachkingUrlId)?.CreatedDate;
                x.SubId01 = trachkings.GetValueOrDefault(x.TrachkingUrlId)?.SubId1;
                x.SubId02 = trachkings.GetValueOrDefault(x.TrachkingUrlId)?.SubId2;
                x.SubId03 = trachkings.GetValueOrDefault(x.TrachkingUrlId)?.SubId3;
                x.SubId04 = trachkings.GetValueOrDefault(x.TrachkingUrlId)?.SubId4;
                x.SubId05 = trachkings.GetValueOrDefault(x.TrachkingUrlId)?.SubId5;
            });

            return data;
        }

        private Expression<Func<AffiliateTrackingManagement, bool>> CreateUrlReportExpression(long publisherId, long affiliateStoreId, string searchKeyword, string searchType, DateTime? fromDate, DateTime? toDate, bool isIncludeDeleted = false)
        {
            var predicate = PredicateBuilder.New<AffiliateTrackingManagement>(true);
            predicate = predicate.And(p => p.PartnerId.Equals(publisherId) && p.TotalClicks > 0);

            if (fromDate.HasValue && toDate.HasValue)
            {
                predicate = predicate.And(p => p.AffiliateLink.CreatedDate <= toDate.Value && p.AffiliateLink.CreatedDate >= fromDate.Value);
            }

            if (!string.IsNullOrWhiteSpace(searchKeyword))
            {
                predicate = searchType switch
                {
                    AffUrlReportConstants.PRODUCT_NAME => predicate = predicate.And(p => p.AffiliateProduct.Name.ToLower().Contains(searchKeyword)),
                    AffUrlReportConstants.PRODUCT_ID => predicate = predicate.And(p => p.ProductId.ToString().Contains(searchKeyword)),
                    AffUrlReportConstants.SUB_ATTRIBUTE => predicate = predicate.And(p => p.AffiliateLink.SubId1.ToLower().Contains(searchKeyword) ||
                                                                                          p.AffiliateLink.SubId2.ToLower().Contains(searchKeyword) ||
                                                                                          p.AffiliateLink.SubId3.ToLower().Contains(searchKeyword) ||
                                                                                          p.AffiliateLink.SubId4.ToLower().Contains(searchKeyword) ||
                                                                                          p.AffiliateLink.SubId5.ToLower().Contains(searchKeyword)),
                    _ => predicate
                };
            }

            return predicate;
        }

        private Tuple<decimal, decimal> GetSumDashboard(IQueryable<AffiliateUrlModel> list)
        {
            //decimal sumTotalOfOrder = list.Sum(s => s.TotalOfOrder);
            decimal sumTotalOfOrder = 0;
            decimal sumTotalClick = list.Sum(s => s.TotalClick);
            return new Tuple<decimal, decimal>(sumTotalOfOrder, sumTotalClick);
        }

    }
}


