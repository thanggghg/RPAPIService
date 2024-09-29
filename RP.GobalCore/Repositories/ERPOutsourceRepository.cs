using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RP.GobalCore.Database;
using RP.GobalCore.Repositories.Interfaces;
using RP.Library.Seedwork;

namespace RP.GobalCore.Repositories
{
    public class ERPOutsourceRepository<TEntity> : IERPOutsourceRepository<TEntity>
        where TEntity : class
    {
        public readonly ERPOutsourceContext _dbContext;
        public IUnitOfWork UnitOfWork => (IUnitOfWork)_dbContext;

        public ERPOutsourceRepository(ERPOutsourceContext dbContext)
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
            int count =  _dbContext.Set<TEntity>().Count();
            var b = _dbContext.Set<TEntity>().Skip(1).Take(1);
            query = filter != null ? query.AsQueryable() : query.AsQueryable();

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

            return b.AsQueryable();
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
