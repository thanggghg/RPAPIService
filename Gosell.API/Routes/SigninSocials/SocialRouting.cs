using GoSell.API.Service;
using GoSell.Library.Utils;
namespace GoSell.API.Routes.SocialSignin
{
    public static class SocialSigninRouting
    {
        public static RouteGroupBuilder MapSocialSigninRouting(this RouteGroupBuilder app)
        {
            app.MapPost("/social/{type:alpha}/{providerId:alpha}", SigninSocialApiService.SignInSocialAsync)
                .WithTags(SwaggerConstants.SocialStoreTitle);

            return app;
        }
    }
}
