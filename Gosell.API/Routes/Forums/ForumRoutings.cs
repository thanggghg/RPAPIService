using GoSell.API.Service;
using GoSell.Library.Utils;

namespace GoSell.API.Routes.Forums
{
    public static class ForumRoutings
    {
        public static RouteGroupBuilder MapForumCategoryRoutingApis(this RouteGroupBuilder app)
        {
            app.MapPost("/category/create", ForumApis.CreateCategoryAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPost("/category/filter", ForumApis.GetCategoriesAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapGet("/category/detail/{categoryId}", ForumApis.GetCategoryAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPut("/category/update", ForumApis.UpdateCategoryAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPut("/category/update-is-blocked", ForumApis.UpdateIsBlockedCategoryAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            return app;
        }

        public static RouteGroupBuilder MapForumCommentsRoutingApis(this RouteGroupBuilder app)
        {
            app.MapPost("/forum-comments/create", ForumApis.CreateCommentsAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPut("/forum-comments/update-status", ForumApis.UpdateStatusCommentAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.ForumApi);

            app.MapPost("/forum-comments/filter", ForumApis.GetForumCommentsAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapGet("/forum-comments/{commentId}", ForumApis.GetCommentDetailAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            return app;
        }

        public static RouteGroupBuilder MapForumMembersRoutingApis(this RouteGroupBuilder app)
        {

            app.MapPost("/forum-members/filter", ForumApis.GetForumMembersAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapGet("/forum-members/detail/{memberId}", ForumApis.GetForumMemberDetailAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPut("/forum-members/update-status", ForumApis.UpdateStatusMemberAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.ForumApi);

            return app;
        }

        public static RouteGroupBuilder MapForumPostRoutingApis(this RouteGroupBuilder app)
        {
            app.MapPost("/post/create", ForumApis.CreatePostAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.ForumApi);

            app.MapPost("/post/filter", ForumApis.GetPostByFilterAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapGet("/post/detail/{postId}", ForumApis.GetPostDetailAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPut("/post/update", ForumApis.UpdatePostAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPut("/post/update-is-blocked", ForumApis.UpdateIsBlockedPostAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPut("/post/deleted", ForumApis.DeletedPostAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPut("/post/approve", ForumApis.ApprovePostAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPut("/post/reject", ForumApis.RejectPostAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            return app;
        }

        public static RouteGroupBuilder MapForumTopicRoutingApis(this RouteGroupBuilder app)
        {

            app.MapPost("/topic/create", ForumApis.CreateTopicAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPost("/topic/filter", ForumApis.GetTopicsAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapGet("/topic/detail/{topicId}", ForumApis.GetTopicAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPut("/topic/update", ForumApis.UpdateTopicAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPut("/topic/update-is-blocked", ForumApis.UpdateIsBlockedTopicAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            return app;
        }

        public static RouteGroupBuilder MapForumConfigurationRoutingApis(this RouteGroupBuilder app)
        {
            app.MapPost("/configuration/getConfiguration/{storeId}", ForumApis.GetConfigurationAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPut("/configuration/update", ForumApis.UpdateConfigurationAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPost("/configuration/remind-expired-package", ForumApis.SendExpiredEmail)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            return app;
        }

        public static RouteGroupBuilder MapSEOSettingRoutingApis(this RouteGroupBuilder app)
        {

            app.MapGet("/seo-setting/check-url-is-duplicate", ForumApis.CheckUrlIsDuplicate)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            return app;
        }

        public static RouteGroupBuilder MapForumStoreFrontRoutingApis(this RouteGroupBuilder app)
        {
            /// Provide apis for StoreFont, do not reuse existing apis of the object because it may affect StoreFont's logic
            app.MapPost("/ssr/get-forum-categories", ForumApis.GetHomePageCategoriesAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPost("/ssr/get-topic-posts", ForumApis.StoreFrontGetPostsAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPost("/ssr/get-forum-latest-posts", ForumApis.GetHomePageLatestPostsAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPost("/ssr/{topicId:long}/get-topic-latest-posts", ForumApis.GetTopicLatestPostsAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPost("/ssr/get-forum-latest-comments", ForumApis.GetHomePageLatestCommentsAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPost("/ssr/{topicId:long}/get-topic-latest-comments", ForumApis.GetTopicLatestCommentsAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            //app.MapPost("/ssr/get-comment-and-replies-by-post", ForumApis.GetForumCommentByRepliesAsync)
            //.AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            //   .WithTags(SwaggerConstants.ForumApi);

            app.MapGet("/ssr/{topicId:long}/get-topic-detail", ForumApis.StoreFrontGetTopicAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPost("/ssr/create-post", ForumApis.CreatePostOnStoreFrontAsync)
              .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
              .WithTags(SwaggerConstants.ForumApi);

            app.MapGet("/ssr/get-config-and-permission", ForumApis.GetForumConfigAndPermissionAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.GUEST)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPost("/ssr/is-allow-create-edit-post", ForumApis.IsAllowCreateOrEditPostAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPost("/ssr/update-post", ForumApis.UpdatePostOnStoreFrontAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapDelete("/ssr/delete-post", ForumApis.DeletePostOnStoreFrontAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapGet("/ssr/{postId:long}/get-post-detail", ForumApis.GetPostDetailOnStoreFrontAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPost("/ssr/{postId:long}/get-comments", ForumApis.GetCommentsFilterOnStoreFrontAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPost("/ssr/create-comment", ForumApis.CreateCommentOnStoreFrontAsync)
              .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
              .WithTags(SwaggerConstants.ForumApi);

            app.MapPost("/ssr/update-comment", ForumApis.UpdateCommentOnStoreFrontAsync)
              .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
              .WithTags(SwaggerConstants.ForumApi);

            app.MapDelete("/ssr/delete-comment", ForumApis.DeleteCommentOnStoreFrontAsync)
              .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
              .WithTags(SwaggerConstants.ForumApi);

            app.MapGet("/ssr/{userId:long}/get-summary-profile-member", ForumApis.GetSummaryProfileMemberAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            app.MapPost("/ssr/create-member", ForumApis.CreateMemberAsync)
              .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
              .WithTags(SwaggerConstants.ForumApi);

            return app;
        }


        public static RouteGroupBuilder MapForumPaymentPackageApis(this RouteGroupBuilder app)
        {

            app.MapPost("/package-order/create", ForumApis.CreateCreatePackageOrder)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);
            app.MapPost("/package-order/approve", ForumApis.ApprovePackageOrder)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);
            app.MapPost("/package-order/approve-reject-package-order-cod", ForumApis.ApproveRejectPackageOrderCOD)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);
            app.MapPut("/package-order/update-qc-testing", ForumApis.UpdateQCMarkCommand)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);
            app.MapGet("/package-order/filter", ForumApis.GetListPackageOrder)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);
            app.MapGet("/package-price/filter", ForumApis.GetListPackagePrice)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);
            app.MapGet("/store-package/detail", ForumApis.GetStorePackage)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.ForumApi);

            return app;
        }
    }
}
