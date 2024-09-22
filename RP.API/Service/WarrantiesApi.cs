using System.Net;
using GoSell.EWarranty.Commands;
using GoSell.EWarranty.Queries;
using GoSell.EWarranty.Repositories.Implementation;
using GoSell.EWarranty.Services;
using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Api;
using GoSell.Payments.Application.Commands.Payments;
using GoSell.Payments.Services.Payment;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using Serilog;

namespace GoSell.API.Service
{
    public static class WarrantiesApi
    {
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetWarrantyDetailAsync([FromRoute] long templateId, [AsParameters] EWarrantyService ewarrantyService)
        {
            var input = new GetWarrantyDetailQuery(templateId);
            var result = await ewarrantyService.Mediator.Send(input);
            Log.Logger.Information($"DONE {nameof(GetWarrantyDetailQuery)}");
            return TypedResults.Ok(result);
        }
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetWarrantiesAsync([FromBody] GetWarrantiesQuery request, [AsParameters] EWarrantyService ewarrantyService)
        {
            var result = await ewarrantyService.Mediator.Send(request);
            Log.Logger.Information($"DONE {nameof(GetWarrantiesQuery)}");
            return TypedResults.Ok(result);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CreateWarrantyTemplateAsync([FromBody] CreateWarrantyTemplateCommand request, [AsParameters] EWarrantyService ewarrantyService)
        {
            try
            {
                var result = await ewarrantyService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(CreateWarrantyTemplateCommand)}");
                return TypedResults.Ok(result);
            }
            catch (Exception)
            {
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> UpdateWarrantyTemplateAsync([FromBody] UpdateWarrantyTemplateCommand request, [AsParameters] EWarrantyService ewarrantyService)
        {
            try
            {
                var result = await ewarrantyService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(UpdateWarrantyTemplateCommand)}");
                return TypedResults.Ok(result);
            }
            catch (Exception)
            {
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> DeleteWarrantyTemplateAsync([FromRoute] long templateId, [AsParameters] EWarrantyService ewarrantyService)
        {
            var input = new DeleteWarrantyTemplateCommand(templateId);
            var result = await ewarrantyService.Mediator.Send(input);
            Log.Logger.Information($"DONE {nameof(DeleteWarrantyTemplateCommand)}");
            return TypedResults.Ok(result);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetWarrantyCardsAsync([FromBody] GetWarrantyCardsQuery request, [AsParameters] EWarrantyService ewarrantyService)
        {
            var result = await ewarrantyService.Mediator.Send(request);
            Log.Logger.Information($"DONE {nameof(GetWarrantyCardsQuery)}");
            return TypedResults.Ok(result);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CreateWarrantyCardAsync([FromBody] CreateWarrantyCardCommand request, [AsParameters] EWarrantyService ewarrantyService)
        {
            try
            {
                var result = await ewarrantyService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(CreateWarrantyCardCommand)}");
                return TypedResults.Ok(result);
            }
            catch (Exception)
            {
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetWarrantyCardDetailAsync([FromRoute] long cardId, [AsParameters] EWarrantyService ewarrantyService)
        {
            var input = new GetWarrantyCardDetailQuery(cardId);
            var result = await ewarrantyService.Mediator.Send(input);
            Log.Logger.Information($"DONE {nameof(GetWarrantyCardDetailQuery)}");
            return TypedResults.Ok(result);
        }
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> UpdateWarrantyCardAsync([FromBody] UpdateWarrantyCardCommand request, [AsParameters] EWarrantyService ewarrantyService)
        {
            try
            {
                var result = await ewarrantyService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(UpdateWarrantyCardCommand)}");
                return TypedResults.Ok(result);
            }
            catch (Exception)
            {
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> UpdateWarrantyCardStatusAsync([FromBody] UpdateWarrantyCardStatusCommand request, [AsParameters] EWarrantyService ewarrantyService)
        {
            try
            {
                var result = await ewarrantyService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(UpdateWarrantyCardStatusCommand)}");
                return TypedResults.Ok(result);
            }
            catch (Exception)
            {
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetCardInformationAsync([FromRoute] long cardId, [AsParameters] EWarrantyService ewarrantyService)
        {
            var result = await ewarrantyService.Mediator.Send(new GetCardInformationQuery { CardId = cardId });
            Log.Logger.Information($"DONE {nameof(GetCardInformationQuery)}");
            return TypedResults.Ok(result);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> DeleteWarrantyCardAsync([FromRoute] long cardId, [AsParameters] EWarrantyService ewarrantyService)
        {
            var input = new DeleteWarrantyCardCommand(cardId);
            var result = await ewarrantyService.Mediator.Send(input);
            Log.Logger.Information($"DONE {nameof(DeleteWarrantyCardCommand)}");
            return TypedResults.Ok(result);
        }
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetPrintSettingAsync([FromRoute] long cardId, [AsParameters] EWarrantyService ewarrantyService)
        {
            var result = await ewarrantyService.Mediator.Send(new GetWarrantyCardPrintSettingQuery { CardId = cardId });
            Log.Logger.Information($"DONE {nameof(GetWarrantyCardPrintSettingQuery)}");
            return TypedResults.Ok(result);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> SaveCardPrintSetting([FromBody] SavePrintSettingCommand request, [AsParameters] EWarrantyService ewarrantyService)
        {
            try
            {
                var result = await ewarrantyService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(SavePrintSettingCommand)}");
                return TypedResults.Ok(result);
            }
            catch (Exception)
            {
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetWarrantyProductSetting([FromRoute] long productId, [AsParameters] EWarrantyService ewarrantyService)
        {
            try
            {
                var result = await ewarrantyService.Mediator.Send(new GetWarrantyProductSettingQuery { ProductId = productId });
                Log.Logger.Information($"DONE {nameof(GetWarrantyProductSettingQuery)}");
                return TypedResults.Ok(result);
            }
            catch (Exception)
            {
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> SaveWarrantyProductSetting([FromBody] SaveWarrantyProductSettingCommand request, [AsParameters] EWarrantyService ewarrantyService)
        {
            try
            {
                var result = await ewarrantyService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(SaveWarrantyProductSettingCommand)}");
                return TypedResults.Ok(result);
            }
            catch (Exception)
            {
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CreateWarrantyProduct([FromBody] CreateWarrantyCardProductCommand request, [AsParameters] EWarrantyService ewarrantyService)
        {
            try
            {
                var result = await ewarrantyService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(CreateWarrantyCardProductCommand)}");
                return TypedResults.Ok(result);
            }
            catch (Exception)
            {
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetWarrantyOfProduct([FromBody] GetWarrantyOfProductQuery request, [AsParameters] EWarrantyService ewarrantyService)
        {
            try
            {
                var result = await ewarrantyService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(GetWarrantyOfProductQuery)}");
                return TypedResults.Ok(result);
            }
            catch (Exception)
            {
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> UpdateWarrantyProductCard([FromBody] UpdateWarrantyProductCardCommand request, [AsParameters] EWarrantyService ewarrantyService)
        {
            try
            {
                var result = await ewarrantyService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(UpdateWarrantyProductCardCommand)}");
                return TypedResults.Ok(result);
            }
            catch (Exception)
            {
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> DisableProductCards([FromRoute] long orderId, [AsParameters] EWarrantyService ewarrantyService)
        {
            var input = new DisableWarrantyCardByOrderCommand(orderId);
            var result = await ewarrantyService.Mediator.Send(input);
            Log.Logger.Information($"DONE {nameof(DisableWarrantyCardByOrderCommand)}");
            return TypedResults.Ok(result);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetWarrantyCardByOrderDetail([FromRoute] long orderDetailId, [AsParameters] EWarrantyService ewarrantyService)
        {
            try
            {
                var result = await ewarrantyService.Mediator.Send(new GetWarrantyCardOrderDetailQuery { OrderDetailId = orderDetailId });
                Log.Logger.Information($"DONE {nameof(GetWarrantyCardOrderDetailQuery)}");
                return TypedResults.Ok(result);
            }
            catch (Exception)
            {
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> UpdateExpiredCardApi([FromBody] UpdateExpiredWarrantyCardStatusCommand request, [AsParameters] EWarrantyService ewarrantyService)
        {
            try
            {
                var result = await ewarrantyService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(UpdateExpiredWarrantyCardStatusCommand)}");
                return TypedResults.Ok(result);
            }
            catch (Exception)
            {
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> UpdateActiveCardApi([FromBody] GenerateCardByOrderCommand request, [AsParameters] EWarrantyService ewarrantyService)
        {
            try
            {
                var result = await ewarrantyService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(GenerateCardByOrderCommand)}");
                return TypedResults.Ok(result);
            }
            catch (Exception)
            {
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetSSRWarrantiesApi([FromBody] GetSSRWarrantyQuery request, [AsParameters] EWarrantyService ewarrantyService)
        {
            try
            {
                var result = await ewarrantyService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(GetSSRWarrantyQuery)}");
                return TypedResults.Ok(result);
            }
            catch (Exception)
            {
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
    }
}
