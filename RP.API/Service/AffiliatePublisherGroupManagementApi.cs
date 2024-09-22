using System.Net;
using GoSell.Affiliate.PublisherGroupManagement.Application.Commands;
using GoSell.Affiliate.PublisherGroupManagement.Application.Queries;
using GoSell.Affiliate.PublisherGroupManagement.Models.Responses;
using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Api;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

namespace GoSell.API.Service
{
    public static class AffiliatePublisherGroupManagementApi
    {
        public static async Task<Results<Ok<GenericResponse<ListPublishGroupHistoryResponse>>, BadRequest<BaseResponse>>> FilterListPublishGroupHistoryAsync(
            IMediator mediator,
            [FromHeader] string langKey,
            IBaseApi baseApi,
            [FromBody] FilterListPublishedGroupHistoryQuery query)
        {
            query.ModifiedUserName = baseApi.User.DisplayName;
            var result = await mediator.Send(query);
            Log.Logger.Information($"DONE {nameof(FilterListPublishGroupHistoryAsync)}");
            return TypedResults.Ok(new GenericResponse<ListPublishGroupHistoryResponse>(HttpStatusCode.OK, "Request succeeded", result));
        }

        public static async Task<Results<Ok<GenericResponse<ListGroupPublisherResponse>>, BadRequest<BaseResponse>>> GetListGroupPublishersAsync(
            IMediator mediator,
            [FromHeader] string langKey,
            IBaseApi baseApi,
            [FromBody] FilterListPublisherGroupQuery query)
        {
            query.ModifiedUserName = baseApi.User.DisplayName;
            query.GosellStoreId = baseApi.User.StoreId;

            var result = await mediator.Send(query);
            Log.Logger.Information($"DONE {nameof(GetListGroupPublishersAsync)}");
            return TypedResults.Ok(new GenericResponse<ListGroupPublisherResponse>(HttpStatusCode.OK, "Request succeeded", result));
        }

        public static async Task<Results<Ok<GenericResponse<GroupPublisherResponse>>, BadRequest<BaseResponse>>> GetAffiliateGroupPublishersAsync(
            IMediator mediator,
            [FromHeader] string langKey,
            IBaseApi baseApi,
            [FromRoute] long groupId)
        {
            var query = new GetAffiliateGroupPublisherQuery(groupId);
            var data = await mediator.Send(query);

            var isSuccess = data is not null;
            if (!isSuccess)
            {
                Log.Logger.Information($"DONE - Request failured - {nameof(GetAffiliateGroupPublishersAsync)}");
                return TypedResults.BadRequest(new BaseResponse(HttpStatusCode.BadRequest, "Request failured"));
            }

            var result = new GroupPublisherResponse()
            {
                IsSuccess = isSuccess,
                Data = data
            };

            Log.Logger.Information($"DONE {nameof(GetAffiliateGroupPublishersAsync)}");
            return TypedResults.Ok(new GenericResponse<GroupPublisherResponse>(HttpStatusCode.OK, "Request succeeded", result));
        }

        public static async Task<Results<Ok<GenericResponse<CreateGroupPublisherResponse>>, BadRequest<BaseResponse>>> CreateGroupPublisherAsync(
            IMediator mediator,
            [FromHeader] string langKey,
            IBaseApi baseApi,
            [FromBody] CreateGroupPublisherCommand command)
        {
            command.ModifiedUserName = baseApi.User.DisplayName;
            var groupId = await mediator.Send(command);
            bool isSuccess = groupId > 0;
            if (!isSuccess)
            {
                Log.Logger.Information($"DONE - Request failured - {nameof(CreateGroupPublisherAsync)}");
                return TypedResults.BadRequest(new BaseResponse(HttpStatusCode.BadRequest, "Request failured"));
            }

            var result = new CreateGroupPublisherResponse()
            {
                IsSuccess = isSuccess,
                Data = groupId,
            };
            Log.Logger.Information($"DONE {nameof(CreateGroupPublisherAsync)}");
            return TypedResults.Ok(new GenericResponse<CreateGroupPublisherResponse>(HttpStatusCode.OK, "Request succeeded", result));
        }

