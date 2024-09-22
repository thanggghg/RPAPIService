using GoSell.API.Service;
using GoSell.Library.Utils;

namespace GoSell.API.Routes.Payments
{
    public static class PaymentsRouting
    {
        public static RouteGroupBuilder MapPaymentsApi(this RouteGroupBuilder app)
        {
            // only use from service to service
            app.MapPost("/create", PaymentsApi.CreatePaymentAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.ADMIN)
               .WithTags(SwaggerConstants.PaymentAPI);

            // use from FE
            app.MapPost("/cancel", PaymentsApi.CancelPaymentAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.PaymentAPI);

            // only use from service to service
            app.MapPost("/cancel-mpos-only", PaymentsApi.CancelPaymentMposOnlyAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.ADMIN)
               .WithTags(SwaggerConstants.PaymentAPI);

            app.MapGet("/get-transaction-payment-status", PaymentsApi.GetTransactionPaymentStatusAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.PaymentAPI);

            app.MapGet("/get-transaction-payment-status-admin", PaymentsApi.GetTransactionPaymentStatusAdminAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.ADMIN)
               .WithTags(SwaggerConstants.PaymentAPI);

            // use from Mpos
            app.MapPost("/update-transaction-status", PaymentsApi.UpdateTransactionPaymentStatusAsync)
               .AllowAnonymous()
               .WithTags(SwaggerConstants.PaymentAPI);

            // use from FE
            app.MapPost("/config-mpos", PaymentsApi.CreateConfigPaymentMethodAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.PaymentAPI);

            // use from FE
            app.MapPut("/config-mpos/{id:long}", PaymentsApi.UppdateConfigPaymentMethodAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.PaymentAPI);

            // use from FE
            app.MapGet("/config-mpos", PaymentsApi.GetConfigPaymentMethodAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.PaymentAPI);

            app.MapPut("/change-config-mpos-status/{id:long}", PaymentsApi.ChangeConfigMposStatus)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.PaymentAPI);

            return app;
        }
    }
}
