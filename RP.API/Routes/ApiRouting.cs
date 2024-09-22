
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

        public static RouteGroupBuilder MapAffiliateAuthencationApi(this RouteGroupBuilder app)
        {
            app.MapPost("/sendOTPByPhoneNumber", AffiliateAuthenticationApi.AffiliateSendSMSOTPAsync)
                .WithTags(SwaggerConstants.AffiliateAuthencationApi);

            app.MapPost("/signin", AffiliateAuthenticationApi.AffiliateSigninAsync)
               .WithTags(SwaggerConstants.AffiliateAuthencationApi);

            app.MapPost("/signup", AffiliateAuthenticationApi.AffiliateSignupAsync)
                .WithTags(SwaggerConstants.AffiliateAuthencationApi);

            app.MapPost("/verifyOtp", AffiliateAuthenticationApi.VerifyOtpAsync)
                .WithTags(SwaggerConstants.AffiliateAuthencationApi);

            app.MapPost("/resetPassword", AffiliateAuthenticationApi.AffiliateForgotPassword)
                .WithTags(SwaggerConstants.AffiliateAuthencationApi);

            app.MapGet("/getUserProfile", AffiliateAuthenticationApi.GetUserProfileByIdAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.AFFILIATE_PROFILE)
                .WithTags(SwaggerConstants.AffiliateAuthencationApi);

            app.MapPost("/updateUserProfile", AffiliateAuthenticationApi.UpdateUserProfileAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.AFFILIATE_PROFILE)
                .WithTags(SwaggerConstants.AffiliateAuthencationApi);

            app.MapPost("/changePassword", AffiliateAuthenticationApi.ChangePasswordAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.AFFILIATE_PROFILE)
               .WithTags(SwaggerConstants.AffiliateAuthencationApi);

            app.MapPost("/uploadAvatar", AffiliateAuthenticationApi.UploadAvatarAsync)
              .AddRequireAuthorizationJWTToken(AuthoritiesConstants.AFFILIATE_PROFILE)
              .WithTags(SwaggerConstants.AffiliateAuthencationApi);

            app.MapPost("/refreshToken", AffiliateAuthenticationApi.RefreshTokenAsync)
            .WithTags(SwaggerConstants.AffiliateAuthencationApi);

            app.MapPost("/social/{type}/{providerId}", AffiliateAuthenticationApi.SocialAuthenAsync)
                .WithTags(SwaggerConstants.AffiliateAuthencationApi);

            app.MapPost("/social/signup", AffiliateAuthenticationApi.SocialVerifyOtpSignupAsync)
                .WithTags(SwaggerConstants.AffiliateAuthencationApi);

            app.MapGet("/social/redirectUrl/{provider:alpha}", AffiliateAuthenticationApi.GetSocialRedirectUrlAsync)
                .WithTags(SwaggerConstants.AffiliateAuthencationApi);

            app.MapGet("/social/google/authen-callback", AffiliateAuthenticationApi.GoogleAuthenCallbackAsync)
                .WithTags(SwaggerConstants.AffiliateAuthencationApi);

            app.MapGet("/social/apple/authen-callback", AffiliateAuthenticationApi.AppleAuthenCallbackAsync)
                .WithTags(SwaggerConstants.AffiliateAuthencationApi);

            app.MapGet("/social/facebook/authen-callback", AffiliateAuthenticationApi.FacebookAuthenCallbackAsync)
                .WithTags(SwaggerConstants.AffiliateAuthencationApi);

            app.MapPost("/getuser-bylistusername", AffiliateAuthenticationApi.GetUserByListUserNamesAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.AffiliateAuthencationApi);

            return app;
        }

    }
}
