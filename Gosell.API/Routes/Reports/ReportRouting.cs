using GoSell.API.Service;
using GoSell.Library.Utils;

namespace GoSell.API.Routes.Payments
{
    public static class ReportRouting
    {
        public static RouteGroupBuilder MapAffiliateReportApi(this RouteGroupBuilder app)
        {
            // use from FE
            app.MapPost("/summary-dashboard", AffiliateReportApi.GetSummaryDashboardReportAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.ReportApi);

            // use from FE
            app.MapPost("/top-selling-publisher", AffiliateReportApi.GetTopSellingPublisherReportAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.ReportApi);

            // use from FE
            app.MapPost("/top-selling-product", AffiliateReportApi.GetTopSellingProductReportAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.ReportApi);

            // use from FE
            app.MapPost("/order_trend", AffiliateReportApi.GetOrderTrendReportAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.ReportApi);

            app.MapPost("/product-commission", AffiliateReportApi.GetProductCommissionReportAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.ReportApi);

            app.MapPost("/campaign-commission", AffiliateReportApi.GetCampaignCommissionReportAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.ReportApi);

            app.MapPost("/product-commission-publisher", AffiliateReportApi.GetProductCommissionPublisherReportAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.ReportApi);
            return app;
        }
    }
}
