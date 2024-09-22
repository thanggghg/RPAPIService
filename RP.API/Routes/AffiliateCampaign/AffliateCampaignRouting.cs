using GoSell.API.Service;
using GoSell.Library.Utils;

namespace GoSell.API.Routes.AffliateTracking
{
    public static class AffliateCampaignRouting
    {
        public static RouteGroupBuilder MapAffiliateCampaignApi(this RouteGroupBuilder app)
        {

            app.MapPost("/create-or-update", AffiliateCampaignApi.CreateOrUpdateAffiliateCampaignAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.AffiliateCampaignApi);

            app.MapPut("/delete/{id}", AffiliateCampaignApi.DeleteAffiliateCampaignAsync)
              .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
              .WithTags(SwaggerConstants.AffiliateCampaignApi);

            app.MapGet("/", AffiliateCampaignApi.GetAllAffiliateCampaignAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.AffiliateCampaignApi);

            app.MapGet("/{id}", AffiliateCampaignApi.GetSpecificAffiliateCampaignAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.AffiliateCampaignApi);
			   
            app.MapGet("/getAll/{storeId}", AffiliateCampaignApi.GetAllAffiliateCampaignByStoreIdAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.AffiliateCampaignApi);

            app.MapPost("/publish", AffiliateCampaignApi.PublishAffiliateCampaignAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.AffiliateCampaignApi);

            app.MapPut("/terminate", AffiliateCampaignApi.TerminateAffiliateCampaignAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.AffiliateCampaignApi);

            app.MapPost("/validate", AffiliateCampaignApi.ValidateAffiliateCampaignAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.AffiliateCampaignApi);

            app.MapGet("/campaigns-to-calculate-commission", AffiliateCampaignApi.GetCampaignsToCalculateCommissionAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.ADMIN)
                .WithTags(SwaggerConstants.AffiliateCampaignApi);

            app.MapGet("/happening-for-publisher-include-product", AffiliateCampaignApi.GetCampaignsHappeningForPublisherIncludeProductAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.AFFILIATE)
                .WithTags(SwaggerConstants.AffiliateCampaignApi);

            app.MapGet("/happening-for-publisher", AffiliateCampaignApi.GetCampaignsHappeningForPublisherAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.AFFILIATE)
                .WithTags(SwaggerConstants.AffiliateCampaignApi);

            app.MapPost("/cronjob-update-campaign-expired", AffiliateCampaignApi.CronJobUpdateAllExpriredCampaignAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.AffiliateCampaignApi);

            return app;
        }
    }
}
