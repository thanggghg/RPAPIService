using System.Net;
using GoSell.FBBulkPosting.Application.Commands;
using GoSell.FBBulkPosting.Application.Queries;
using GoSell.FBBulkPosting.Database.Entities;
using GoSell.FBBulkPosting.Models.Reponses;
using GoSell.FBBulkPosting.Queries;
using GoSell.FBBulkPosting.Service;
using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Api;
using GoSell.Library.Helpers.Pagination;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

namespace GoSell.API.Service
{
    public static class FBBulkPostingApi
    {
        public static async Task<Results<Ok<BaseResponseCode>, BadRequest<string>>> CreateAsync(
            [FromBody] CreateBulkPostingRequest request,
            [AsParameters] FBBulkPostingService fbBulkPostingService,
            IBaseApi baseApi)
        {
            var command = new CreateBulkPostingCommand
            {
                PostName = request.PostName,
                PostContent = request.PostContent,
                PublishType = request.PublishType,
                ScheduleTime = request.ScheduleTime,
                Images = request.Images,
                StoreId = baseApi.User.StoreId,
                UserLogin = baseApi.User.Sub,
                StoreChats = request.StoreChats,
                IsPublish = false
            };
            var result = await fbBulkPostingService.Mediator.Send(command);
            Log.Logger.Information($"DONE FBBulkPostingApiCreateAsync");
            return TypedResults.Ok(result);
        }

        public static async Task<Results<Ok<GenericResponse<PagingItems<GetBulkPostingResponse>>>, BadRequest<string>>> GetAllBulkPoseAsync(
           [AsParameters] GetAllBulkPostQuery request,
           [AsParameters] FBBulkPostingService services)
        {
            try
            {
                var result = await services.Mediator.Send(request);
                return TypedResults.Ok(new GenericResponse<PagingItems<GetBulkPostingResponse>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllBulkPoseAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<PagingItems<GetBulkPostingResponse>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<BaseResponseCode>, BadRequest<string>>> UpdateAsync(
            [FromBody] EditBulkPostingRequest request,
            [AsParameters] FBBulkPostingService fbBulkPostingService,
            IBaseApi baseApi)
        {
            var command = new EditBulkPostingCommand
            {
                Id = request.Id,
                PostName = request.PostName,
                PostContent = request.PostContent,
                PublishType = request.PublishType,
                ScheduleTime = request.ScheduleTime,
                Images = request.Images,
                StoreId = baseApi.User.StoreId,
                UserLogin = baseApi.User.Sub,
                StoreChats = request.StoreChats,
                IsPublish = false
            };
            var result = await fbBulkPostingService.Mediator.Send(command);
            Log.Logger.Information($"DONE FBBulkPostingApiUpdateAsync");
            return TypedResults.Ok(result);
        }

        public static async Task<Results<Ok<BaseResponseCode>, BadRequest<string>>> SaveAndPublishAsync(
            [FromBody] SaveAndPublishBulkPostingRequest request,
            [AsParameters] FBBulkPostingService fbBulkPostingService,
            IBaseApi baseApi)
        {
            BaseResponseCode result;
            if (request.Id.HasValue && request.Id > 0)
            {
                var command = new EditBulkPostingCommand
                {
                    Id = request.Id.Value,
                    PostName = request.PostName,
                    PostContent = request.PostContent,
                    PublishType = request.PublishType,
                    ScheduleTime = request.ScheduleTime,
                    Images = request.Images,
                    StoreId = baseApi.User.StoreId,
                    UserLogin = baseApi.User.Sub,
                    StoreChats = request.StoreChats,
                    IsPublish = true
                };
                result = await fbBulkPostingService.Mediator.Send(command);
            }
            else
            {
                var command = new CreateBulkPostingCommand
                {
                    PostName = request.PostName,
                    PostContent = request.PostContent,
                    PublishType = request.PublishType,
                    ScheduleTime = request.ScheduleTime,
                    Images = request.Images,
                    StoreId = baseApi.User.StoreId,
                    UserLogin = baseApi.User.Sub,
                    StoreChats = request.StoreChats,
                    IsPublish = true
                };
                result = await fbBulkPostingService.Mediator.Send(command);
            }

            Log.Logger.Information($"DONE FBBulkPostingApiSaveAndPublishAsync");
            return TypedResults.Ok(result);
        }

        public static async Task<Results<Ok<BaseResponseCode>, BadRequest<string>>> DeleteBulkPostAsync(
            [FromBody] DeleteBulkPostingRequest request,
            [AsParameters] FBBulkPostingService fbBulkPostingService,
            IBaseApi baseApi)
        {
            var command = new DeleteBulkPostingCommand
            {
                Id = request.Id,
                StoreId = baseApi.User.StoreId,
                UserLogin = baseApi.User.Sub
            };
            var result = await fbBulkPostingService.Mediator.Send(command);
            Log.Logger.Information($"DONE FBBulkPostingApiDeleteBulkPostDetailAsync");
            return TypedResults.Ok(result);
        }

        public static async Task<Results<Ok<BaseResponseCode>, BadRequest<string>>> DeleteBulkPostDetailAsync(
            [FromBody] DeleteBulkPostingDetailRequest request,
            [AsParameters] FBBulkPostingService fbBulkPostingService,
            IBaseApi baseApi)
        {
            var command = new DeleteBulkPostingDetailCommand
            {
                Id = request.Id,
                StoreId = baseApi.User.StoreId,
                UserLogin = baseApi.User.Sub
            };
            var result = await fbBulkPostingService.Mediator.Send(command);
            Log.Logger.Information($"DONE FBBulkPostingApiDeleteBulkPostDetailAsync");
            return TypedResults.Ok(result);
        }

        public static async Task<Results<Ok<BaseResponseCode>, BadRequest<string>>> GetBulkPostAsync(
            long id,
            [AsParameters] FBBulkPostingService fbBulkPostingService,
            IBaseApi baseApi)
        {
            var command = new GetBulkPostingQuery
            {
                Id = id,
                StoreId = baseApi.User.StoreId
            };
            var result = await fbBulkPostingService.Mediator.Send(command);
            Log.Logger.Information($"DONE FBBulkPostingApiGetBulkPostAsync");
            return TypedResults.Ok(result);
        }
    }
}
