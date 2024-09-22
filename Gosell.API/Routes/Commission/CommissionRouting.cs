using GoSell.API.Service;
using GoSell.Library.Utils;

namespace GoSell.API.Routes.Commission
{
    public static class CommissionRouting
    {
        public static RouteGroupBuilder MapCommissionApi(this RouteGroupBuilder app)
        {
            app.MapGet("/{commissionSettingId:long}", CommissionApi.GetCommissionSettingAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("commision");

            app.MapPost("get-commission-products", CommissionApi.GetCommissionProductAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("commision");

            app.MapPost("/list", CommissionApi.SearchCommissionSettingAsync)
           .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
           .WithTags("commision");

            app.MapPost("/create", CommissionApi.CreateCommissionSettingAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("commision");

            app.MapPost("/publish", CommissionApi.CreateAndPublishCommissionSettingAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("commision");

            app.MapPost("/stop", CommissionApi.StopCommissionSettingAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("commision");

            app.MapDelete("/{commissionSettingId:long}/delete", CommissionApi.DeleteCommissionSettingAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("commision");

            app.MapGet("/frequency/{storeId:long}", CommissionApi.GetCommissionFrequencySettingAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("commision");

            app.MapGet("/get-final-frequency-setting/{affiliateStoreId:long}", CommissionApi.GetFinalCommissionFrequencySettingAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("commision");

            app.MapPost("/frequency/search", CommissionApi.SearchCommissionFrequencySettingAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("commision");

            app.MapPost("/frequency/create-or-edit", CommissionApi.CreateOrEditCommissionFrequencySettingAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("commision");

            app.MapPost("/calculate", CommissionApi.CalculateCommissionAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("commision");

            app.MapPost("/commission-calculation/manual-calculate-commission", CommissionApi.ManualCalculateCommissionAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("commision");

            app.MapGet("/commission-calculation/manual-calculate-commission/{publisherId:long}/{affiliateStoreId:long}", CommissionApi.ManualCalculateCommissionByPublisherIdAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("commision");

            app.MapGet("/{storeId:long}/affiliate-group", CommissionApi.ListAffiliateGroupAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("commision");

            app.MapPost("/publisher", CommissionApi.GetCommissionSettingOfPublisherAsync)
           .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
           .WithTags("commision");

            app.MapPost("/get-default-settings", CommissionApi.GetDefaultCommissionSettingAsync)
           .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
           .WithTags("commision");

            app.MapPost("commission-calculation/{goSellStoreId:long}", CommissionCalculationApi.GetCommissionCalculationAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
            .WithTags("commision");

            app.MapPost("commission-calculation/update-status", CommissionCalculationApi.UpdateStatusCommissionCalculationAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
            .WithTags("commision");

            app.MapPost("commission-calculation/export/{type:alpha}/{goSellStoreId:long}", CommissionCalculationApi.ExportOrderCommissionReportAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
            .WithTags("commision");

            #region Report publisher page
            app.MapGet("/commission-report/summary", CommissionCalculationApi.GetComissionSummaryAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.AFFILIATE)
            .WithTags("commission");

            app.MapGet("/commission-report/chart", CommissionCalculationApi.GetCommissionOrderForChartAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.AFFILIATE)
            .WithTags("commission");

            app.MapGet("/commission-report/top-selling", CommissionCalculationApi.GetTopSellingProductByAffStoreIdAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.AFFILIATE)
            .WithTags(SwaggerConstants.AffiliateProductApi);

            #endregion

            app.MapPost("/commission-calculation/cronjob-commission-calculation", CommissionCalculationApi.RunCronJobCommissionCalculationAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("commision");

            app.MapPost("/cronjob-update-commission-expired", CommissionCalculationApi.CronJobUpdateCommisstionSettingExpiredAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("commision");

            return app;
        }
    }
}
