using GoSell.API.Service;
using GoSell.Library.Utils;

namespace GoSell.API.Routes.Comments
{
    public static class CommentsRouting
    {
        public static RouteGroupBuilder MapCommentsApi(this RouteGroupBuilder app)
        {
            app.MapPost("/search", CommentsApi.SearchAsync)
           .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
           //.AllowAnonymous()
           .WithTags("comments");

            app.MapPost("/create", CommentsApi.CreateAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            //.AllowAnonymous()
            .WithTags("comments");

            app.MapPut("/edit", CommentsApi.EditAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            //.AllowAnonymous()
            .WithTags("comments");

            app.MapDelete("/delete/{id:long}", CommentsApi.DeleteAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            //.AllowAnonymous()
            .WithTags("comments");

            app.MapPost("/permissions/create", CommentsApi.CreatePermissionAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            //.AllowAnonymous()
            .WithTags("comments");

            app.MapPut("/permissions/edit", CommentsApi.EditPermissionAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            //.AllowAnonymous()
            .WithTags("comments");

            app.MapPost("/permissions/search", CommentsApi.GetPermissionAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            //.AllowAnonymous()
            .WithTags("comments");

            app.MapPost("/reaction/create", CommentsApi.CreateReaction)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            //.AllowAnonymous()
            .WithTags("comments");

            app.MapDelete("/reaction/{reactionId:long}", CommentsApi.DeleteReaction)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            //.AllowAnonymous()
            .WithTags("comments");

            return app;
        }
    }
}
