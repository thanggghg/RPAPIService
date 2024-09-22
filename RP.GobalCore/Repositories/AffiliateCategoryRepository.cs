using System.Linq.Expressions;
using RP.Affiliate.Tracking.Database;
using RP.Affiliate.Tracking.Database.Entities;
using RP.Affiliate.Tracking.Repositories.Interfaces;
using RP.Library.Seedwork;
using Microsoft.EntityFrameworkCore;

namespace RP.Affiliate.Tracking.Repositories
{
    public class AffiliateCategoryRepository : IAffiliateCategoryRepository
    {
        private readonly AffiliateContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public AffiliateCategoryRepository(AffiliateContext context)
        {
            _context = context;
        }

        public async Task Add(AffiliateCategory affiliateCategory)
        {
            _context.AffiliateCategory.Add(affiliateCategory);
            await _context.SaveChangesAsync();
        }

        public async Task Update(AffiliateCategory affiliateCategory)
        {
            _context.AffiliateCategory.Update(affiliateCategory);
            await _context.SaveChangesAsync();
        }
        public async Task<AffiliateCategory> GetByIdAsync(long id, long affiliateStoreId)
        {
            var result = await _context.AffiliateCategory.FirstOrDefaultAsync(e => e.Id == id && e.AffiliateStoreId == affiliateStoreId &&  e.IsDeleted != true);
            return result;
        }

        public async Task<AffiliateCategory> GetByIdAsync(long id)
        {
            var result = await _context.AffiliateCategory.FirstOrDefaultAsync(e => e.Id == id && e.IsDeleted != true);
            return result;
        }

        public IQueryable<AffiliateCategory> GetAllAsync(Expression<Func<AffiliateCategory, bool>> filter)
        {
            var result = filter != null ?
                _context.AffiliateCategory.AsNoTracking().Where(filter).OrderBy(x => x.Name).AsQueryable() :
                _context.AffiliateCategory.AsNoTracking().OrderBy(x => x.Name).AsQueryable();

            return result;
        }

        public async Task<AffiliateCategory> GetByRefIdAsync(string refId, long affiliateStoreId, bool includeDelete = false)
        {
            if(includeDelete)
                return await _context.AffiliateCategory.FirstOrDefaultAsync(e => e.RefCategoryId.ToLower() == refId.ToLower() && e.AffiliateStoreId == affiliateStoreId);

            return await _context.AffiliateCategory.FirstOrDefaultAsync(e => e.RefCategoryId.ToLower() == refId.ToLower() && e.AffiliateStoreId == affiliateStoreId && e.IsDeleted != true);
        }

        public async Task<AffiliateCategory> GetByNameAsync(long storeId, string name)
        {
            return await _context.AffiliateCategory.FirstOrDefaultAsync(e => e.Name.ToLower() == name.ToLower() && e.AffiliateStoreId == storeId && e.IsDeleted != true);
        }

        public async Task<bool> InsertOrUpdateByBulkAsync(List<AffiliateCategory> affiliateCategorys, long affiliateStoreId)
        {
            try
            {
                var refCategoryIds = affiliateCategorys.Select(s => s.RefCategoryId).Distinct();
                var affCategorysUpdate = _context.AffiliateCategory.Where(w => w.AffiliateStoreId == affiliateStoreId && refCategoryIds.Contains(w.RefCategoryId));
                foreach(var categoryUpdate in affCategorysUpdate)
                {
                    categoryUpdate.Name = affiliateCategorys.LastOrDefault(f => f.RefCategoryId == categoryUpdate.RefCategoryId)?.Name;
                    categoryUpdate.IsDeleted = false;
                    categoryUpdate.Status = true;
                }

                var affCategoryUpdateRefIds = affCategorysUpdate.Select(s => s.RefCategoryId);
                var affCategorysAdd = affiliateCategorys.Where(w => !affCategoryUpdateRefIds.Contains(w.RefCategoryId));


                if (affCategorysUpdate.Any())
                {
                    _context.UpdateRange(affCategorysUpdate);
                }

                if (affCategorysAdd.Any())
                {
                    await _context.AddRangeAsync(affCategorysAdd);
                }     
                
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
