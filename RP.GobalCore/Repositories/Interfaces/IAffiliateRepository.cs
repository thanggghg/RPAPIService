using System.Linq.Expressions;
using RP.Affiliate.Tracking.Queries;
using RP.Affiliate.Tracking.ViewModels;
using RP.Library.Helpers.Pagination;
using RP.Library.Seedwork;
using Microsoft.EntityFrameworkCore.Query;

namespace RP.Affiliate.Tracking.Repositories
{
    public interface IAffiliateRepository<TEntity>
        where TEntity : class
    {
        IUnitOfWork UnitOfWork { get; }
        Task<TEntity> AddAsync(TEntity entity);
        void AddRange(List<TEntity> entities);
        TEntity Update(TEntity entity);
        Task<TEntity> GetByIdAsync<T>(T id);
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> filter,
                                   int skip = 0,
                                   int take = int.MaxValue,
                                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                   Expression<Func<TEntity, object>>[] includes = null,
                                   bool isTracking = false);
        void UpdateRange(List<TEntity> entities);
        Tuple<IQueryable<TEntity>, int> FilterAndTotalCount(Expression<Func<TEntity, bool>> filter,
                                          int skip = 0,
                                          int take = int.MaxValue,
                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                          bool isTracking = false);
        IQueryable<TEntity> BuildQuery(Expression<Func<TEntity, bool>> predicate);
    }
}
