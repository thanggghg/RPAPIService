using System.Linq.Expressions;

namespace GoSell.API.Infrastructure.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] propertySelectors);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] propertySelectors);
        Task<T> GetByIdAsync(long id);
        Task<T> GetOneAsync(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        Task<long> Count(Expression<Func<T, bool>> predicate);
        IQueryable<T> BuildQuery(Expression<Func<T, bool>> predicate);
        Task<List<T>> SearchAsync(IQueryable<T> query);
        Task<long> CountAsync(IQueryable<T> query);
        Task CreateListAsync(List<T> entities);
        void Delete(T entity);
        void DeleteList(List<T> entities);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
