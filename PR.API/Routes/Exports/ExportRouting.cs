using GoSell.API.Service;
using GoSell.Library.Utils;

namespace GoSell.API.Routes.Exports
{
    public static class ExportRouting
    {
        public static RouteGroupBuilder MapExportRouting(this RouteGroupBuilder app)
        {
            app.MapPost("{type:alpha}/{storeId:long}", ExportApi.ExportAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.ExportAPI);

            app.MapPost("product-commission-report/{langKey}", ExportApi.ExportProductCommissionReportAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.ExportAPI);

            app.MapPost("campaign-commission-report/{langKey}", ExportApi.ExportCampaignCommissionReportAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.ExportAPI);

            app.MapPost("product-publisher-commission-report/{langKey}", ExportApi.ExportProductPublisherCommissionReportAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.ExportAPI);
            return app;
        }
    }
}
