using GoSell.API.Service;
using GoSell.Library.Utils;

namespace GoSell.API.Routes.FBBulkPosting
{
    public static class FBBulkPosting
    {
        public static RouteGroupBuilder MapFBBulkPostingApi(this RouteGroupBuilder app)
        {
            app.MapPost("/create", FBBulkPostingApi.CreateAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.FBBulkPostingApi);

            app.MapGet("/", FBBulkPostingApi.GetAllBulkPoseAsync)
             .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
             .WithTags(SwaggerConstants.FBBulkPostingApi);

            app.MapPost("/update", FBBulkPostingApi.UpdateAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.FBBulkPostingApi);

            app.MapPost("/save-and-publish", FBBulkPostingApi.SaveAndPublishAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.FBBulkPostingApi);

            app.MapPost("/delete", FBBulkPostingApi.DeleteBulkPostAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.FBBulkPostingApi);

            app.MapPost("/delete-bulk-post-detail", FBBulkPostingApi.DeleteBulkPostDetailAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.FBBulkPostingApi);

            app.MapGet("/{id}", FBBulkPostingApi.GetBulkPostAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.FBBulkPostingApi);

            return app;

        }

    }
}
