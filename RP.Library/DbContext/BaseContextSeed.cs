using RP.Library.Extensions;

namespace RP.Library.Db
{
    public class BaseContextSeed : IDbSeeder<BaseContext>
    {
        public async Task SeedAsync(BaseContext context)
        {
            await context.SaveChangesAsync();
        }
    }
}
