using GoSell.API.Service;
using GoSell.Library.Utils;

namespace GoSell.API.Routes.Orders
{
    public static class OrdersRouting
    {
        public static RouteGroupBuilder MapOrdersApi(this RouteGroupBuilder app)
        {

            app.MapPut("/create", OrdersApi.CreateOrderAsync)
               .WithTags(SwaggerConstants.OrderAPI);

            app.MapGet("admin/{orderId:int}", OrdersApi.GetOrderAsync)
                //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.ADMIN)
                .WithTags(SwaggerConstants.OrderAPI);

            app.MapGet("store/{orderId:int}", OrdersApi.GetOrderAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.OrderAPI);

            app.MapGet("user/{orderId:int}", OrdersApi.GetOrderAsync)
                .WithTags(SwaggerConstants.OrderAPI);

            app.MapGet("{orderId:int}", OrdersApi.GetOrderAsync)
                .AddRequireAuthorizationJWTToken()
                .WithTags(SwaggerConstants.OrderAPI);
            return app;
        }
    }
}
