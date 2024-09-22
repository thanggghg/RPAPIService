using GoSell.API.Service;
using GoSell.Library.Utils;

namespace GoSell.API.Routes.CommonHistory
{
    public static class CommonHistoryRouting
    {
        public static RouteGroupBuilder MapCommonHistoryApi(this RouteGroupBuilder app)
        {
            app.MapPost("/history-node-create", CommonHistoryApi.CreateHistoryNodeAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.CommonHistoryApi)
                .WithOpenApi()
                .DisableAntiforgery();

            app.MapPost("/history", CommonHistoryApi.GetHistoryAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.CommonHistoryApi)
                .WithOpenApi()
                .DisableAntiforgery();

            return app;
        }
    }
}
