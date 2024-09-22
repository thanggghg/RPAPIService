using System.Linq.Expressions;
using GoSell.Library.Db;

namespace GoSell.API.Infrastructure.Repositories.Comments
{
    public class BaseRepository<T>(BaseContext context) : IBaseRepository<T> where T : class
    {
        public Task<long> Count(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(T entity)
        {
            await context.AddAsync(entity);
        }

        public async Task CreateListAsync(List<T> entities)
        {
            await context.AddRangeAsync(entities);
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] propertySelectors)
        {
            var query = GetAll();

            if (propertySelectors is not null)
                foreach (var propertySelector in propertySelectors)
                    query = query.Include(propertySelector);

            return query;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] propertySelectors)
        {
            return GetAll(propertySelectors).Where(predicate);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await context.FindAsync<T>(id);
        }

        public Task<T> GetOneAsync(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate) ?? null;
        }

        public void Update(T entity)
        {
            context.Update(entity);
        }
        public IQueryable<T> BuildQuery(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }
        public async Task<List<T>> SearchAsync(IQueryable<T> query)
        {
            return await query.ToListAsync();
        }
        public async Task<long> CountAsync(IQueryable<T> query)
        {
            return await query.CountAsync();
        }

        public void Delete(T entity)
        {
            context.Remove(entity);
        }

        public void DeleteList(List<T> entities)
        {
            context.RemoveRange(entities);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
