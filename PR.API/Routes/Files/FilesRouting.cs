using GoSell.API.Service;
using GoSell.Library.Utils;

namespace GoSell.API.Routes.Comments
{
    public static class FilesRouting
    {
        public static RouteGroupBuilder MapFilesApi(this RouteGroupBuilder app)
        {
            app.MapPost("/handle", FilesApi.FileAsync).AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags("files");
            return app;
        }
    }
}
