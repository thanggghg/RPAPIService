using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace GoSell.Library.Db

{
    public class GenericDbContext<T> : IGenericDbContext<T> where T : BaseContext
    {
        private bool disposed = false;
        private readonly T _dbContext;

        public GenericDbContext(T dataContext)
        {
            _dbContext = dataContext;
        }
        public DatabaseFacade Database { get { return _dbContext.Database; } }

        public void DetachAllEntities()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                _dbContext.Dispose();
            }
            disposed = true;
        }
        public Dictionary<string, (int, int, int)> GetAddUpdateDeleteEntryCount()
        {
            throw new NotImplementedException();
        }

        public T GetContext()
        {
            return _dbContext;
        }

        public T GetContextScoped(IServiceScope serviceScope)
        {
            if (serviceScope != null)
            {
                return serviceScope.ServiceProvider.GetRequiredService<T>();
            }

            return GetContext();
        }
    }
}
