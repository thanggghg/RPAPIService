using GoSell.API.Service;
using GoSell.Library.Utils;

namespace GoSell.API.Routes.AffliateTracking
{
    public static class AffliateCategoryRouting
    {
        public static RouteGroupBuilder MapAffiliateCategoryApi(this RouteGroupBuilder app)
        {

            app.MapPost("/create", AffiliateCategoryApi.CreateAffiliateCategoryAsync)
               .AddRequireAuthorizationJWTToken()
               .WithTags(SwaggerConstants.AffiliateCategoryApi);

            app.MapPost("/create-public", AffiliateCategoryApi.CreateAffiliateCategoryPublicAsync)
                           .WithTags(SwaggerConstants.AffiliateCategoryApi);

            app.MapPut("/update", AffiliateCategoryApi.UpdateAffiliateCategoryAsync)
               .AddRequireAuthorizationJWTToken()
               .WithTags(SwaggerConstants.AffiliateCategoryApi);

            app.MapGet("/", AffiliateCategoryApi.GetAllAffiliateCategoryAsync)
               .AddRequireAuthorizationJWTToken()
               .WithTags(SwaggerConstants.AffiliateCategoryApi);

            app.MapGet("/get-all-public", AffiliateCategoryApi.GetAllAffiliateCategoryPublicAsync)
                          .WithTags(SwaggerConstants.AffiliateCategoryApi);

            app.MapGet("{id}", AffiliateCategoryApi.GetSpecificAffiliateCategoryAsync)
               .WithTags(SwaggerConstants.AffiliateCategoryApi);

            app.MapPut("/delete/{id}", AffiliateCategoryApi.DeleteAffiliateCategoryAsync)
               .AddRequireAuthorizationJWTToken()
               .WithTags(SwaggerConstants.AffiliateCategoryApi);

            app.MapPut("/change-status", AffiliateCategoryApi.ChangeStatusAffiliateCategoryasync)
               .AddRequireAuthorizationJWTToken()
               .WithTags(SwaggerConstants.AffiliateCategoryApi);

            app.MapPost("/check-duplicate-ref-id", AffiliateCategoryApi.CheckDuplicateRefIdAsync)
                .AddRequireAuthorizationJWTToken()
                .WithTags(SwaggerConstants.AffiliateCategoryApi);

            app.MapPost("/check-duplicate-name", AffiliateCategoryApi.CheckDuplicateNameAsync)
             .AddRequireAuthorizationJWTToken()
             .WithTags(SwaggerConstants.AffiliateCategoryApi);

            app.MapGet("/get-select-list", AffiliateCategoryApi.GetAffiliateCategorySelectListAsync)
              .AddRequireAuthorizationJWTToken()
              .WithTags(SwaggerConstants.AffiliateCategoryApi);

            app.MapGet("/export-category-import-template/{langkey}", AffiliateCategoryApi.ExportImportCategoryTemplate)
                 .AddRequireAuthorizationJWTToken()
                 .WithTags(SwaggerConstants.AffiliateCategoryApi);

            app.MapPost("/import", AffiliateCategoryApi.ImportAffiliateCategoryAsync)
                .AddRequireAuthorizationJWTToken()
                .DisableAntiforgery()
                .WithTags(SwaggerConstants.AffiliateCategoryApi);

            app.MapPost("/create-token", AffiliateCategoryApi.CreateTokenAPIAsync)
                           .WithTags(SwaggerConstants.AffiliateCategoryApi);

            return app;
        }
    }
}
