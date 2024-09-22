using RP.API.Routes;

namespace GoSell.API.Routes.AccountRouting
{
    public static class AccountRouting
    {
        public static void AddRegisterAccountRoutes(this WebApplication app)
        {
            app.RegisterDefault();
        }
        public static void RegisterDefault(this WebApplication app)
        {

            app.MapGet("/", async context =>
            {
                await context.Response.WriteAsync($"Welcome Go Sell .NET! Version: {typeof(RP.API.Routes.ApiRouting).Assembly.GetName().Version}");
            });
        }
    }
}
