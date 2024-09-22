using GoSell.API.Service;

namespace GoSell.API.Routes.Analysis;

public static class AnalysisRouting
{
    public static RouteGroupBuilder MapAnalysisApi(this RouteGroupBuilder app)
    {
        app.MapPost("/sale-performance", AnalysisApi.SearchAnalysisChartAsync)
            //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .AllowAnonymous()
            .WithTags("analysis");
        app.MapPost("/best-product", AnalysisApi.SearchAnalysisChartAsync)
            //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("analysis");
        app.MapPost("/unit-returned", AnalysisApi.SearchAnalysisChartAsync)
            //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("analysis");
        app.MapPost("/remaining-stock", AnalysisApi.SearchAnalysisChartAsync)
            //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("analysis");
        app.MapPost("/product-performance", AnalysisApi.SearchAnalysisChartAsync)
            //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("analysis");
        app.MapPost("/frequency-inventory", AnalysisApi.SearchAnalysisChartAsync)
            //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("analysis");
        app.MapPost("/analyst-metric", AnalysisApi.SearchAnalystMetricAsync)
            //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("analysis");
        app.MapPost("/analyst-top-best-sell", AnalysisApi.SearchAnalystTopBestSellAsync)
            //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("analysis");
        app.MapPost("/analyst-top-most-viewed", AnalysisApi.SearchAnalystTopMostViewedAsync)
            //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("analysis");
        app.MapPost("/analyst-top-incomplete-checkout", AnalysisApi.SearchAnalystTopInCompleteCheckoutAsync)
            //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("analysis");
        app.MapPost("/analyst-init-data-by-store", AnalysisApi.SearchAnalystInitDataByStoreAsync)
           //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
           .WithTags("analysis");

        app.MapPost("/analyst-init-special-data-by-store", AnalysisApi.SearchAnalystInitSpecialDataByStoreAsync)
           //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
           .WithTags("analysis");

        #region Promotion Analytics
        app.MapPost("/analyst-promotion-metric", AnalysisApi.SearchAnalystPromotionMetricAsync)
          //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
          .WithTags("analysis");

        app.MapPost("/analyst-promotion-init-data-by-store", AnalysisApi.SearchPromotionAnalystInitDataByStoreAsync)
         //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
         .WithTags("analysis");

        app.MapPost("/analyst-promotion-top-revenue", AnalysisApi.SearchAnalystPromotionTopRevenueAsync)
         //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
         .WithTags("analysis");

        app.MapPost("/analyst-promotion-top-product", AnalysisApi.SearchAnalystPromotionTopProductAsync)
         //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
         .WithTags("analysis");

        app.MapPost("/analyst-promotion-type-distribution", AnalysisApi.SearchAnalysistPromotionChartTypeDistributionAsync)
         //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
         .WithTags("analysis");

        app.MapPost("/analyst-promotion-revenue-type-distribution", AnalysisApi.SearchAnalysistPromotionChartRevenueTypeDistributionAsync)
         //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
         .WithTags("analysis");
        #endregion

        #region REPORT JOB
        app.MapPost("/cronjob-sync-warehouse-item", AnalysisApi.ReportItemJobAsync)
        //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
        .WithTags("analysis");

        app.MapPost("/cronjob-sync-warehouse-orderservice", AnalysisApi.ReportOrderJobAsync)
        //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
        .WithTags("analysis");

        app.MapPost("/cronjob-sync-warehouse-lazada", AnalysisApi.ReportLazadaJobAsync)
        //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
        .WithTags("analysis");

        app.MapPost("/cronjob-sync-warehouse-shopee", AnalysisApi.ReportShopeeJobAsync)
        //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
        .WithTags("analysis");

        app.MapPost("/cronjob-sync-warehouse-tiktok", AnalysisApi.ReportTiktokJobAsync)
        //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
        .WithTags("analysis");

        #endregion END REPORT JOB

        return app;
    }
}