        public static async Task<Results<Ok<GenericResponse<SuccessResponse>>, BadRequest<BaseResponse>>> DeleteGroupPublisherAsync(
            IMediator mediator,
            [FromHeader] string langKey,
            IBaseApi baseApi,
            [FromBody] DeleteGroupPublisherCommand command)
        {
            command.ModifiedUserName = baseApi.User.DisplayName;
            var result = await mediator.Send(command);
            Log.Logger.Information($"DONE {nameof(DeleteGroupPublisherAsync)}");
            return TypedResults.Ok(new GenericResponse<SuccessResponse>(HttpStatusCode.OK, "Request succeeded", result));
        }

        public static async Task<Results<Ok<GenericResponse<SuccessResponse>>, BadRequest<BaseResponse>>> InsertPublisherToGroupAsync(
            IMediator mediator,
            [FromHeader] string langKey,
            IBaseApi baseApi,
            [FromBody] InsertPublisherToGroupCommand command)
        {
            command.ModifiedUserName = baseApi.User.DisplayName;
            var result = await mediator.Send(command);
            Log.Logger.Information($"DONE {nameof(InsertPublisherToGroupAsync)}");
            return TypedResults.Ok(new GenericResponse<SuccessResponse>(HttpStatusCode.OK, "Request succeeded", result));
        }

        public static async Task<Results<Ok<GenericResponse<SuccessResponse>>, BadRequest<BaseResponse>>> PublishGroupPublisherAsync(
            IMediator mediator,
            [FromHeader] string langKey,
            IBaseApi baseApi,
            [FromBody] PublishGroupPublisherCommand command)
        {
            command.ModifiedUserName = baseApi.User.DisplayName;
            var isSuccess = await mediator.Send(command);
            if (!isSuccess)
            {
                Log.Logger.Information($"DONE - Request failured - {nameof(PublishGroupPublisherAsync)}");
                return TypedResults.BadRequest(new BaseResponse(HttpStatusCode.BadRequest, "Request failured"));
            }

            var result = new SuccessResponse(isSuccess);
            Log.Logger.Information($"DONE {nameof(PublishGroupPublisherAsync)}");
            return TypedResults.Ok(new GenericResponse<SuccessResponse>(HttpStatusCode.OK, "Request succeeded", result));
        }

        public static async Task<Results<Ok<GenericResponse<SuccessResponse>>, BadRequest<BaseResponse>>> RemovePublisherFromGroupAsync(
            IMediator mediator,
            [FromHeader] string langKey,
            IBaseApi baseApi,
            [FromBody] RemovePublisherFromGroupCommand command)
        {
            command.ModifiedUserName = baseApi.User.DisplayName;
            var result = await mediator.Send(command);
            Log.Logger.Information($"DONE {nameof(RemovePublisherFromGroupAsync)}");
            return TypedResults.Ok(new GenericResponse<SuccessResponse>(HttpStatusCode.OK, "Request succeeded", result));
        }

        public static async Task<Results<Ok<GenericResponse<SuccessResponse>>, BadRequest<BaseResponse>>> UpdateGroupPublisherAsync(
            IMediator mediator,
            [FromHeader] string langKey,
            IBaseApi baseApi,
            [FromBody] UpdateGroupPublisherCommand command)
        {
            command.ModifiedUserName = baseApi.User.DisplayName;
            var isSuccess = await mediator.Send(command);
            if (!isSuccess)
            {
                Log.Logger.Information($"DONE - Request failured - {nameof(UpdateGroupPublisherAsync)}");
                return TypedResults.BadRequest(new BaseResponse(HttpStatusCode.BadRequest, "Request failured"));
            }

            var result = new SuccessResponse(isSuccess);
            Log.Logger.Information($"DONE {nameof(UpdateGroupPublisherAsync)}");
            return TypedResults.Ok(new GenericResponse<SuccessResponse>(HttpStatusCode.OK, "Request succeeded", result));
        }

        public static async Task<Results<Ok<GenericResponse<ListPublisherResponse>>, BadRequest<BaseResponse>>> GetListPublishersAsync(
            IMediator mediator,
            [FromHeader] string langKey,
            IBaseApi baseApi,
            [FromBody] GetListPublishersQuery query)
        {
            query.ModifiedUserName = baseApi.User.DisplayName;
            var result = await mediator.Send(query);
            Log.Logger.Information($"DONE {nameof(GetListPublishersAsync)}");
            return TypedResults.Ok(new GenericResponse<ListPublisherResponse>(HttpStatusCode.OK, "Request succeeded", result));
        }
    }
}
