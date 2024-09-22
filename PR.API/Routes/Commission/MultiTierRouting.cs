using GoSell.API.Service;
using GoSell.Library.Utils;

namespace GoSell.API.Routes.Commission
{
    public static class MultiTierRouting
    {
        public static RouteGroupBuilder MapMultiTierApi(this RouteGroupBuilder app)
        {
            app.MapGet("/{multiTierSettingId:long}", CommissionMultiTierApi.GetMultiTierCommissionSettingAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("MultiTier");

            app.MapPost("/list", CommissionMultiTierApi.SearchMultiTierCommissionSettingAsync)
           .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
           .WithTags("MultiTier");

            app.MapPost("/create", CommissionMultiTierApi.CreateMultiTierCommissionSettingAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("MultiTier");

            app.MapPost("/edit", CommissionMultiTierApi.EditMultiTierCommissionSettingAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("MultiTier");

            app.MapPost("/publish", CommissionMultiTierApi.CreateAndPublishMultiTierCommissionSettingAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("MultiTier");

            app.MapPost("/stop", CommissionMultiTierApi.StopMultiTierCommissionSettingAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("MultiTier");

            app.MapGet("/multi-traces", CommissionMultiTierApi.GetMultiTracesAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("MultiTier");

            app.MapDelete("/{multiTierSettingId:long}/delete", CommissionMultiTierApi.DeleteMultiTierCommissionSettingAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("MultiTier");

            app.MapPost("/calculate-multitier", CommissionApi.CalculateMultitierCommissionAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("MultiTier");

            app.MapPost("/cronjob-calculate-multitier", CommissionApi.CronJobCalculateMultitierCommissionAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("MultiTier");

            app.MapPost("/cronjob-update-multitiersetting-expired", CommissionApi.CronJobUpdateMultitierSettingExpiredAsync)
           .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
           .WithTags("MultiTier");

            return app;
        }
    }
}
