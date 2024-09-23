
using RP.API.Routes.AccountRouting;

namespace RP.API.Routes
{
    public static class ApiRouting
    {
        public static void AddRegisterRoutes(this WebApplication app)
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

        public static void RegisterAccountAthenRouter(this WebApplication app)
        {

            app.MapGroup("/api/v1/authen")
               .MapRPAuthencationApi();
        }


    }
}
