using GoSell.Library.Extensions;

namespace GoSell.Library.Db
{
    public class BaseContextSeed : IDbSeeder<BaseContext>
    {
        public async Task SeedAsync(BaseContext context)
        {
            await context.SaveChangesAsync();
        }
    }
}
