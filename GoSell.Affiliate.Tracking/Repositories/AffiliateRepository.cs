using System.Linq.Expressions;
using GoSell.Affiliate.Tracking.Database;
using GoSell.Library.Seedwork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace GoSell.Affiliate.Tracking.Repositories
{
    public class AffiliateRepository<TEntity> : IAffiliateRepository<TEntity>
        where TEntity : class
    {
        public readonly AffiliateContext _dbContext;
        public IUnitOfWork UnitOfWork => (IUnitOfWork)_dbContext;

        public AffiliateRepository(AffiliateContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.AddAsync<TEntity>(entity);
            return entity;
        }

        public void AddRange(List<TEntity> entities)
        {
            _dbContext.AddRange(entities);
        }

        public TEntity Update(TEntity entity)
        {
            return _dbContext.Update(entity).Entity;
        }

        public void UpdateRange(List<TEntity> entities)
        {
            _dbContext.UpdateRange(entities);
        }

        public async Task<TEntity> GetByIdAsync<T>(T id)
        {
            var entities = await _dbContext.FindAsync<TEntity>(id);
            return entities;
        }

        public IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> filter,
                                          int skip = 0,
                                          int take = int.MaxValue,
                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                          Expression<Func<TEntity, object>>[] includes = null,
                                          bool isTracking = false)
        {
            var query = isTracking ? _dbContext.Set<TEntity>() : _dbContext.Set<TEntity>().AsNoTracking();

            query = filter != null ? query.Where(filter).AsQueryable() : query.AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }
            if (orderBy != null)
            {
                query = orderBy(query).AsQueryable();
            }
            query = skip == 0 ? query.Take(take) : query.Skip(skip).Take(take);

            return query.AsQueryable();
        }

        public Tuple<IQueryable<TEntity>, int> FilterAndTotalCount(Expression<Func<TEntity, bool>> filter,
                                          int skip = 0,
                                          int take = int.MaxValue,
                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                          bool isTracking = false)
        {
            var query = isTracking ? _dbContext.Set<TEntity>() : _dbContext.Set<TEntity>().AsNoTracking();

            query = filter != null ? query.Where(filter).AsQueryable() : query.AsQueryable();

            if (include != null)
            {
                query = include(query);
            }
            if (orderBy != null)
            {
                query = orderBy(query).AsQueryable();
            }

            var totalCount = query.Count();
            query = skip == 0 ? query.Take(take) : query.Skip(skip).Take(take);

            return new Tuple<IQueryable<TEntity>, int>(query.AsQueryable(), totalCount);
        }

        public IQueryable<TEntity> BuildQuery(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }
    }
}
