using System.Linq.Expressions;
using GoSell.Affiliate.Tracking.Commons.Constants;
using GoSell.Affiliate.Tracking.Database;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Models.Requests;
using GoSell.Affiliate.Tracking.Queries.AffiliateCampaign;
using GoSell.Affiliate.Tracking.Repositories.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Seedwork;
using GoSell.Library.Utils;
using Microsoft.EntityFrameworkCore;

namespace GoSell.Affiliate.Tracking.Repositories
{
    public class AffiliateCampaignRepository(AffiliateContext context) : IAffiliateCampaignRepository
    {
        private readonly AffiliateContext _context = context;
        public IUnitOfWork UnitOfWork => _context;

        /// <summary>
        /// Create campaign and return campaign id
        /// </summary>
        /// <param name="affiliateCampaign"></param>
        /// <param name="campaignProducts"></param>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public async Task<long> CreateCampaign(AffiliateCampaign affiliateCampaign, List<CampaignProductRequest> campaignProducts, string userLogin)
        {
            using var dbContextTransaction = _context.Database.BeginTransaction();
            try
            {
                var dateUtcNow = DateTime.UtcNow;

                affiliateCampaign.CreatedBy = userLogin;
                affiliateCampaign.CreatedDate = dateUtcNow;
                affiliateCampaign.LastModifiedBy = userLogin;

                _context.AffiliateCampaigns.Add(affiliateCampaign);
                await _context.SaveChangesAsync();

                if (affiliateCampaign.Id > 0)
                {
                    var campaignProductsAdd = campaignProducts.Select(e => new AffiliateCampaignProduct
                    {
                        AffiliateCampaignId = affiliateCampaign.Id,
                        AffiliateProductId = e.ProductId,
                        CommissionPercent = e.CommissionPercent,
                        CommissionFix = e.CommissionFix,
                        CreatedDate = dateUtcNow,
                        CreatedBy = userLogin,
                        LastModifiedBy = userLogin,
                        LastModifiedDate = dateUtcNow,
                    });

                    await _context.AffiliateCampaignProducts.AddRangeAsync(campaignProductsAdd);
                    await _context.SaveChangesAsync();

                    dbContextTransaction.Commit();
                    return affiliateCampaign.Id;
                }
                else
                {
                    dbContextTransaction.Rollback();
                    return 0;
                }
            }
            catch (Exception ex)
            {
                var a = ex.Message;
                dbContextTransaction.Rollback(); //Required according to MSDN article 
                return 0;
            }
        }

        public async Task<long> UpdateCampaign(AffiliateCampaign affiliateCampaign, List<CampaignProductRequest> campaignProducts, string userLogin)
        {
            using var dbContextTransaction = _context.Database.BeginTransaction();
            try
            {
                var dateUtcNow = DateTime.UtcNow;

                affiliateCampaign.LastModifiedBy = userLogin;
                affiliateCampaign.LastModifiedDate = dateUtcNow;
                _context.AffiliateCampaigns.Update(affiliateCampaign);
                var res = await _context.SaveChangesAsync();

                if (res > 0)
                {
                    var dbCampaignProducts = _context.AffiliateCampaignProducts.Where(w => w.AffiliateCampaignId == affiliateCampaign.Id).ToList();

                    // get items need add new
                    var campaignProductsAdd = campaignProducts
                        .Where(w => !dbCampaignProducts.Any(a => a.AffiliateProductId == w.ProductId))
                        .Select(e => new AffiliateCampaignProduct
                        {
                            AffiliateCampaignId = affiliateCampaign.Id,
                            AffiliateProductId = e.ProductId,
                            CommissionPercent = e.CommissionPercent,
                            CommissionFix = e.CommissionFix,
                            CreatedDate = dateUtcNow,
                            CreatedBy = userLogin,
                            LastModifiedBy = userLogin,
                            LastModifiedDate = dateUtcNow,
                        });

                    // get items need remove
                    var productIds = campaignProducts.Select(s => s.ProductId).ToList();
                    var campaignProductsRemove = _context.AffiliateCampaignProducts
                        .Where(w => w.AffiliateCampaignId == affiliateCampaign.Id && !productIds.Any(productId => w.AffiliateProductId == productId)).ToList();

                    // get items need update. only update which items has change
                    var dbCampaignProductsNeedUpdate = dbCampaignProducts
                        .Where(w => campaignProducts.Any(a => w.AffiliateProductId == a.ProductId
                                                && (w.CommissionPercent != a.CommissionPercent || w.CommissionFix != a.CommissionFix)));

                    if (dbCampaignProductsNeedUpdate.Any())
                    {
                        foreach (var dbcampaignProduct in dbCampaignProductsNeedUpdate)
                        {
                            var campaignProduct = campaignProducts.FirstOrDefault(f => f.ProductId == dbcampaignProduct.AffiliateProductId);
                            dbcampaignProduct.CommissionPercent = campaignProduct.CommissionPercent;
                            dbcampaignProduct.CommissionFix = campaignProduct.CommissionFix;
                            dbcampaignProduct.LastModifiedBy = userLogin;
                            dbcampaignProduct.LastModifiedDate = dateUtcNow;
                        }

                        _context.AffiliateCampaignProducts.UpdateRange(dbCampaignProductsNeedUpdate);
                    }

                    if (campaignProductsAdd.Any())
                    {
                        await _context.AffiliateCampaignProducts.AddRangeAsync(campaignProductsAdd);
                    }

                    if (campaignProductsRemove.Any())
                    {
                        _context.AffiliateCampaignProducts.RemoveRange(campaignProductsRemove);
                    }

                    await _context.SaveChangesAsync();

                    dbContextTransaction.Commit();
                    return affiliateCampaign.Id;
                }
                else
                {
                    dbContextTransaction.Rollback();
                    return 0;
                }
            }
            catch
            {
                dbContextTransaction.Rollback(); //Required according to MSDN article 
                return 0;
            }
        }

