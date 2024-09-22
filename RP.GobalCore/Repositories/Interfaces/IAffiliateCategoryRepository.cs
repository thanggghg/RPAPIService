using System.Linq.Expressions;
using RP.Affiliate.Tracking.Database.Entities;
using RP.Library.Seedwork;

namespace RP.Affiliate.Tracking.Repositories.Interfaces
{
    public interface IAffiliateCategoryRepository : IRepository<AffiliateCategory>
    {
        Task Add(AffiliateCategory affiliateCategory);

        Task Update(AffiliateCategory affiliateCategory);
        Task<AffiliateCategory> GetByIdAsync(long id, long affiliatetStoreId);

        Task<AffiliateCategory> GetByIdAsync(long id);
        IQueryable<AffiliateCategory> GetAllAsync(Expression<Func<AffiliateCategory, bool>> filter);
        Task<AffiliateCategory> GetByNameAsync(long affiliatetStoreId, string name);
        Task<AffiliateCategory> GetByRefIdAsync(string refId, long affiliatetStoreId, bool includeDelete = false);
        Task<bool> InsertOrUpdateByBulkAsync(List<AffiliateCategory> affiliateCategorys, long affiliateStoreId);
    }
}
