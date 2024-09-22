using System.Linq.Expressions;
using EFCore.BulkExtensions;
using RP.Affiliate.Tracking.Commons.Constants;
using RP.Affiliate.Tracking.Database;
using RP.Affiliate.Tracking.Entities;
using RP.Affiliate.Tracking.Queries.AffiliateProduct;
using RP.Affiliate.Tracking.Repositories.Interfaces;
using RP.Affiliate.Tracking.ViewModels;
using RP.Library.Helpers.Pagination;
using RP.Library.Seedwork;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace RP.Affiliate.Tracking.Repositories
{
    public class AffiliateProductRepository : IAffiliateProductRepository
    {
        private readonly AffiliateContext _context;
        public IUnitOfWork UnitOfWork => _context;

        private readonly int BATCH_SIZE = 4000;
        public AffiliateProductRepository(AffiliateContext context)
        {
            _context = context;
        }

        public async Task Add(AffiliateProduct affiliateProduct)
        {
            _context.AffiliateProducts.Add(affiliateProduct);
            await _context.SaveChangesAsync();
        }

        public async Task Update(AffiliateProduct affiliateProduct)
        {
            _context.AffiliateProducts.Update(affiliateProduct);
            await _context.SaveChangesAsync();
        }
        public async Task<AffiliateProduct> GetByIdAsync(long id, long affiliateStoreId)
        {
            return await _context.AffiliateProducts.FirstOrDefaultAsync(e => e.Id == id && e.AffiliateStoreId == affiliateStoreId && e.IsDeleted != true);
        }

        public async Task<AffiliateProduct> GetByIdAsync(long id)
        {
            return await _context.AffiliateProducts.FirstOrDefaultAsync(e => e.Id == id && e.IsDeleted != true);
        }

        public async Task<AffiliateProduct> GetByRefIdAsync(string refProductId)
        {
            return await _context.AffiliateProducts.FirstOrDefaultAsync(e => e.RefProductId.ToLower() == refProductId.ToLower() && e.IsDeleted != true);
        }

        public async Task<AffiliateProduct> GetByRefIdWithAffiliateStoreIdAsync(string refProductId, long affiliateStoreId)
        {
            return await _context.AffiliateProducts.FirstOrDefaultAsync(e => e.RefProductId == refProductId && e.AffiliateStoreId == affiliateStoreId && e.IsDeleted != true);
        }

        public IQueryable<AffiliateProduct> GetByRefIdsWithAffiliateStoreIdAsync(List<string> refProductIds, long affiliateStoreId)
        {
            return _context.AffiliateProducts.Where(e => refProductIds.Contains(e.RefProductId) && e.AffiliateStoreId == affiliateStoreId && e.IsDeleted != true);
        }

        public async Task<bool> InsertOrUpdateByBulkAsync(List<AffiliateProduct> affiliateProducts, long affiliateStoreId)
        {
            try
            {
                var affiliateProductRefIds = affiliateProducts
                    .Select(x => x.RefProductId)
                    .ToList();

                var existsAffiliateProducts = await _context.AffiliateProducts
                .AsNoTracking()
                    .Where(x => affiliateProductRefIds.Contains(x.RefProductId) && x.AffiliateStoreId == affiliateStoreId)
                    .ToListAsync();

                var existsAffiliateProductIds = existsAffiliateProducts
                    .Select(x => x.RefProductId)
                    .ToList();

                var newAffiliateProducts = affiliateProducts.Where(x => !existsAffiliateProductIds.Contains(x.RefProductId));

                var updatedData = existsAffiliateProducts.Select(item =>
                {
                    var updatedItem = affiliateProducts.FirstOrDefault(x => x.RefProductId == item.RefProductId);
                    item.Name = updatedItem.Name;
                    //item.Description = updatedItem.Description;
                    item.CategoryId = updatedItem.CategoryId;
                    item.RegularPrice = updatedItem.RegularPrice;
                    item.SalePrice = updatedItem.SalePrice;
                    item.ProductUrl = updatedItem.ProductUrl;
                    item.ImageUrl = updatedItem.ImageUrl;
                    item.IsDeleted = false;

                    return item;
                });

                var bulkConfig = new BulkConfig { SetOutputIdentity = true, BatchSize = BATCH_SIZE, PropertiesToExcludeOnCompare = [nameof(AffiliateProduct.CreatedDate), nameof(AffiliateProduct.LastModifiedDate)] };

                if (updatedData.Any())
                    await _context.BulkUpdateAsync(updatedData, bulkConfig);

                if (newAffiliateProducts.Any())
                    await _context.BulkInsertAsync(newAffiliateProducts, bulkConfig);

                await _context.BulkSaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<AffiliateProduct> GetByStoreIdAsync(Expression<Func<AffiliateProduct, bool>> filter)
        {
            var query = _context.AffiliateProducts
                .Where(x => x.IsDeleted != true)
                .OrderBy(x => x.IsStopSelling)
                .ThenBy(x => x.IsOutOfStock)
                .ThenBy(x => x.Name)
                .AsNoTracking();

            return filter != null ? query.Where(filter).AsQueryable() : query.AsQueryable();
        }

        public IQueryable<AffiliateProduct> GetAll(Expression<Func<AffiliateProduct, bool>> predicate = null)
        {
            var query = _context.AffiliateProducts.Where(x => x.IsDeleted.Value == false);
            if (predicate != null)
            {
                query.Where(predicate);
            }
            return query;
        }

        public IQueryable<AffiliateProduct> GetAsync(Expression<Func<AffiliateProduct, bool>> filter)
        {
            var query = _context.AffiliateProducts
            .Where(x => x.IsDeleted != true);

            var resFilter = filter != null ? query.Where(filter) : query;

            resFilter = resFilter
            .OrderBy(x => x.IsStopSelling)
            .ThenBy(x => x.IsOutOfStock)
            .ThenBy(x => x.Name);

            return filter != null ? query.Where(filter).AsQueryable() : query.AsQueryable();
        }

        public IQueryable<AffiliateProduct> GetProductAPIAsync(Expression<Func<AffiliateProduct, bool>> filter)
        {
            var resFilter = filter != null ? _context.AffiliateProducts.Where(filter) : _context.AffiliateProducts;
            resFilter = resFilter
            .OrderBy(x => x.IsStopSelling)
            .ThenBy(x => x.IsOutOfStock)
            .ThenBy(x => x.Name);

            return filter != null ? _context.AffiliateProducts.Where(filter).Include(x => x.AffiliateCategory)
             .AsQueryable() : _context.AffiliateProducts.Include(x => x.AffiliateCategory).AsQueryable();
        }
        public async Task<List<AffiliateProduct>> GetByQueryAsync(Expression<Func<AffiliateProduct, bool>> filter)
        {
            var query = _context.AffiliateProducts
            .Where(x => x.IsDeleted != true);

            var resFilter = filter != null ? query.Where(filter) : query;

            resFilter = resFilter
            .OrderBy(x => x.IsStopSelling)
            .ThenBy(x => x.IsOutOfStock)
            .ThenBy(x => x.Name);

            return filter != null ? await query.Where(filter).ToListAsync() : await query.ToListAsync();
        }

        public async Task<PagingItems<AffiliateProduct>> GetProducNotCampaignQuery(GetAffiliateProductViewPublisherQuery request)
        {
            var predicate = PredicateBuilder.New<AffiliateProduct>(x => x.IsDeleted != true && x.AffiliateStoreId == request.AffiliateStoreId);

            if (request.CategoryId != null && request.CategoryId > 0)
            {
                predicate.And(x => x.CategoryId == request.CategoryId);
            }

            if (!string.IsNullOrEmpty(request.Status) && request.Status != AffiliateProductStatusSearchType.ALL)
            {
                switch (request.Status)
                {
                    case AffiliateProductStatusSearchType.SELLING:
                        predicate.And(x => x.IsStopSelling == false && x.IsOutOfStock == false);
                        break;
                    case AffiliateProductStatusSearchType.OUT_OF_STOCK:
                        predicate.And(x => x.IsStopSelling == false && x.IsOutOfStock == true);
                        break;
                    default:
                        break;
                }
            }
            else  // get all item is selling
            {
                predicate.And(x => x.IsStopSelling == false);
            }

            request.Keyword = request.Keyword?.ToLower();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                predicate.And(x => x.Name.ToLower().Contains(request.Keyword));
            }

            var query = _context.AffiliateProducts.Where(predicate);

            if (string.IsNullOrEmpty(request.LinkRefId))
            {
                query = query
                .OrderBy(x => x.IsStopSelling)
                .ThenBy(x => x.IsOutOfStock)
                // todo thenby Campaign: Show product(s) with ongoing campaign at first
                // todo thenby Commission: Commission(%): High → Low → Blank | Commission(Fix): High → Low → Blank
                .ThenBy(x => x.Name);
            }
            else
            {
                query = query.OrderBy(x => x.RefProductId != request.LinkRefId ? 1 : 0)
                .ThenBy(x => x.IsStopSelling)
                .ThenBy(x => x.IsOutOfStock)
                // todo thenby Campaign: Show product(s) with ongoing campaign at first
                // todo thenby Commission: Commission(%): High → Low → Blank | Commission(Fix): High → Low → Blank
                .ThenBy(x => x.Name);
            }

            var affiliateProducts = await query.PaginatedListAsync(request.PageSize.Value, request.PageNumber.Value, request.IsPaging);
            return affiliateProducts;
        }

        public async Task<PagingItems<AffiliateProductViewModel>> GetProductWithCampaignQuery(GetAffiliateProductViewPublisherQuery request)
        {
            var predicate = PredicateBuilder.New<AffiliateCampaignProduct>
                (x => x.AffiliateProduct.IsDeleted != true &&
                 x.AffiliateProduct.AffiliateStoreId == request.AffiliateStoreId &&
                 x.AffiliateCampaignId == request.CampaignId);

            if (request.CategoryId != null && request.CategoryId > 0)
            {
                predicate.And(x => x.AffiliateProduct.CategoryId == request.CategoryId);
            }

            if (!string.IsNullOrEmpty(request.Status) && request.Status != AffiliateProductStatusSearchType.ALL)
            {
                switch (request.Status)
                {
                    case AffiliateProductStatusSearchType.SELLING:
                        predicate.And(x => x.AffiliateProduct.IsStopSelling == false && x.AffiliateProduct.IsOutOfStock == false);
                        break;
                    case AffiliateProductStatusSearchType.OUT_OF_STOCK:
                        predicate.And(x => x.AffiliateProduct.IsStopSelling == false && x.AffiliateProduct.IsOutOfStock == true);
                        break;
                    default:
                        break;
                }
            }
            else  // get all item is selling
            {
                predicate.And(x => x.AffiliateProduct.IsStopSelling == false);
            }

            request.Keyword = request.Keyword?.ToLower();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                predicate.And(x => x.AffiliateProduct.Name.ToLower().Contains(request.Keyword));
            }

            var query = _context.AffiliateCampaignProducts
                    .Include(i => i.AffiliateProduct)
                    .Include(i => i.AffiliateCampaign)
                    .Where(predicate);
            var dataQuery = query.Select(s => new AffiliateProductViewModel
            {
                Id = s.AffiliateProduct.Id,
                Name = s.AffiliateProduct.Name,
                RefProductId = s.AffiliateProduct.RefProductId,
                CreatedDate = s.AffiliateProduct.CreatedDate.Value,
                ImageUrl = s.AffiliateProduct.ImageUrl,
                IsOutOfStock = s.AffiliateProduct.IsOutOfStock,
                IsStopSelling = s.AffiliateProduct.IsStopSelling,
                ProductUrl = s.AffiliateProduct.ProductUrl,
                RegularPrice = s.AffiliateProduct.RegularPrice,
                SalePrice = s.AffiliateProduct.SalePrice,
                FixValue = s.CommissionFix > 0 ? s.CommissionFix : s.AffiliateProduct.FixValue,
                Percentage = s.CommissionPercent > 0 ? s.CommissionPercent : s.AffiliateProduct.Percentage,
                EarnValue = s.CommissionPercent / 100 * (s.AffiliateProduct.SalePrice > 0 ? s.AffiliateProduct.SalePrice.Value : (s.AffiliateProduct.RegularPrice ?? 0)) + s.CommissionFix,
                IsShowLink = s.AffiliateCampaign.StartDate < DateTime.Now
            })
            .OrderByDescending(o => o.EarnValue)
            .ThenBy(x => x.IsStopSelling)
            .ThenBy(x => x.IsOutOfStock)
            .ThenBy(x => x.Name);

            var affiliateProducts = await dataQuery.PaginatedListAsync(request.PageSize.Value, request.PageNumber.Value, request.IsPaging);

            return affiliateProducts;
        }

        public IQueryable<AffiliateProduct> GetProductByIds(List<long> productIds)
        {
            productIds = productIds.Distinct().ToList();
            return _context.AffiliateProducts.Where(e => productIds.Contains(e.Id) && e.IsDeleted != true);
        }

        public async Task<int> UpdateMultipleAffiliateProduct(IQueryable<AffiliateProduct> affiliateProducts)
        {
            _context.UpdateRange(affiliateProducts);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateMultipleAffiliateProduct(long storeId, List<long> productIds, string actionType, string userLogin)
        {
            productIds = productIds.Distinct().ToList();
            var products = _context.AffiliateProducts.Where(e => productIds.Contains(e.Id) && e.IsDeleted != true);
            if (products.Any())
            {
                if (actionType == UpdateProductActionType.DeleteMultipleProduct)
                {
                    foreach (var item in products)
                    {
                        item.IsDeleted = true;
                        item.LastModifiedBy = userLogin;
                    }
                }
                else if (actionType == UpdateProductActionType.SetInStock || actionType == UpdateProductActionType.SetOutOfStock)
                {
                    foreach (var item in products)
                    {
                        item.IsOutOfStock = actionType == UpdateProductActionType.SetOutOfStock;
                        item.LastModifiedBy = userLogin;
                    }
                }
                else if (actionType == UpdateProductActionType.SetSelling || actionType == UpdateProductActionType.SetStopSelling)
                {
                    foreach (var item in products)
                    {
                        item.IsStopSelling = actionType == UpdateProductActionType.SetStopSelling;
                        item.LastModifiedBy = userLogin;
                    }
                }

                return await _context.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<AffiliateProduct> GetDeletedAffProductByRefIdAsync(string refProductId, long affiliateStoreId)
        {
            return await _context.AffiliateProducts.FirstOrDefaultAsync(e => e.RefProductId == refProductId && e.AffiliateStoreId == affiliateStoreId && e.IsDeleted == true);
        }
        public async Task<AffiliateProduct> GetAffProductByRefIdAsync(string refProductId, long affiliateStoreId)
        {
            return await _context.AffiliateProducts.FirstOrDefaultAsync(e => e.RefProductId == refProductId && e.AffiliateStoreId == affiliateStoreId && e.IsDeleted != true);
        }
        public IQueryable<AffiliateProduct> GetByCategoryAsync(long categoryId)
        {
            return _context.AffiliateProducts.Where(e => e.CategoryId == categoryId && e.IsDeleted == true);
        }

        public async Task<PagingItems<AffiliateProductAddCampaignViewModel>> GetProductsAddCampaignAsync(GetProductsAddCampaignQuery request)
        {
            var query = _context.AffiliateProducts
                .Where(w => w.AffiliateStoreId == request.AffiliateStoreId && w.IsStopSelling == false && w.IsOutOfStock == false && w.IsDeleted != true);


            // filter if any
            var keyword = request.Keyword?.Trim().ToLower();
            if (!string.IsNullOrEmpty(keyword))
            {
                if (request.SearchType == AffiliateProductCampaignSearchType.ProductName)
                    query = query.Where(w => w.Name.ToLower().Contains(keyword));

                if (request.SearchType == AffiliateProductCampaignSearchType.ProductRefId)
                    query = query.Where(w => w.RefProductId.ToLower().Contains(keyword));

                if (request.SearchType == AffiliateProductCampaignSearchType.CategoryName)
                {
                    var categoryIds = _context.AffiliateCategory
                        .Where(w => w.Name.ToLower().Contains(keyword)).Select(s => s.Id).ToList();

                    if (categoryIds.Count == 0)
                    {
                        return new PagingItems<AffiliateProductAddCampaignViewModel>
                        {
                            Items = [],
                            PagingInfo = new PagingInfo
                            {
                                PageNumber = request.PageNumber ?? 0,
                                PageSize = request.PageSize ?? 20,
                                TotalItems = 0
                            }
                        };
                    }

                    query = query.Where(w => w.CategoryId.HasValue && categoryIds.Contains(w.CategoryId.Value));
                }
            }

            // sort
            query = query.OrderBy(o => o.Name);

            var data = query.Select(s => new AffiliateProductAddCampaignViewModel
            {
                Id = s.Id,
                Name = s.Name,
                ImageUrl = s.ImageUrl,
                RefProductId = s.RefProductId,
                RegularPrice = s.RegularPrice ?? 0,
                SalePrice = s.SalePrice
            });

            // paging
            return await data.PaginatedListAsync(request.PageSize.Value, request.PageNumber.Value, request.IsPaging);
        }
    }
}
