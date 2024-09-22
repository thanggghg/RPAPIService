using GoSell.API.Service;
using GoSell.Library.Utils;
using Microsoft.AspNetCore.Builder;

namespace GoSell.API.Routes.Warranties
{
    public static class WarrantiesRouting
    {
        public static RouteGroupBuilder MapWarrantyApis(this RouteGroupBuilder app)
        {
            app.MapGet("/get-template-detail/{templateId}", WarrantiesApi.GetWarrantyDetailAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapPost("/get-templates", WarrantiesApi.GetWarrantiesAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapPost("/create-template", WarrantiesApi.CreateWarrantyTemplateAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapPut("/update-template", WarrantiesApi.UpdateWarrantyTemplateAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapDelete("/delete-template/{templateId}", WarrantiesApi.DeleteWarrantyTemplateAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapPost("/card/get-cards", WarrantiesApi.GetWarrantyCardsAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapPost("/card/create-card", WarrantiesApi.CreateWarrantyCardAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapGet("/card/get-card-detail/{cardId}", WarrantiesApi.GetWarrantyCardDetailAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapPut("/card/update-card", WarrantiesApi.UpdateWarrantyCardAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapGet("/card/information/{cardId}", WarrantiesApi.GetCardInformationAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapDelete("/card/delete/{cardId}", WarrantiesApi.DeleteWarrantyCardAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapPut("/card/update-card-status", WarrantiesApi.UpdateWarrantyCardStatusAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapPost("/card/print-setting/save", WarrantiesApi.SaveCardPrintSetting)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapGet("/card/print-setting/{cardId}", WarrantiesApi.GetPrintSettingAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapGet("/product-setting/{productId}", WarrantiesApi.GetWarrantyProductSetting)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.GUEST)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.GUEST_CHECKOUT)
            .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapPost("/product-setting/save", WarrantiesApi.SaveWarrantyProductSetting)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapPost("/product-cards", WarrantiesApi.CreateWarrantyProduct)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapPost("/get-warranty-products", WarrantiesApi.GetWarrantyOfProduct)
           .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
           .AddRequireAuthorizationJWTToken(AuthoritiesConstants.GUEST)
           .AddRequireAuthorizationJWTToken(AuthoritiesConstants.GUEST_CHECKOUT)
           .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapPut("/card/update-product", WarrantiesApi.UpdateWarrantyProductCard)
           .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
           .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapDelete("/disable-product-cards/{orderId}", WarrantiesApi.DisableProductCards)
           .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
           .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapGet("/summary-cards/{orderDetailId}", WarrantiesApi.GetWarrantyCardByOrderDetail)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapPost("/update-expired-card", WarrantiesApi.UpdateExpiredCardApi)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapPost("/update-active-card", WarrantiesApi.UpdateActiveCardApi)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags(SwaggerConstants.WarrantyAPI);

            app.MapPost("/store-font", WarrantiesApi.GetSSRWarrantiesApi)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags(SwaggerConstants.WarrantyAPI);

            return app;
        }
    }
}
