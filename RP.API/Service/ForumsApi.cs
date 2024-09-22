using System.Net;
using DocumentFormat.OpenXml.Wordprocessing;
using GoSell.Common.Models;
using GoSell.EWarranty.Queries;
using GoSell.Forum.Commands;
using GoSell.Forum.Commands.StoreFront;
using GoSell.Forum.Models.Results;
using GoSell.Forum.Queries;
using GoSell.Forum.Queries.StoreFront;
using GoSell.Forum.Services;
using GoSell.Library.Exceptions;
using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Api;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

namespace GoSell.API.Service
{
    public static class ForumApis
    {
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CreateCategoryAsync([FromBody] CreateCategoryCommand request, [AsParameters] ForumService forumService)
        {
            try
            {
                var result = await forumService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(CreateCategoryCommand)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateCategoryAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> UpdateCategoryAsync([FromBody] UpdateCategoryCommand request, [AsParameters] ForumService forumService)
        {
            try
            {
                var result = await forumService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(UpdateCategoryCommand)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateCategoryAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> UpdateIsBlockedCategoryAsync([FromBody] UpdateIsBlockedCategoryCommand request, [AsParameters] ForumService forumService)
        {
            try
            {
                var result = await forumService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(UpdateIsBlockedCategoryCommand)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateIsBlockedCategoryAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetCategoriesAsync([FromBody] GetCategoriesQuery request, [AsParameters] ForumService forumService)
        {
            try
            {

                var result = await forumService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(GetCategoriesQuery)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetCategoriesAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<object>>> GetHomePageCategoriesAsync([FromBody] GetHomePageCategoriesQuery request, [AsParameters] ForumService forumService)
        {
            try
            {
                var result = await forumService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(GetHomePageCategoriesQuery)}");
                return TypedResults.Ok(result);
            }
            catch (ForumException ex)
            {
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = ex.MessageCode
                };
                Log.Logger.Error(ex, $"FAIL {nameof(GetHomePageCategoriesAsync)} : {ex.Message}");
                return TypedResults.BadRequest<object>(responseException);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetHomePageCategoriesAsync)} : {ex.Message}");
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = string.Empty,
                };
                return TypedResults.BadRequest<object>(responseException);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetCategoryAsync([FromRoute] long categoryId, [AsParameters] ForumService forumService)
        {
            try
            {
                var result = await forumService.Mediator.Send(new GetCategoryDetailQuery { CategoryId = categoryId });
                Log.Logger.Information($"DONE {nameof(GetCategoryDetailQuery)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetCategoryAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CreatePostAsync(
           CreatePostCommand request,
           IMediator mediator)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Content))
                {
                    return TypedResults.Ok(new BaseResponse()
                    {
                        Message = "Content cannot be empty",
                        Code = HttpStatusCode.BadRequest
                    });
                }
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(CreatePostAsync)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreatePostAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetPostDetailAsync(
            [FromRoute] long postId,
            IMediator mediator)
        {
            try
            {
                var result = await mediator.Send(new GetPostDetailQuery(postId));
                Log.Logger.Information($"DONE {nameof(GetPostDetailAsync)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetPostDetailAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetPostByFilterAsync(
           GetPostByFilterQuery request,
           IMediator mediator)
        {
            try
            {
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(GetPostByFilterAsync)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetPostByFilterAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> UpdatePostAsync(
           UpdatePostCommand request,
           IMediator mediator)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Content))
                {
                    return TypedResults.Ok(new BaseResponse()
                    {
                        Message = "Content cannot be empty",
                        Code = HttpStatusCode.BadRequest
                    });
                }

                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(UpdatePostAsync)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdatePostAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> UpdateIsBlockedPostAsync(
          UpdateIsBlockedPostCommand request,
          IMediator mediator)
        {
            try
            {
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(UpdateIsBlockedPostAsync)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateIsBlockedPostAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> DeletedPostAsync(
          DeletePostCommand request,
          IMediator mediator)
        {
            try
            {
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(DeletedPostAsync)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(DeletedPostAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CreateTopicAsync([FromBody] CreateTopicCommand request, IMediator mediator)
        {
            try
            {
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(CreateTopicAsync)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateTopicAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> UpdateTopicAsync([FromBody] UpdateTopicCommand request, IMediator mediator)
        {
            try
            {
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(UpdateTopicAsync)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateTopicAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> SendExpiredEmail([FromBody] SendRemindExpiredPackageEmailCommand request, IMediator mediator)
        {
            try
            {
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(SendExpiredEmail)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(SendExpiredEmail)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<GenericResponse<PaginatedList<TopicData>>>, BadRequest<string>>> GetTopicsAsync([FromBody] GetTopicsQuery request, IMediator mediator)
        {
            try
            {

                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(GetTopicsAsync)}");

                return TypedResults.Ok(new GenericResponse<PaginatedList<TopicData>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetTopicsAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<PaginatedList<TopicData>>(HttpStatusCode.BadRequest, "Request failed"));

            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetTopicAsync([FromRoute] long topicId, IMediator mediator)
        {
            try
            {
                var result = await mediator.Send(new GetTopicDetailQuery { TopicId = topicId });
                Log.Logger.Information($"DONE {nameof(GetTopicAsync)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetTopicAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetConfigurationAsync([FromRoute] long storeId, IMediator mediator)
        {
            try
            {
                var result = await mediator.Send(new GetConfigurationQuery { StoreId = storeId });
                Log.Logger.Information($"DONE {nameof(GetConfigurationAsync)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetConfigurationAsync)} : {ex.Message}");
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> UpdateConfigurationAsync([FromBody] UpdateConfigurationCommand request, IMediator mediator)
        {
            try
            {
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(UpdateConfigurationAsync)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateConfigurationAsync)} : {ex.Message}");
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> UpdateIsBlockedTopicAsync(
          UpdateIsBlockedTopicCommand request,
          IMediator mediator)
        {
            try
            {
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(UpdateIsBlockedTopicAsync)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateIsBlockedTopicAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CheckUrlIsDuplicate([FromQuery] long referenceId, [FromQuery] string url, IMediator mediator)
        {
            try
            {
                var result = await mediator.Send(new CheckUrlIsDuplicateQuery() { ReferenceId = referenceId, Url = url });
                Log.Logger.Information($"DONE {nameof(CheckUrlIsDuplicate)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CheckUrlIsDuplicate)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<object>>> GetHomePageLatestPostsAsync(
            [FromBody] GetHomePageLatestPostsQuery request,
            [AsParameters] ForumService forumService)
        {
            try
            {
                var result = await forumService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(GetHomePageLatestPostsAsync)}");
                return TypedResults.Ok(result);
            }
            catch (ForumException ex)
            {
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = ex.MessageCode
                };
                Log.Logger.Error(ex, $"FAIL {nameof(GetHomePageLatestPostsAsync)} : {ex.Message}");
                return TypedResults.BadRequest<object>(responseException);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetHomePageLatestPostsAsync)} : {ex.Message}");
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = string.Empty,
                };
                return TypedResults.BadRequest<object>(responseException);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<object>>> GetHomePageLatestCommentsAsync(
            [FromBody] GetHomePageLatestCommentsQuery request,
            [AsParameters] ForumService forumService)
        {
            try
            {
                var result = await forumService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(GetHomePageLatestCommentsAsync)}");
                return TypedResults.Ok(result);
            }
            catch (ForumException ex)
            {
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = ex.MessageCode
                };
                Log.Logger.Error(ex, $"FAIL {nameof(GetHomePageLatestCommentsAsync)} : {ex.Message}");
                return TypedResults.BadRequest<object>(responseException);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetHomePageLatestCommentsAsync)} : {ex.Message}");
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = string.Empty,
                };
                return TypedResults.BadRequest<object>(responseException);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<object>>> GetTopicLatestPostsAsync(
            [FromRoute] long topicId,
            [FromBody] GetTopicLatestPostsQuery request,
            [AsParameters] ForumService forumService)
        {
            try
            {
                request.TopicId = topicId;
                var result = await forumService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(GetTopicLatestPostsAsync)}");
                return TypedResults.Ok(result);
            }
            catch (ForumException ex)
            {
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = ex.MessageCode
                };
                Log.Logger.Error(ex, $"FAIL {nameof(GetTopicLatestPostsAsync)} : {ex.Message}");
                return TypedResults.BadRequest<object>(responseException);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetTopicLatestPostsAsync)} : {ex.Message}");
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = string.Empty,
                };
                return TypedResults.BadRequest<object>(responseException);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<object>>> GetTopicLatestCommentsAsync(
            [FromRoute] long topicId,
            [FromBody] GetTopicLatestCommentsQuery request,
            [AsParameters] ForumService forumService)
        {
            try
            {
                request.TopicId = topicId;
                var result = await forumService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(GetTopicLatestCommentsAsync)}");
                return TypedResults.Ok(result);
            }
            catch (ForumException ex)
            {
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = ex.MessageCode
                };
                Log.Logger.Error(ex, $"FAIL {nameof(GetTopicLatestCommentsAsync)} : {ex.Message}");
                return TypedResults.BadRequest<object>(responseException);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetTopicLatestCommentsAsync)} : {ex.Message}");
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = string.Empty,
                };
                return TypedResults.BadRequest<object>(responseException);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetForumCommentsAsync([FromBody] GetForumCommentQuery request, [AsParameters] ForumService forumService)
        {
            try
            {

                var result = await forumService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(GetForumCommentQuery)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetForumCommentsAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetCommentDetailAsync([FromRoute] long commentId, [AsParameters] ForumService forumService)
        {
            try
            {
                var result = await forumService.Mediator.Send(new GetForumCommentDetailQuery { CommentId = commentId });
                Log.Logger.Information($"DONE {nameof(GetForumCommentDetailQuery)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetCommentDetailAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetForumCommentByRepliesAsync([FromBody] GetForumCommentByRepliesByPostQuery request, [AsParameters] ForumService forumService)
        {
            try
            {

                var result = await forumService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(GetForumCommentByRepliesByPostQuery)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetForumCommentByRepliesAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CreateCommentsAsync([FromBody] CreateForumCommentCommand request, [AsParameters] ForumService forumService)
        {
            try
            {
                var result = await forumService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(CreateForumCommentCommand)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateCommentsAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<object>>> StoreFrontGetTopicAsync(
          [FromRoute] long topicId,
          IHttpContextAccessor httpContextAccessor,
          IMediator mediator)
        {
            try
            {
                long.TryParse(httpContextAccessor.HttpContext.Request.Headers["storeid"].FirstOrDefault(), out long storeId);
                var request = new TopicPageGetTopicQuery() { Id = topicId, StoreId = storeId };
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(StoreFrontGetTopicAsync)}");
                return TypedResults.Ok(result);
            }
            catch (ForumException ex)
            {
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = ex.MessageCode
                };
                Log.Logger.Error(ex, $"FAIL {nameof(StoreFrontGetTopicAsync)} : {ex.Message}");
                return TypedResults.BadRequest<object>(responseException);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(StoreFrontGetTopicAsync)} : {ex.Message}");
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = string.Empty,
                };
                return TypedResults.BadRequest<object>(responseException);
            }
        }

        public static async Task<Results<Ok<GenericResponse<object>>, BadRequest<object>>> CreatePostOnStoreFrontAsync(
           CreatePostOnStoreFrontCommand request,
           IMediator mediator
           )
        {
            try
            {
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(CreatePostOnStoreFrontAsync)}");

                return TypedResults.Ok(new GenericResponse<object>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (ForumException ex)
            {
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = ex.MessageCode
                };
                Log.Logger.Error(ex, $"FAIL {nameof(CreatePostOnStoreFrontAsync)} : {ex.Message}");
                return TypedResults.BadRequest<object>(responseException);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreatePostOnStoreFrontAsync)} : {ex.Message}");
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = string.Empty,
                };
                return TypedResults.BadRequest<object>(responseException);
            }
        }

        public static async Task<Results<Ok<GenericResponse<object>>, BadRequest<object>>> GetForumConfigAndPermissionAsync(
            IHttpContextAccessor httpContextAccessor,
            IMediator mediator,
            IBaseApi _baseApi)
        {
            try
            {
                long.TryParse(httpContextAccessor.HttpContext.Request.Headers["storeid"].FirstOrDefault(), out long storeId);
                var request = new GetForumConfigAndPermissionQuery
                {
                    UserId = _baseApi.User.UserId,
                    StoreId = storeId
                };
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(GetForumConfigAndPermissionAsync)}");

                return TypedResults.Ok(new GenericResponse<object>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(StoreFrontGetTopicAsync)} : {ex.Message}");
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = string.Empty,
                };
                return TypedResults.BadRequest<object>(responseException);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<object>>> StoreFrontGetPostsAsync(
          [FromBody] TopicPageGetPostsQuery request,
          IHttpContextAccessor httpContextAccessor,
          IMediator mediator)
        {
            try
            {
                long.TryParse(httpContextAccessor.HttpContext.Request.Headers["storeid"].FirstOrDefault(), out long storeId);
                request.StoreId = storeId;

                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(StoreFrontGetPostsAsync)}");
                return TypedResults.Ok(result);
            }
            catch (ForumException ex)
            {
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = ex.MessageCode
                };

                Log.Logger.Error(ex, $"FAIL {nameof(StoreFrontGetPostsAsync)} : {ex.Message}");
                return TypedResults.BadRequest<object>(responseException);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(StoreFrontGetPostsAsync)} : {ex.Message}");
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = string.Empty,
                };
                return TypedResults.BadRequest<object>(responseException);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> ApprovePostAsync([FromBody] ApprovePostCommand request, IMediator mediator)
        {
            try
            {
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(ApprovePostAsync)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(ApprovePostAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> RejectPostAsync([FromBody] RejectPostCommand request, IMediator mediator)
        {
            try
            {
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(RejectPostAsync)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(RejectPostAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> UpdateStatusCommentAsync(
          UpdateStatusCommentCommand request,
          IMediator mediator)
        {
            try
            {
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(UpdateStatusCommentAsync)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateStatusCommentAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetForumMembersAsync([FromBody] GetForumMemberQuery request, [AsParameters] ForumService forumService)
        {
            try
            {

                var result = await forumService.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(GetForumMemberQuery)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetForumMembersAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetForumMemberDetailAsync([FromRoute] long memberId, [AsParameters] ForumService forumService)
        {
            try
            {
                var result = await forumService.Mediator.Send(new GetForumMemberDetailQuery { MemberId = memberId });
                Log.Logger.Information($"DONE {nameof(GetForumMemberDetailQuery)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetCategoryAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<object>>> IsAllowCreateOrEditPostAsync(
          IsAllowCreateOrEditPostQuery request,
          IHttpContextAccessor httpContextAccessor,
          IMediator mediator)
        {
            try
            {
                long.TryParse(httpContextAccessor.HttpContext.Request.Headers["storeid"].FirstOrDefault(), out long storeId);
                request.StoreId = storeId;
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(IsAllowCreateOrEditPostAsync)}");
                return TypedResults.Ok(result);
            }
            catch (ForumException ex)
            {
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = ex.MessageCode
                };
                Log.Logger.Error(ex, $"FAIL {nameof(IsAllowCreateOrEditPostAsync)} : {ex.Message}");
                return TypedResults.BadRequest<object>(responseException);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(IsAllowCreateOrEditPostAsync)} : {ex.Message}");
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = string.Empty,
                };
                return TypedResults.BadRequest<object>(responseException);
            }
        }

        public static async Task<Results<Ok<GenericResponse<bool>>, BadRequest<object>>> UpdatePostOnStoreFrontAsync(
           UpdatePostOnStoreFrontCommand request,
           IHttpContextAccessor httpContextAccessor,
           IMediator mediator
           )
        {
            try
            {
                long.TryParse(httpContextAccessor.HttpContext.Request.Headers["storeid"].FirstOrDefault(), out long storeId);
                request.StoreId = storeId;
                bool isSuccess = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(UpdatePostOnStoreFrontAsync)}");
                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.OK, "Request successfully", isSuccess));
            }
            catch (ForumException ex)
            {
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = ex.MessageCode
                };
                Log.Logger.Error(ex, $"FAIL {nameof(UpdatePostOnStoreFrontAsync)} : {ex.Message}");
                return TypedResults.BadRequest<object>(responseException);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdatePostOnStoreFrontAsync)} : {ex.Message}");
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = string.Empty,
                };
                return TypedResults.BadRequest<object>(responseException);
            }
        }

        public static async Task<Results<Ok<GenericResponse<bool>>, BadRequest<object>>> DeletePostOnStoreFrontAsync(
           [FromBody] DeletePostOnStoreFrontCommand request,
           IHttpContextAccessor httpContextAccessor,
           IMediator mediator
           )
        {
            try
            {
                long.TryParse(httpContextAccessor.HttpContext.Request.Headers["storeid"].FirstOrDefault(), out long storeId);
                request.StoreId = storeId;
                bool isSuccess = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(DeletePostOnStoreFrontAsync)}");
                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.OK, "Request successfully", isSuccess));
            }
            catch (ForumException ex)
            {
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = ex.MessageCode
                };
                Log.Logger.Error(ex, $"FAIL {nameof(DeletePostOnStoreFrontAsync)} : {ex.Message}");
                return TypedResults.BadRequest<object>(responseException);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(DeletePostOnStoreFrontAsync)} : {ex.Message}");
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = string.Empty,
                };
                return TypedResults.BadRequest<object>(responseException);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> UpdateStatusMemberAsync(
          UpdateStatusMemberCommand request,
          IMediator mediator)
        {
            try
            {
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(UpdateStatusMemberAsync)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateStatusMemberAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CreateMemberAsync(
          UpdateStatusMemberCommand request,
          IMediator mediator)
        {
            try
            {
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(CreateMemberAsync)}");
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateMemberAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<object>>> GetPostDetailOnStoreFrontAsync(
            IHttpContextAccessor httpContextAccessor,
            IMediator mediator,
            [FromRoute] long postId
        )
        {
            try
            {
                long.TryParse(httpContextAccessor.HttpContext.Request.Headers["storeid"].FirstOrDefault(), out long storeId);
                var result = await mediator.Send(new PostPageGetPostDetailQuery() { Id = postId, StoreId = storeId });
                Log.Logger.Information($"DONE {nameof(PostPageGetPostDetailQuery)}");
                return TypedResults.Ok(result);
            }
            catch (ForumException ex)
            {
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = ex.MessageCode
                };
                Log.Logger.Error(ex, $"FAIL {nameof(GetPostDetailOnStoreFrontAsync)} : {ex.Message}");
                return TypedResults.BadRequest<object>(responseException);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetPostDetailOnStoreFrontAsync)} : {ex.Message}");
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = string.Empty,
                };
                return TypedResults.BadRequest<object>(responseException);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<object>>> GetCommentsFilterOnStoreFrontAsync(
            IHttpContextAccessor httpContextAccessor,
            IMediator mediator,
            [FromRoute] long postId,
            [FromBody] PostPageGetCommentsQuery request
        )
        {
            try
            {
                long.TryParse(httpContextAccessor.HttpContext.Request.Headers["storeid"].FirstOrDefault(), out long storeId);
                request.StoreId = storeId;
                request.PostId = postId;

                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(PostPageGetCommentsQuery)}");
                return TypedResults.Ok(result);
            }
            catch (ForumException ex)
            {
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = ex.MessageCode
                };
                Log.Logger.Error(ex, $"FAIL {nameof(GetCommentsFilterOnStoreFrontAsync)} : {ex.Message}");
                return TypedResults.BadRequest<object>(responseException);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetCommentsFilterOnStoreFrontAsync)} : {ex.Message}");
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = string.Empty,
                };
                return TypedResults.BadRequest<object>(responseException);
            }
        }

        public static async Task<Results<Ok<GenericResponse<object>>, BadRequest<object>>> CreateCommentOnStoreFrontAsync(
           CreateCommentOnStoreFrontCommand request,
           IMediator mediator
           )
        {
            try
            {
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(CreateCommentOnStoreFrontAsync)}");

                return TypedResults.Ok(new GenericResponse<object>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (ForumException ex)
            {
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = ex.MessageCode
                };
                Log.Logger.Error(ex, $"FAIL {nameof(CreateCommentOnStoreFrontAsync)} : {ex.Message}");
                return TypedResults.BadRequest<object>(responseException);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateCommentOnStoreFrontAsync)} : {ex.Message}");
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = string.Empty,
                };
                return TypedResults.BadRequest<object>(responseException);
            }
        }

        public static async Task<Results<Ok<GenericResponse<bool>>, BadRequest<object>>> UpdateCommentOnStoreFrontAsync(
           UpdateCommentOnStoreFrontCommand request,
           IHttpContextAccessor httpContextAccessor,
           IMediator mediator
           )
        {
            try
            {
                bool isSuccess = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(UpdateCommentOnStoreFrontAsync)}");
                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.OK, "Request successfully", isSuccess));
            }
            catch (ForumException ex)
            {
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = ex.MessageCode
                };
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateCommentOnStoreFrontAsync)} : {ex.Message}");
                return TypedResults.BadRequest<object>(responseException);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateCommentOnStoreFrontAsync)} : {ex.Message}");
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = string.Empty,
                };
                return TypedResults.BadRequest<object>(responseException);
            }
        }

        public static async Task<Results<Ok<GenericResponse<bool>>, BadRequest<object>>> DeleteCommentOnStoreFrontAsync(
           [FromBody] DeleteCommentOnStoreFrontCommand request,
           IHttpContextAccessor httpContextAccessor,
           IMediator mediator
           )
        {
            try
            {
                bool isSuccess = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(DeleteCommentOnStoreFrontAsync)}");
                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.OK, "Request successfully", isSuccess));
            }
            catch (ForumException ex)
            {
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = ex.MessageCode
                };
                Log.Logger.Error(ex, $"FAIL {nameof(DeleteCommentOnStoreFrontAsync)} : {ex.Message}");
                return TypedResults.BadRequest<object>(responseException);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(DeleteCommentOnStoreFrontAsync)} : {ex.Message}");
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = string.Empty,
                };
                return TypedResults.BadRequest<object>(responseException);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<object>>> GetSummaryProfileMemberAsync(
           IHttpContextAccessor httpContextAccessor,
           IMediator mediator,
           [FromRoute] long userId
        )
        {
            try
            {
                long.TryParse(httpContextAccessor.HttpContext.Request.Headers["storeid"].FirstOrDefault(), out long storeId);
                var result = await mediator.Send(new GetSummaryProfileMemberQuery() { UserId = userId, StoreId = storeId });
                Log.Logger.Information($"DONE {nameof(GetSummaryProfileMemberAsync)}");
                return TypedResults.Ok(result);
            }
            catch (ForumException ex)
            {
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = ex.MessageCode
                };
                Log.Logger.Error(ex, $"FAIL {nameof(GetSummaryProfileMemberAsync)} : {ex.Message}");
                return TypedResults.BadRequest<object>(responseException);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetSummaryProfileMemberAsync)} : {ex.Message}");
                var responseException = new
                {
                    Code = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    MessageCode = string.Empty,
                };
                return TypedResults.BadRequest<object>(responseException);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CreateCreatePackageOrder(
           CreatePackageOrderCommand request,
           IHttpContextAccessor httpContextAccessor,
           IMediator mediator
           )
        {
            try
            {
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(CreateCreatePackageOrder)}");
                if (result.Code == HttpStatusCode.OK)
                {

                    return TypedResults.Ok(result);
                }
                return TypedResults.Ok(result);
            }
            catch (ForumException ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateCreatePackageOrder)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> ApprovePackageOrder(
           ApprovePackageOrderCommand request,
           IHttpContextAccessor httpContextAccessor,
           IMediator mediator
           )
        {
            try
            {
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(ApprovePackageOrder)}");
                return TypedResults.Ok(result);
            }
            catch (ForumException ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(ApprovePackageOrder)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> ApproveRejectPackageOrderCOD(
           ApproveRejectPackageOrderCODCommand request,
           IHttpContextAccessor httpContextAccessor,
           IMediator mediator
           )
        {
            try
            {
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(ApproveRejectPackageOrderCOD)}");
                return TypedResults.Ok(result);
            }
            catch (ForumException ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(ApproveRejectPackageOrderCOD)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> UpdateQCMarkCommand(
           UpdateQCMarkCommand request,
           IHttpContextAccessor httpContextAccessor,
           IMediator mediator
           )
        {
            try
            {
                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(UpdateQCMarkCommand)}");
                return TypedResults.Ok(result);
            }
            catch (ForumException ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateQCMarkCommand)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetListPackageOrder(
           [FromQuery] DateTime? fromDate,
           [FromQuery] DateTime? toDate,
           IHttpContextAccessor httpContextAccessor,
           IMediator mediator,
           [FromQuery] int pageNumber = 0,
           [FromQuery] int pageSize = int.MaxValue
           )
        {
            try
            {
                var request = new GetPackageOrderByFilterQuery
                {
                    FromDate = fromDate,
                    ToDate = toDate,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };

                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(GetListPackageOrder)}");
                return TypedResults.Ok(result);
            }
            catch (ForumException ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetListPackageOrder)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetListPackagePrice(
           [FromQuery] bool isInternational,
           IHttpContextAccessor httpContextAccessor,
           IMediator mediator
           )
        {
            try
            {
                var request = new GetPackagePriceByFilterQuery
                {
                    IsInternational = isInternational
                };

                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(GetListPackageOrder)}");
                return TypedResults.Ok(result);
            }
            catch (ForumException ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetListPackageOrder)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetStorePackage(
           IHttpContextAccessor httpContextAccessor,
           IMediator mediator
           )
        {
            try
            {
                var request = new GetStorePackageQuery
                {
                };

                var result = await mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(GetListPackageOrder)}");
                return TypedResults.Ok(result);
            }
            catch (ForumException ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetListPackageOrder)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }
    }
}
