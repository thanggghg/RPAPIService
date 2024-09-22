using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Api;
using GoSell.Library.Helpers.Pagination;
using GoSell.Payments.Application.Commands.Payments;
using GoSell.Payments.Commands.MposDevices;
using GoSell.Payments.Models.Results;
using GoSell.Payments.Queries.Payments;
using GoSell.Payments.Services.MposDevices;
using GoSell.Payments.Services.Payment;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GoSell.API.Service
{
    public static class MposDevicesApi
    {
        public static async Task<Results<Ok<GenericResponse<MposDeviceResultModel>>, BadRequest<string>>> CreateMposDeviceAsync(
            CreateMposDeviceRequest request,
            [AsParameters] MposDevicesService mposDevicesService,
            IBaseApi baseApi)
        {
            var input = new CreateMposDeviceCommand(request.mposId, request.merchantStoreId, request.posName, request.branchId, baseApi.User.Sub);
            var res = await mposDevicesService.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<GenericResponse<MposDeviceResultModel>>, BadRequest<string>>> UpdateMposDeviceAsync(
            long id,
            [FromBody] UpdateMposDeviceRequest request,
            [AsParameters] MposDevicesService mposDevicesService,
            IBaseApi baseApi)
        {
            var input = new UpdateMposDeviceCommand(id, request.mposId, request.merchantStoreId, request.posName, request.branchId, request.isActive, baseApi.User.Sub);
            var res = await mposDevicesService.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<GenericResponse<MposDeviceResultModel>>, BadRequest<string>>> ChangeMposDeviceAsync(
            long id,
            [FromBody] ChangeStatusMposDeviceRequest request,
            [AsParameters] MposDevicesService mposDevicesService,
            IBaseApi baseApi)
        {
            var input = new ChangeStatusMposDeviceCommand(id, request.isActive, baseApi.User.Sub);
            var res = await mposDevicesService.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> DeleteMposDeviceAsync(
            long id,
            [AsParameters] MposDevicesService mposDevicesService,
            IBaseApi baseApi)
        {
            var input = new DeleteMposDeviceCommand(id, baseApi.User.Sub);
            var res = await mposDevicesService.Mediator.Send(input);
            return TypedResults.Ok(res);
        }
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetListMposDevicesByStoreIdAsync(
            long id,
            [AsParameters] MposDevicesService mposDevicesService)
        {
            var input = new GetListMposDeviceActiveByStoreCommand(id);
            var res = await mposDevicesService.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetListMposDeviceActiveByBranchAsync(long id, [AsParameters] PaymentService paymentSerivce)
        {
            var input = new GetListMposDeviceActiveByBranchCommand(id);
            var res = await paymentSerivce.Mediator.Send(input);
            return TypedResults.Ok(res);
        }
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetMposDeviceByIdAsync(long id, [AsParameters] PaymentService paymentSerivce)
        {
            var input = new GetMposDeviceByIdCommand(id);
            var res = await paymentSerivce.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CheckMposIdAsync(string id, [AsParameters] MposDevicesService mposDevicesService, IBaseApi baseApi)
        {
            var input = new CheckMposIdCommand(id, baseApi.User.StoreId);
            var res = await mposDevicesService.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CheckMposDeviceNameAsync(string name, long branchId, [AsParameters] MposDevicesService mposDevicesService)
        {
            var input = new CheckMposDeviceNameCommand(name, branchId);
            var res = await mposDevicesService.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<PagingItems<MposDeviceResultModel>>, BadRequest<string>>> GetMposDeviceAsync([AsParameters] GetMposDeviceRequest request, [AsParameters] MposDevicesService mposDevicesService, IBaseApi baseApi)
        {
            var query = new GetMposDeviceQuery
            {
                StoreId = baseApi.User.StoreId,
                BranchId = request.BranchId,
                IsActive = request.IsActive,
                Keyword = request.Keyword,
                SearchType = request.SearchType,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
            };
            var res = await mposDevicesService.Mediator.Send(query);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CheckMposDeviceAsync([AsParameters] CheckMposDeviceAsyncRequest request, [AsParameters] MposDevicesService mposDevicesService)
        {
            var query = new CheckMposDeviceCommand(request.mposDeviceId, request.branchId);
            var res = await mposDevicesService.Mediator.Send(query);
            return TypedResults.Ok(res);
        }

        public record CreateMposDeviceRequest(
        long merchantStoreId,
        string mposId,
        long branchId,
        string posName);
        public record UpdateMposDeviceRequest(
        long merchantStoreId,
        string mposId,
        long branchId,
        string posName,
        bool? isActive
        );
        public record ChangeStatusMposDeviceRequest(
        bool isActive
        );

        public record CheckMposDeviceAsyncRequest(
        long mposDeviceId,
        long branchId
        );
    }
}