        public bool CheckIsExitCampaignName(long? campaignId, long affiliateStoreId, string name)
        {
            try
            {
                name = name?.ToLower();
                var utcNow = DateTime.UtcNow;
                return _context.AffiliateCampaigns
                    .Any(a => a.Id != campaignId
                          && a.AffiliateStoreId == affiliateStoreId
                          && (a.Status == AffiliateCampaignStatus.DRAFT || (a.Status == AffiliateCampaignStatus.PUBLISHED && a.EndDate > utcNow))
                          && a.Name.ToLower() == name);
            }
            catch (Exception ex)
            {
                var a = ex.Message;
                return false;
            }
        }

        public async Task Delete(AffiliateCampaign affiliateCampaign)
        {
            _context.AffiliateCampaigns.Remove(affiliateCampaign);
            await _context.SaveChangesAsync();
        }
        public async Task<AffiliateCampaign> GetByIdAsync(long id)
        {
            return await _context.AffiliateCampaigns.FirstOrDefaultAsync(f => f.Id == id && f.IsDeleted != true);
        }

        public async Task<AffiliateCampaign> GetByIdAsync(long id, long affiliateStoreId)
        {
            return await _context.AffiliateCampaigns.FirstOrDefaultAsync(f => f.Id == id && f.AffiliateStoreId == affiliateStoreId && f.IsDeleted != true);
        }

        public async Task<AffiliateCampaignDetailViewModel> GetDetailViewModelByIdAsync(long id)
        {
            var utcNow = DateTime.UtcNow;
            var data = await _context.AffiliateCampaigns
                .Where(f => f.Id == id && f.IsDeleted != true)
                .Include(f => f.AffiliateCampaignProducts)
                .ThenInclude(f => f.AffiliateProduct)
                .Include(f => f.AffiliateStore)
                .ThenInclude(f => f.AffiliateStoreCurrency)
                .AsSingleQuery()
                .Select(s => new AffiliateCampaignDetailViewModel
                {
                    AffiliateStoreId = s.AffiliateStoreId,
                    Id = s.Id,
                    Name = s.Name,
                    StartDate = s.StartDate,
                    EndDate = s.EndDate,
                    Status = s.Status == AffiliateCampaignStatus.PUBLISHED && s.EndDate < utcNow ? AffiliateCampaignStatus.ENDED : s.Status,
                    AffiliateStoreCurrencySymbol = (s.AffiliateStore != null && s.AffiliateStore.AffiliateStoreCurrency != null) ? s.AffiliateStore.AffiliateStoreCurrency.Symbol : null,
                    AffiliateCampaignProducts = s.AffiliateCampaignProducts.Select(acp => new AffiliateCampaignProductViewModel
                    {
                        CampaignId = acp.AffiliateCampaignId,
                        Id = acp.Id,
                        CommissionFix = acp.CommissionFix,
                        CommissionPercent = acp.CommissionPercent,
                        ProductId = acp.AffiliateProductId,
                        IsOutOfStock = acp.AffiliateProduct.IsOutOfStock,
                        IsStopSelling = acp.AffiliateProduct.IsStopSelling,
                        IsDeleteProduct = acp.AffiliateProduct.IsDeleted ?? false,
                        ProductRefId = acp.AffiliateProduct.RefProductId,
                        ProductName = acp.AffiliateProduct.Name,
                        ProductImageUrl = acp.AffiliateProduct.ImageUrl,
                        RegularPrice = acp.AffiliateProduct.RegularPrice ?? 0,
                        SalePrice = acp.AffiliateProduct.SalePrice,
                        Status = acp.AffiliateProduct.IsDeleted == true ? 1 : (acp.AffiliateProduct.IsStopSelling == true ? 2 : (acp.AffiliateProduct.IsOutOfStock == true ? 3 : 4))
                    })
                }).FirstOrDefaultAsync();

            if (data != null && data.AffiliateCampaignProducts != null && data.AffiliateCampaignProducts.Any())
            {
                data.AffiliateCampaignProducts = data?.AffiliateCampaignProducts.OrderBy(o => o.Status);
            }

            return data;
        }

