using RP.API.Routes;
using RP.Library.Utils;

namespace RP.API.Routes.AccountRouting
{
    public static class AccountRouting
    {
        public static RouteGroupBuilder MapRPAuthencationApi(this RouteGroupBuilder app)
        {
            app.MapPost("/sendOTPByPhoneNumber", AffiliateAuthenticationApi.AffiliateSendSMSOTPAsync)
                .WithTags(SwaggerConstants.RPAuthencation);

            //app.MapPost("/getuser-bylistusername", AffiliateAuthenticationApi.GetUserByListUserNamesAsync)
            //    .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            //    .WithTags(SwaggerConstants.AffiliateAuthencationApi);

            return app;
        }

    }
}
