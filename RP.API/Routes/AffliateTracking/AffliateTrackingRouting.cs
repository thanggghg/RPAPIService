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
            return app;
        }
    }
}
