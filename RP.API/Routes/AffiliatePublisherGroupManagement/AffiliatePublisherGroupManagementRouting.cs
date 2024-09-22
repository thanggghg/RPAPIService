using GoSell.API.Service;
using GoSell.Library.Utils;

namespace GoSell.API.Routes.AffiliatePublisherGroupManagement
{
    public static class AffiliatePublisherGroupManagementRouting
    {
        public static RouteGroupBuilder MapAffiliatePublisherGroupManagementApi(this RouteGroupBuilder app)
        {
            app.MapPost("/filterListPublishedGroup", AffiliatePublisherGroupManagementApi.FilterListPublishGroupHistoryAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherGroupManagementApi);

            app.MapPost("/getListGroupPublisher", AffiliatePublisherGroupManagementApi.GetListGroupPublishersAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherGroupManagementApi);

            app.MapGet("/getAffiliateGroup/{groupId:long}", AffiliatePublisherGroupManagementApi.GetAffiliateGroupPublishersAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherGroupManagementApi);

            app.MapPost("/createGroupPublisher", AffiliatePublisherGroupManagementApi.CreateGroupPublisherAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherGroupManagementApi);

            app.MapPost("/deleteGroupPublisher", AffiliatePublisherGroupManagementApi.DeleteGroupPublisherAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherGroupManagementApi);

            app.MapPost("/insertPublisherToGroup", AffiliatePublisherGroupManagementApi.InsertPublisherToGroupAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherGroupManagementApi);

            app.MapPost("/publishGroupPublisher", AffiliatePublisherGroupManagementApi.PublishGroupPublisherAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherGroupManagementApi);

            app.MapPost("/removePublisherFromGroup", AffiliatePublisherGroupManagementApi.RemovePublisherFromGroupAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherGroupManagementApi);

            app.MapPost("/updateGroupPublisher", AffiliatePublisherGroupManagementApi.UpdateGroupPublisherAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherGroupManagementApi);

            app.MapPost("/getListPublishers", AffiliatePublisherGroupManagementApi.GetListPublishersAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherGroupManagementApi);


            return app;
        }
    }
}
