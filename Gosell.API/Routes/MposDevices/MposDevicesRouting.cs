using GoSell.API.Service;
using GoSell.Library.Utils;

namespace GoSell.API.Routes.MposDevices
{
    public static class MposDevicesRouting
    {
        public static RouteGroupBuilder MapMposDevicesApi(this RouteGroupBuilder app)
        {
            app.MapPost("/create-mpos", MposDevicesApi.CreateMposDeviceAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.MposDevicesAPI);

            app.MapPut("/update-mpos/{id:long}", MposDevicesApi.UpdateMposDeviceAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.MposDevicesAPI);

            app.MapPut("/change-mpos-status/{id:long}", MposDevicesApi.ChangeMposDeviceAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.MposDevicesAPI);

            app.MapPut("/delete-mpos/{id:long}", MposDevicesApi.DeleteMposDeviceAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.MposDevicesAPI);

            app.MapGet("/list-mpos-device-active-by-branch/{id:long}", MposDevicesApi.GetListMposDeviceActiveByBranchAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.MposDevicesAPI);

            app.MapGet("/list-mpos-device/{id:long}", MposDevicesApi.GetListMposDevicesByStoreIdAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.MposDevicesAPI);

            app.MapGet("/mpos-device/{id:long}", MposDevicesApi.GetMposDeviceByIdAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.MposDevicesAPI);

            app.MapGet("/check-mpos-id/{id}", MposDevicesApi.CheckMposIdAsync)
              .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
              .WithTags(SwaggerConstants.MposDevicesAPI);

            app.MapGet("/check-mpos-device-name/{branchId:long}/{name}", MposDevicesApi.CheckMposDeviceNameAsync)
              .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
              .WithTags(SwaggerConstants.MposDevicesAPI);

            app.MapGet("/mpos-device", MposDevicesApi.GetMposDeviceAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.STORE)
               .WithTags(SwaggerConstants.MposDevicesAPI);


            // use from FE
            app.MapGet("/check-mpos-device", MposDevicesApi.CheckMposDeviceAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.MposDevicesAPI);


            return app;
        }
    }
}
