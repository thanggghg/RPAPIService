using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace RP.Library.Db;
public interface IGenericDbContext<T> where T : DbContext
{
    DatabaseFacade Database { get; }
    void Dispose();
    T GetContext();
    Dictionary<string, (int, int, int)> GetAddUpdateDeleteEntryCount();
    /// <summary>
    /// Get instance of dbcontext in a serviceScope identified by type of 'T'.
    /// </summary>
    T GetContextScoped(IServiceScope serviceScope);
    /// <summary>
    /// Detach all entities in data context
    /// </summary>
    void DetachAllEntities();
}

