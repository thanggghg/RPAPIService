using GoSell.API.Service;
using GoSell.Library.Utils;

namespace GoSell.API.Routes.Commission
{
    public static class BonusRouting
    {
        public static RouteGroupBuilder MapBonusApi(this RouteGroupBuilder app)
        {
            app.MapGet("/{bonusSettingId:long}", CommissionBonusApi.GetBonusCommissionSettingAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            //.AllowAnonymous()
            .WithTags("bonus");

            app.MapPost("/list", CommissionBonusApi.SearchBonusCommissionSettingAsync)
           .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
           //.AllowAnonymous()
           .WithTags("bonus");

            app.MapPost("/create", CommissionBonusApi.CreateBonusCommissionSettingAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            //.AllowAnonymous()
            .WithTags("bonus");

            app.MapPost("/publish", CommissionBonusApi.CreateAndPublishBonusCommissionSettingAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            //.AllowAnonymous()
            .WithTags("bonus");

            app.MapPost("/stop", CommissionBonusApi.StopBonusCommissionSettingAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            //.AllowAnonymous()
            .WithTags("bonus");

            app.MapDelete("/{bonusSettingId:long}/delete", CommissionBonusApi.DeleteBonusCommissionSettingAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            //.AllowAnonymous()
            .WithTags("bonus");

            app.MapPost("/getbypublisher", CommissionBonusApi.GetBonusByPublisherAnsync)
           .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
           //.AllowAnonymous()
           .WithTags("bonus");

            return app;
        }
    }
}
