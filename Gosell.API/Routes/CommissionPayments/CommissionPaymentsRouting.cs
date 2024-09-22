using GoSell.API.Service;
using GoSell.Library.Utils;

namespace GoSell.API.Routes.CommissionPayments
{
    public static class CommissionPaymentsRouting
    {
        public static RouteGroupBuilder MapCommissionPaymentsApi(this RouteGroupBuilder app)
        {
            app.MapGet("/", CommissionPaymentsApi.GetCommissionPaymentAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
            .WithTags(SwaggerConstants.AffiliateCommissionPaymentApi);

            app.MapGet("/get-publisher-payment-total", CommissionPaymentsApi.GetCommissionPaymentTotalAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
            .WithTags(SwaggerConstants.AffiliateCommissionPaymentApi);

            app.MapGet("/payment-histories", CommissionPaymentsApi.GetCommissionPaymentHistoriesAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
            .WithTags(SwaggerConstants.AffiliateCommissionPaymentApi);

            app.MapGet("/get-payment-histories-total", CommissionPaymentsApi.GetCommissionPaymentHistoriesTotalAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
            .WithTags(SwaggerConstants.AffiliateCommissionPaymentApi);

            app.MapGet("/export-payment-history", CommissionPaymentsApi.ExportPaymentHistoryAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.AffiliateCommissionPaymentApi);

            app.MapGet("/export-payment-information", CommissionPaymentsApi.ExportPaymentInformationAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.AffiliateCommissionPaymentApi);

            app.MapPost("/create-payment-history", CommissionPaymentsApi.CreateAffiliatePaymentHistoryAsync)
              .AddRequireAuthorizationJWTToken()
              .WithTags(SwaggerConstants.AffiliateCommissionPaymentApi);

            app.MapPost("/import-payment-information", CommissionPaymentsApi.ImportPaymentPaidAmountAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .DisableAntiforgery()
                 .WithTags(SwaggerConstants.AffiliateCommissionPaymentApi);

            app.MapGet("/export-payment-import-template/{langKey}", CommissionPaymentsApi.ExportPaymentImportTemplate)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliateCommissionPaymentApi);

            app.MapGet("/payment-report/{publisherId}", CommissionPaymentsApi.GetPaymentReportByPublisherIdAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.AFFILIATE)
            .WithTags(SwaggerConstants.AffiliateCommissionPaymentApi);

            app.MapGet("/export-payment-report/{publisherId}", CommissionPaymentsApi.ExportPaymentReportByPublisherIdAsync)
           .AddRequireAuthorizationJWTToken(AuthoritiesConstants.AFFILIATE)
           .WithTags(SwaggerConstants.AffiliateCommissionPaymentApi);

            return app;
        }
    }
}
