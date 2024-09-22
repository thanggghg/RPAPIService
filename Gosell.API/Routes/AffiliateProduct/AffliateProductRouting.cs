using GoSell.API.Service;
using GoSell.Library.Utils;
using Microsoft.AspNetCore.Builder;

namespace GoSell.API.Routes.AffliateTracking
{
    public static class AffliateProductRouting
    {
        public static RouteGroupBuilder MapAffiliateProductApi(this RouteGroupBuilder app)
        {

            app.MapPost("/create", AffiliateProductApi.AddAffiliateProductAsync)
               .AddRequireAuthorizationJWTToken()
               .WithTags(SwaggerConstants.AffiliateProductApi);

            app.MapPut("/update", AffiliateProductApi.UpdateAffiliateProductAsync)
               .AddRequireAuthorizationJWTToken()
               .WithTags(SwaggerConstants.AffiliateProductApi);
            
            app.MapPost("/import", AffiliateProductApi.ImportAffiliateProductAsync)
                .AddRequireAuthorizationJWTToken()
                .DisableAntiforgery()
                .WithTags(SwaggerConstants.AffiliateProductApi);
			   
            app.MapGet("/", AffiliateProductApi.GetAllAffiliateProductAsync)
               .AddRequireAuthorizationJWTToken()
               .WithTags(SwaggerConstants.AffiliateProductApi);

            app.MapGet("{id}", AffiliateProductApi.GetSpecificAffiliateProductAsync)
                .AddRequireAuthorizationJWTToken()
               .WithTags(SwaggerConstants.AffiliateProductApi);
			   
            app.MapGet("/getAll/{storeId}", AffiliateProductApi.GetAllAffiliateProductByStoreIdAsync)
				.WithTags(SwaggerConstants.AffiliateProductApi);
				
            app.MapPut("/delete/{id}", AffiliateProductApi.DeleteAffiliateProductAsync)
               .AddRequireAuthorizationJWTToken()
               .WithTags(SwaggerConstants.AffiliateProductApi);

            app.MapPut("/change-status/{affiliateStoreId}/{id}", AffiliateProductApi.ChangeStatusAffiliateProductAsync)
               .AddRequireAuthorizationJWTToken()
               .WithTags(SwaggerConstants.AffiliateProductApi);

            app.MapPut("/update-multiplate", AffiliateProductApi.UpdateMultipleAffiliateProductAsync)
               .AddRequireAuthorizationJWTToken()
               .WithTags(SwaggerConstants.AffiliateProductApi);

            app.MapPost("/check-duplicate-ref-id", AffiliateProductApi.CheckDuplicateRefIdAsync)
                .AddRequireAuthorizationJWTToken()
                .WithTags(SwaggerConstants.AffiliateProductApi);

            #region view of publisher
            app.MapGet("/publisher", AffiliateProductApi.GetAffiliateProductViewPublisherAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.AFFILIATE)
               .WithTags(SwaggerConstants.AffiliateProductApi);

            app.MapGet("/publisher-preview", AffiliateProductApi.GetAffiliateProductViewPublisherPreviewAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.AffiliateProductApi);
            #endregion end view of publisher

            app.MapGet("/get-link-product/{id}", AffiliateProductApi.GetProductLinkToPublisherPageAsync)
                .AddRequireAuthorizationJWTToken()
                .WithTags(SwaggerConstants.AffiliateProductApi);

            app.MapGet("/get-link/{refId}", AffiliateProductApi.GetAffiliateProductLinkTrackingAsync)
                 .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                 .WithTags(SwaggerConstants.AffiliateProductApi);

            app.MapGet("/publisher-get-link/{refId}", AffiliateProductApi.GetAffiliateProductLinkTrackingFromPublisherAsync)
                 .AddRequireAuthorizationJWTToken(AuthoritiesConstants.AFFILIATE)
                 .WithTags(SwaggerConstants.AffiliateProductApi);

            app.MapGet("/export-product-import-template/{langkey}", AffiliateProductApi.ExportImportProductTemplate)
                 .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                 .WithTags(SwaggerConstants.AffiliateProductApi);

            app.MapGet("/get-products-add-campaign", AffiliateProductApi.GetProductsAddCampaignAsync)
                 .AddRequireAuthorizationJWTToken()
                 .WithTags(SwaggerConstants.AffiliateProductApi);

            app.MapPost("/resize-image", AffiliateProductApi.ResizeImageAsync)
                .AddRequireAuthorizationJWTToken()
                .DisableAntiforgery()
               .WithTags(SwaggerConstants.AffiliateProductApi);

            app.MapPost("/create-token", AffiliateProductApi.CreateTokenAPIAsync)
               .WithTags(SwaggerConstants.AffiliateProductApi);

            app.MapPost("/create-product-api", AffiliateProductApi.APIAffiliateProductAsync)
               .WithTags(SwaggerConstants.AffiliateProductApi);

            app.MapGet("/get-list-product", AffiliateProductApi.GetAPIAffiliateProductAsync)
               .WithTags(SwaggerConstants.AffiliateProductApi);

            return app;
        }
    }
}
