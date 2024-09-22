using GoSell.API.Service;
using GoSell.Library.Utils;

namespace GoSell.API.Routes.AffiliatePublisherManagement
{
    public static class AffiliatePublisherManagementRouting
    {
        public static RouteGroupBuilder MapAffiliatePublisherManagementApi(this RouteGroupBuilder app)
        {
            app.MapPost("publishers/{storeId:long}", AffiliatePublisherManagementApi.GetPublisherByStoreAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherManagementApi);

            app.MapGet("publisher/detail/{storeId:long}/{id:long}", AffiliatePublisherManagementApi.GetPublisherInfoByIdAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherManagementApi);

            app.MapPost("publisher/update/{storeId:long}/{id:long}", AffiliatePublisherManagementApi.UpdatePublisherStoreAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherManagementApi);

            app.MapPost("publisher/update-status/{storeId:long}/{id:long}/{type:int}", AffiliatePublisherManagementApi.UpdatePublisherStoreStatusAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherManagementApi);

            app.MapPost("publisher/update-auto-approved-store/{storeId:long}", AffiliatePublisherManagementApi.UpdateAutoApprovedStoreAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherManagementApi);

            app.MapGet("publisher/total-status/{storeId:long}", AffiliatePublisherManagementApi.GetPublisherStatusByStoreAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherManagementApi);

            app.MapPost("publisher/update-allow-publisher-register/{storeId:long}", AffiliatePublisherManagementApi.UpdateAllowPublisherRegisterAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherManagementApi);

            app.MapPost("publisher/get-list-user-manager/{goSellStoreId:long}", AffiliatePublisherManagementApi.GetPublisherUserManagerAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherManagementApi);


            // Use for Payment Commission search data...
            app.MapPost("publishers/get-by-filter", AffiliatePublisherManagementApi.GetPublisherByFilterAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherManagementApi);

            app.MapGet("publisher/check-package-limit/{storeId:long}", AffiliatePublisherManagementApi.CheckPackageLimitAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherManagementApi);
            // Publisher network
            app.MapPost("publisher/user-manager/update", AffiliatePublisherManagementApi.UpdateAffiliateUserManagerAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherManagementApi);
            app.MapGet("publishers/get-all-publisher-user-manager/{storeId:long}", AffiliatePublisherManagementApi.GetAllPublisherUserManagerByStoreAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherManagementApi);
            app.MapGet("publishers/get-all-publisher-user-manager-affStore/{storeId:long}", AffiliatePublisherManagementApi.GetAllPublisherUserManagerByAFFStoreAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.AffiliatePublisherManagementApi);
            #region partner title
            app.MapGet("partner-title", AffiliatePublisherManagementApi.GetAffiliatePartnerTitleAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherManagementApi);

            app.MapPut("partner-title/delete", AffiliatePublisherManagementApi.DeleteAffiliatePartnerTitleAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherManagementApi);

            app.MapPost("partner-title/insert-update", AffiliatePublisherManagementApi.InsertUpdateAffiliatePartnerTitleAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherManagementApi);

            app.MapGet("partner-title-dropdown/{affiliateStoreId:long}", AffiliatePublisherManagementApi.GetAffiliatePartnerTitleForDropdownAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
                .WithTags(SwaggerConstants.AffiliatePublisherManagementApi);
            #endregion

            app.MapPost("publisher/filter-by-name-and-phone", AffiliatePublisherManagementApi.GetListFilterByNameAndPhone)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.AffiliatePublisherManagementApi);

            return app;
        }
    }
}
