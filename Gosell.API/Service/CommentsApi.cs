using GoSell.Comments.Application.Queries.Comments;
using GoSell.Comments.Application.Queries.Permissions;
using GoSell.Comments.Models.Response;
using GoSell.Comments.Services;
using GoSell.Library.Helpers.Api;
using GoSell.Library.Utils;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

namespace GoSell.API.Service
{
    public static class CommentsApi
    {
        public static async Task<Results<Ok<CreateCommentResponseModel>, NotFound>> CreateAsync(CreateCommentsModelQuery request, [AsParameters] CommentServices services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                request.DisplayName = baseApi.User.DisplayName;
                var comments = await services.Mediator.Send(request);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<SearchCommentResponseModel>, NotFound>> SearchAsync(SearchCommentsModelQuery request, [AsParameters] CommentServices services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var comments = await services.Mediator.Send(request);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<EditCommentResponseModel>, NotFound, BadRequest<string>>> EditAsync(EditCommentsModelQuery request, [AsParameters] CommentServices services, IBaseApi baseApi)
        {
            try
            {
                if (!CheckUserPermission(baseApi, request.StoreId))
                {
                    return TypedResults.BadRequest("Permisision denied!");
                }

                request.UserId = baseApi.User.Sub;
                var comments = await services.Mediator.Send(request);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<DeleteCommentResponseModel>, NotFound, BadRequest<string>>> DeleteAsync(long id, [AsParameters] CommentServices services, IBaseApi baseApi)
        {
            try
            {
                if (!CheckUserPermission(baseApi, null))
                {
                    return TypedResults.BadRequest("Permisision denied!");
                }

                DeleteCommentsModelQuery query = new DeleteCommentsModelQuery() { Id = id, UserId = baseApi.User.Sub };
                var comments = await services.Mediator.Send(query);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CreatePermissionResponseModel>, NotFound, BadRequest<string>>> CreatePermissionAsync(CreatePermissionModelQuery request, [AsParameters] CommentServices services, IBaseApi baseApi)
        {
            try
            {
                if (!CheckUserPermission(baseApi, request.StoreId))
                {
                    return TypedResults.BadRequest("Permisision denied!");
                }

                request.UserId = baseApi.User.Sub;
                var comments = await services.Mediator.Send(request);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<EditPermissionResponseModel>, NotFound, BadRequest<string>>> EditPermissionAsync(EditPermissionModelQuery request, [AsParameters] CommentServices services, IBaseApi baseApi)
        {
            try
            {
                if (!CheckUserPermission(baseApi, request.StoreId))
                {
                    return TypedResults.BadRequest("Permisision denied!");
                }

                request.UserId = baseApi.User.Sub;
                var comments = await services.Mediator.Send(request);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<GetPermissionResponseModel>, NotFound>> GetPermissionAsync(GetPermissionModelQuery request, [AsParameters] CommentServices services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var comments = await services.Mediator.Send(request);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CreateReactionResponseModel>, NotFound>> CreateReaction(CreateReactionModelQuery request, [AsParameters] CommentServices services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var comments = await services.Mediator.Send(request);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<DeleteReactionResponseModel>, NotFound>> DeleteReaction(long reactionId, [AsParameters] CommentServices services, IBaseApi baseApi)
        {
            try
            {
                DeleteReactionModelQuery query = new DeleteReactionModelQuery() { ReactionId = reactionId, UserId = baseApi.User.Sub };
                var comments = await services.Mediator.Send(query);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        private static bool CheckUserPermission(IBaseApi baseApi, long? storeId)
        {
            return baseApi.User.Roles.Contains(AuthoritiesConstants.STORE) || baseApi.User.Roles.Contains(AuthoritiesConstants.ADMIN) || (storeId != null && baseApi.User.StoreId == storeId);
        }
    }
}