        public IQueryable<AffiliateCampaign> GetByStoreIdAsync(Expression<Func<AffiliateCampaign, bool>> filter)
        {
            var query = _context.AffiliateCampaigns.AsNoTracking();

            return filter != null ? query.Where(filter).AsQueryable() : query.AsQueryable();
        }

        public IQueryable<AffiliateCampaign> GetAsync(Expression<Func<AffiliateCampaign, bool>> filter)
        {
            var query = _context.AffiliateCampaigns.AsNoTracking();
            return filter != null ? query.Where(filter).AsQueryable() : query.AsQueryable();

        }
        public async Task<List<AffiliateCampaign>> GetByQueryAsync(Expression<Func<AffiliateCampaign, bool>> filter)
        {
            var query = _context.AffiliateCampaigns.AsNoTracking();
            return filter != null ? await query.Where(filter).ToListAsync() : await query.ToListAsync();

        }

        public async Task UpdateRangeAsync(List<AffiliateCampaign> affiliateCampaigns)
        {
            _context.AffiliateCampaigns.UpdateRange(affiliateCampaigns);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get Campaigns. Used only for commission calculation
        /// </summary>
        /// <param name="affiliateStoreId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public async Task<List<CampaignToCalculateCommissionModel>> GetCampaignsToCommissionCalculateAsync(long affiliateStoreId, DateTime fromDate, DateTime toDate)
        {
            // Only get items with status PUBLISHED, TERMINATED, ENDED
            var utcNow = DateTime.UtcNow;
            var data = await _context.AffiliateCampaigns
                .Where(f => f.AffiliateStoreId == affiliateStoreId
                         && f.IsDeleted != true
                         && f.StartDate <= toDate && f.EndDate >= fromDate
                         && (
                             (f.Status == AffiliateCampaignStatus.PUBLISHED && f.StartDate <= utcNow)
                          || (f.Status == AffiliateCampaignStatus.TERMINATED && fromDate <= f.TerminatedDate && f.StartDate < f.TerminatedDate)
                          || f.Status == AffiliateCampaignStatus.ENDED
                         )
                )
                .Include(f => f.AffiliateCampaignProducts)
                .ThenInclude(f => f.AffiliateProduct)
                .Select(s => new CampaignToCalculateCommissionModel
                {
                    AffiliateStoreId = s.AffiliateStoreId,
                    CampaignId = s.Id,
                    Name = s.Name,
                    StartDate = s.StartDate < fromDate ? fromDate : s.StartDate,
                    EndDate = s.Status == AffiliateCampaignStatus.TERMINATED ? (s.TerminatedDate > toDate ? toDate : s.TerminatedDate) : (s.EndDate > toDate ? toDate.AddDays(1).AddMicroseconds(-1) : s.EndDate),
                    Status = s.Status,
                    Products = s.AffiliateCampaignProducts.Select(acp => new AffiliateProductForCommissionModel
                    {
                        ProductId = acp.AffiliateProductId,
                        ProductRefId = acp.AffiliateProduct.RefProductId,
                        CommissionFix = acp.CommissionFix,
                        CommissionPercent = acp.CommissionPercent
                    })
                }).ToListAsync();

            return data;
        }

        /// <summary>
        /// Get Campaigns for publisher home page include products
        /// </summary>
        /// <param name="affiliateStoreId"></param>
        public async Task<List<CampaignsHappeningForPublisherIncludeProductModel>> GetCampaignsHappeningForPublisherIncludeProductAsync(GetCampaignsHappeningForPublisherIncludeProductQuery request)
        {
            var data = await GetCampaignsHappeningForPublisherAsync(request.AffiliateStoreId, size: 1, request.CampaignId);

            if (data.Count > 0)
            {
                var firstData = data.First();
                var affCampaign = new CampaignsHappeningForPublisherIncludeProductModel
                {
                    AffiliateStoreId = firstData.AffiliateStoreId,
                    CampaignId = firstData.CampaignId,
                    Name = firstData.Name,
                    StartDate = firstData.StartDate,
                    EndDate = firstData.EndDate,
                    Status = firstData.Status
                };

                var affiliateCampaignProducts = _context.AffiliateCampaignProducts
                    .Include(i => i.AffiliateProduct)
                    .Where(f => f.AffiliateCampaignId == affCampaign.CampaignId && f.AffiliateProduct.IsStopSelling == false && f.AffiliateProduct.IsDeleted != true);

                if (!string.IsNullOrWhiteSpace(request.Keyword))
                {
                    affiliateCampaignProducts = affiliateCampaignProducts.Where(x => x.AffiliateProduct.Name.Contains(request.Keyword));
                }
                affCampaign.Products = await affiliateCampaignProducts
                    .Select(s => new AffiliateProductForCampaignModel
                    {
                        Id = s.AffiliateProduct.Id,
                        Name = s.AffiliateProduct.Name,
                        RefProductId = s.AffiliateProduct.RefProductId,
                        CreatedDate = s.AffiliateProduct.CreatedDate,
                        ImageUrl = s.AffiliateProduct.ImageUrl,
                        IsOutOfStock = s.AffiliateProduct.IsOutOfStock,
                        IsStopSelling = s.AffiliateProduct.IsStopSelling,
                        ProductUrl = s.AffiliateProduct.ProductUrl,
                        RegularPrice = s.AffiliateProduct.RegularPrice,
                        SalePrice = s.AffiliateProduct.SalePrice,
                        FixValue = s.CommissionFix,
                        Percentage = s.CommissionPercent,
                        EarnValue = s.CommissionPercent / 100 * (s.AffiliateProduct.SalePrice > 0 ? s.AffiliateProduct.SalePrice.Value : (s.AffiliateProduct.RegularPrice ?? 0)) + s.CommissionFix,
                    })
                    .OrderByDescending(o => o.EarnValue)
                    .Take(10)
                    .ToListAsync();

                return [affCampaign];
            }

            return [];
        }

        /// <summary>
        /// Get Campaigns for publisher home page
        /// </summary>
        /// <param name="affiliateStoreId"></param>
        /// <returns></returns>
        public async Task<List<CampaignsHappeningForPublisherModel>> GetCampaignsHappeningForPublisherAsync(long affiliateStoreId, int size, long? campaignId = null)
        {
            // Only get items with status PUBLISHED
            var utcNow = DateTime.UtcNow;
            var query = _context.AffiliateCampaigns
                .Where(f => f.AffiliateStoreId == affiliateStoreId
                         && f.IsDeleted != true
                         && f.Status == AffiliateCampaignStatus.PUBLISHED
                         && f.EndDate > utcNow
                );

            if (campaignId != null)
            {
                query = query.Where(x => x.Id == campaignId);
            }

            var data = await query
                .Select(s => new CampaignsHappeningForPublisherModel
                {
                    AffiliateStoreId = s.AffiliateStoreId,
                    CampaignId = s.Id,
                    Name = s.Name,
                    StartDate = s.StartDate,
                    EndDate = s.EndDate,
                    Status = s.Status
                })
                .OrderBy(o => o.StartDate)
                .Take(size)
                .ToListAsync();

            return data;
        }

        public async Task<List<long>> GetProductIdsInCampaignAsync(long campaignId)
        {
            return await _context.AffiliateCampaignProducts
                    .Include(i => i.AffiliateProduct)
                    .Where(f => f.AffiliateCampaignId == campaignId && f.AffiliateProduct.IsDeleted != true)
                    .Select(s => s.AffiliateProductId)
                    .ToListAsync();
        }

        public async Task<int> CronJobUpdateAllExpriredCampaignAsync(long affiliateStoreId = 0)
        {
            var currentTime = DateTime.UtcNow;
            var res = await _context.AffiliateCampaigns.Where(x =>
                                        (affiliateStoreId > 0 ? x.AffiliateStoreId == affiliateStoreId : true)
                                        && x.EndDate < currentTime
                                        && x.Status == AffiliateCampaignStatus.PUBLISHED 
                                        && x.IsDeleted != true)
                                    .ExecuteUpdateAsync(x => x.SetProperty(v => v.Status, AffiliateCampaignStatus.ENDED)
                                    .SetProperty(v => v.LastModifiedDate, currentTime)
                                    .SetProperty(v => v.LastModifiedBy, AuthoritiesConstants.SYSTEM_USERNAME)
                                    );
            await _context.SaveChangesAsync();
            return res;
        }
    }
}
