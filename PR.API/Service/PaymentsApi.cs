using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Api;
using GoSell.Payments.Application.Commands.Payments;
using GoSell.Payments.Helpers.MPOS.Models.Result;
using GoSell.Payments.Queries.Payments;
using GoSell.Payments.Services.Payment;
using Microsoft.AspNetCore.Http.HttpResults;
namespace GoSell.API.Service
{
    public static class PaymentsApi
    {
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CreatePaymentAsync(CreatePaymentRequest request, [AsParameters] PaymentService paymentSerivce)
        {
            var input = new CreatePaymentCommand(request.PaymentMposId, request.StoreId, request.OrderId, request.Amount);
            var res = await paymentSerivce.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CancelPaymentAsync([FromBody] CancelPaymentRequest request, [AsParameters] PaymentService paymentSerivce, IBaseApi baseApi)
        {
            var input = new CancelPaymentCommand(request.PaymentMposId, baseApi.User.StoreId, request.OrderId, request.Amount);
            var res = await paymentSerivce.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CancelPaymentMposOnlyAsync(CancelPaymentMposOnlyRequest request, [AsParameters] PaymentService paymentSerivce)
        {
            var input = new CancelPaymentMposOnlyCommand(request.PaymentMposId, request.StoreId, request.OrderId, request.Amount, true);
            var res = await paymentSerivce.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetTransactionPaymentStatusAsync([AsParameters] GetTransactionPaymentStatusRequest request, [AsParameters] PaymentService paymentSerivce, IBaseApi baseApi)
        {
            var input = new GetTransactionPaymentStatusCommand(request.PaymentMposId, baseApi.User.StoreId, request.OrderId, request.Amount);
            var res = await paymentSerivce.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetTransactionPaymentStatusAdminAsync([AsParameters] GetTransactionPaymentStatusAdminRequest request, [AsParameters] PaymentService paymentSerivce)
        {
            var input = new GetTransactionPaymentStatusAdminCommand(request.StoreId, request.OrderId, request.BcOrderGroupId, request.Amount);
            var res = await paymentSerivce.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<UpdateTransactionPaymentStatusResponse>, BadRequest<string>>> UpdateTransactionPaymentStatusAsync(UpdateTransactionPaymentStatusCommand request, [AsParameters] PaymentService paymentSerivce)
        {
            var result = await paymentSerivce.Mediator.Send(request);
            return TypedResults.Ok(result);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CreateConfigPaymentMethodAsync([FromBody] CreateConfigPaymentMethodMposRequest request, [AsParameters] PaymentService paymentSerivce, IBaseApi baseApi)
        {
            var input = new CreateConfigPaymentMethodMposCommand(baseApi.User.StoreId, request.MerchantId, request.SecretKey, request.IsEnabled, baseApi.User.Sub);
            var result = await paymentSerivce.Mediator.Send(input);
            return TypedResults.Ok(result);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> UppdateConfigPaymentMethodAsync(long id, [FromBody] UpdateConfigPaymentMethodMposRequest request, [AsParameters] PaymentService paymentSerivce, IBaseApi baseApi)
        {
            var input = new UpdateConfigPaymentMethodMposCommand(id, baseApi.User.StoreId, request.MerchantId, request.SecretKey, request.IsEnabled, baseApi.User.Sub);
            var result = await paymentSerivce.Mediator.Send(input);
            return TypedResults.Ok(result);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> ChangeConfigMposStatus(long id, [FromBody] UpdateConfigPaymentMethodMposRequest request, [AsParameters] PaymentService paymentSerivce, IBaseApi baseApi)
        {
            var input = new UpdateConfigPaymentMethodMposStatusCommand(id, baseApi.User.StoreId, request.IsEnabled, baseApi.User.Sub);
            var result = await paymentSerivce.Mediator.Send(input);
            return TypedResults.Ok(result);
        }

        public static async Task<Results<Ok<GenericResponse<ConfigPaymentMethodResponse>>, BadRequest<string>>> GetConfigPaymentMethodAsync([AsParameters] PaymentService paymentSerivce, IBaseApi baseApi)
        {
            var query = new GetConfigPaymentMethodQuery(baseApi.User.StoreId);
            var result = await paymentSerivce.Mediator.Send(query);
            return TypedResults.Ok(result);
        }


        public record CreatePaymentRequest(
        long PaymentMposId,
        int StoreId,
        string OrderId,
        long Amount);

        public record CancelPaymentRequest(
        long PaymentMposId,
        string OrderId,
        long Amount);

        public record CancelPaymentMposOnlyRequest(
        long PaymentMposId,
        int StoreId,
        string OrderId,
        long Amount);

        public record GetTransactionPaymentStatusRequest(
        long PaymentMposId,
        long OrderId,
        long Amount);

        public record GetTransactionPaymentStatusAdminRequest(
        int StoreId,
        long OrderId,
        long BcOrderGroupId,
        long Amount);

        public record CreateConfigPaymentMethodMposRequest(
        string MerchantId,
        string SecretKey,
        bool IsEnabled);

        public record UpdateConfigPaymentMethodMposRequest(
        string MerchantId,
        string SecretKey,
        bool IsEnabled);

        public record ChangeConfigPaymentMethodMposStatusRequest(
        bool IsEnabled);
    }
}
