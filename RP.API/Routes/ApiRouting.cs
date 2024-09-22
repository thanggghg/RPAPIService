
namespace RP.API.Routes
{
    public static class ApiRouting
    {
        //public static RouteHandlerBuilder AddRequireAuthorizationJWTToken(this RouteHandlerBuilder builder, string Policy = "")
        //{
        //    return builder.RequireAuthorization(String.IsNullOrEmpty(Policy) ? AuthoritiesConstants.DEFAULT : Policy);
        //}
        //public static RouteHandlerBuilder AddStaffPermissionRequirementHandle(this RouteHandlerBuilder builder, string Policy = "")
        //{
        //    return builder.RequireAuthorization(Policy);
        //}
        //public static IEndpointConventionBuilder AddRequireAuthorizationJWTToken(this IEndpointConventionBuilder builder, string Policy = "")
        //{
        //    return builder.RequireAuthorization(String.IsNullOrEmpty(Policy) ? AuthoritiesConstants.DEFAULT : Policy);
        //}
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
      
    }
}
