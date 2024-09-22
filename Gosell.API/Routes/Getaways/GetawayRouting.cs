using GoSell.API.Service;
using GoSell.Library.Utils;

namespace GoSell.API.Routes.Getaways
{
    public static class GetawayRouting
    {
        public static RouteGroupBuilder MapGetawayRouting(this RouteGroupBuilder app)
        {
            app.MapPost("create-user-by-phone-number", GetwayServiceApi.CreateUserByPhoneNumberAsync)
                .AddRequireAuthorizationJWTToken()
                .WithTags(SwaggerConstants.SocialStoreTitle);

            app.MapGet("get-oauth-client-detail/{clientId:alpha}", GetwayServiceApi.GetOauthClientDetailByClientIdAsync)
                .AddRequireAuthorizationJWTToken()
                .WithTags(SwaggerConstants.SocialStoreTitle);

            app.MapGet("get-user/{id:long}", GetwayServiceApi.GetUserByIdAsync)
                .AddRequireAuthorizationJWTToken()
                .WithTags(SwaggerConstants.SocialStoreTitle);

            app.MapGet("get-user-by-login/{login}", GetwayServiceApi.GetUserByLoginAsync)
                .AddRequireAuthorizationJWTToken()
                .WithTags(SwaggerConstants.SocialStoreTitle);

            app.MapPost("get-user-list-by-logins", GetwayServiceApi.GetUsersByLoginsAsync)
               .AddRequireAuthorizationJWTToken()
               .WithTags(SwaggerConstants.SocialStoreTitle);

            app.MapPost("get-user-by-phone-number", GetwayServiceApi.GetUserByPhoneNumberAsync)
                .AddRequireAuthorizationJWTToken()
                .WithTags(SwaggerConstants.SocialStoreTitle);

            app.MapPost("get-users", GetwayServiceApi.GetUsersAsync)
                .AddRequireAuthorizationJWTToken()
                .WithTags(SwaggerConstants.SocialStoreTitle);

            return app;
        }
    }
}
