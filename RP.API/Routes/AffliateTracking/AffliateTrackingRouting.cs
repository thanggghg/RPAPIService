using RP.API.Service;
using RP.Library.Utils;

namespace RP.API.Routes.AffliateTracking
{
    public static class AffliateTrackingRouting
    {
        public static RouteGroupBuilder MapAffiliateTrackingApi(this RouteGroupBuilder app)
        {
            #region Common
            app.MapGet("/color", AffiliateTrackingApi.GetAllAffiliateColorDefaultAsync)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapGet("/business", AffiliateTrackingApi.GetAllAffiliateBusinessAsync)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            #endregion
            #region Mapping
            app.MapGet("/mapping/get-by-affiliate-store", AffiliateTrackingApi.GetAffiliateMappingByStoreId)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapPost("/mapping/add", AffiliateTrackingApi.AddAffiliateMappingAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapDelete("/mapping/delete", AffiliateTrackingApi.DeleteAffiliateMappingAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            #endregion
            #region Publisher
            app.MapGet("/publisher/by-order-id", AffiliateTrackingApi.GetAffiliatePublisherByOrderId)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            #endregion
            #region Store
            app.MapGet("/store", AffiliateTrackingApi.GetAllAffiliateStoreAsync)
                     .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                     .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapGet("/store/get-all-by-gs-store-id/{goSellStoreId}", AffiliateTrackingApi.GetAllAffiliateStoreByGsIdAsync)
                     .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                     .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapGet("/store/by-domain", AffiliateTrackingApi.GetAffiliateStoreByDomainAsync)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapGet("/store/by-store-id/{id}", AffiliateTrackingApi.GetSpecificAffiliateStoreByIdAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapGet("/store/info", AffiliateTrackingApi.GetAffiliateStoreByAPIdAsync)
                     .WithTags(SwaggerConstants.AffiliateTrackingApi);
            //Api wrong, go-sell-store-id contains multi-affiliated stores; please use api /store/get-all-by-gs-store-id
            //app.MapGet("/store/by-gs-store-id/{goSellStoreId}", AffiliateTrackingApi.GetSpecificAffiliateStoreByGoSellStoreIdAsync)
            //   .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            //   .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapPost("/store", AffiliateTrackingApi.AddAffiliateStoreAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapPut("/store", AffiliateTrackingApi.UpdateAffiliateStoreAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapPut("/store/website", AffiliateTrackingApi.UpdateWebsiteOrIsDeletedOfExternalStoreAsync)
              .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
              .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapPost("/api-key/create", AffiliateTrackingApi.CreateApiKey)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapGet("/by-gs-store-id", AffiliateTrackingApi.GetSpecificAffiliateStoreAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER);

            // get from net service. used validate affiliate store when call api from client
            app.MapGet("/store/by-id/{id}", AffiliateTrackingApi.GetAffiliateStoreByIdAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.ADMIN);

            app.MapPost("/store/by-gs-id", AffiliateTrackingApi.GetAllAffiliateStoreByGoSellIdAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER);

            app.MapPost("/store/update-auto-approve", AffiliateTrackingApi.UpdateAutoApproveStoresAsync)
              .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
              .WithTags(SwaggerConstants.AffiliateTrackingApi);

            //StoreCurrency
            app.MapGet("/store/currency", AffiliateTrackingApi.GetStoreCurrencyAsync)
              .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
              .WithTags(SwaggerConstants.AffiliateTrackingApi);

            app.MapGet("/store/get-currency-unit/{affiliateStoreId:long}", AffiliateTrackingApi.GetCurrencyUnit)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.AffiliateTrackingApi);

            #endregion
            #region Submission
            app.MapPost("/submission/create", AffiliateTrackingApi.AddAffiliateSubmissionAsync)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapPost("/submission/create-by-script", AffiliateTrackingApi.AddAffiliateSubmissionByScriptAsync)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapGet("/submission/get-all/{gsStoreId}", AffiliateTrackingApi.GetAllAffiliateSubmissionByGsStoreIdAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapPut("/submission/updateStatusSubmission", AffiliateTrackingApi.UpdateStatusSubmissionAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER);
            app.MapPut("/submission/updateStatusListSubmission", AffiliateTrackingApi.UpdateStatusListSubmissionAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER);
            app.MapPut("/submission/updatepartnerSubmission", AffiliateTrackingApi.UpdatePartnerSubmissionAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER);
            app.MapPost("/submission/export", AffiliateTrackingApi.ExportSubmissionAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapPost("/submission/import", AffiliateTrackingApi.ImportSubmissionByFileAsync)
                .AddRequireAuthorizationJWTToken()
                .DisableAntiforgery()
                .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapGet("/submission", AffiliateTrackingApi.GetSpecificAffiliateSubmissionByIdAsync)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapGet("/submission/by-external-store-id", AffiliateTrackingApi.GetPublishersByAffStoreIdAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapGet("/submission/by-external-store-id-for-cron-job", AffiliateTrackingApi.GetPublishersByAffStoreIdForCronJobAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.ADMIN)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            #endregion
            #region Theme
            app.MapGet("/theme/get-all/{storeId}", AffiliateTrackingApi.GetAllAffiliateThemeByStoreIdAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapGet("/theme/published/{storeId}", AffiliateTrackingApi.GetAffiliateThemePublishedByStoreIdAsync)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapGet("/theme/business-default", AffiliateTrackingApi.GetThemesOfBusinessAsync)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapGet("/theme", AffiliateTrackingApi.GetAffiliateThemeByBusinessIdAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapPost("/theme", AffiliateTrackingApi.CreateThemeAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapPut("/theme", AffiliateTrackingApi.UpdateThemeAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapPut("/theme/publish", AffiliateTrackingApi.PublishThemeAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapDelete("/theme", AffiliateTrackingApi.DeleteThemeAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapGet("/theme/{themeId}", AffiliateTrackingApi.GetThemeByIdAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            #endregion
            #region Tracking
            app.MapPost("/click", AffiliateTrackingApi.AddClickTrackingAsync)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapPost("/tracking/add-order-tracking", AffiliateTrackingApi.AddOrderTrackingAsync)
                .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapPost("/links", AffiliateTrackingApi.AddAffiliateLinkAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.AFFILIATE)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapPut("/update-platform-by-tracking-id", AffiliateTrackingApi.UpdatePlatformByTrackingId)
               .AddRequireAuthorizationJWTToken()
               .WithTags(SwaggerConstants.AffiliateProductApi);
            app.MapGet("/tracking/order", AffiliateTrackingApi.GetOrderTrackingAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapPost("/get-url-report/{affiliateStoreId:long}", AffiliateTrackingApi.GetAffUrlReport)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.AFFILIATE)
               .WithTags(SwaggerConstants.AffiliateTrackingApi);
            app.MapPost("/url-report/export/{type:alpha}/{affiliateStoreId:long}", AffiliateTrackingApi.ExportAffUrlReportAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.AFFILIATE)
                .WithTags("commision");
            #endregion
            return app;
        }
    }
}
