using System.Net;
using GoSell.Affiliate.PublisherManagement.Commands;
using GoSell.Affiliate.PublisherManagement.Models.Requests;
using GoSell.Affiliate.PublisherManagement.Models.Responses;
using GoSell.Affiliate.PublisherManagement.Queries;
using GoSell.Affiliate.PublisherManagement.Services;
using GoSell.Common.Models;
using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Api;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

namespace GoSell.API.Service
{
    public class AffiliatePublisherManagementApi
    {
        /// <summary>
        /// Get list publisher by store
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="request"></param>
        /// <param name="baseApi"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static async Task<Results<Ok<GenericResponse<GetPublishersByStoreResponse>>, BadRequest<string>>> GetPublisherByStoreAsync
        (
            [FromRoute] long storeId,
            [FromBody] GetPublishersByStoreRequest request,
            IBaseApi baseApi,
            [AsParameters] PublisherManagementService service
        )
        {
            if (baseApi.User.StoreId != storeId)
            {
                service.Logger.LogWarning("Unauthorization - {@IntegrationEvent}", storeId);
                throw new ArgumentException("Unauthorization StoreId Invalid");
            }
            try
            {
                GetPublishersByStoreResponse data = await service.Mediator.Send(new GetPublishersByStoreQuery(storeId, request));

                GenericResponse<GetPublishersByStoreResponse> results = new(HttpStatusCode.OK, "Request processed successfully.", data);

                return TypedResults.Ok(results);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Error {nameof(GetPublisherByStoreAsync)}: {ex.Message}");
                return TypedResults.Ok(new GenericResponse<GetPublishersByStoreResponse>(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        /// <summary>
        /// Get publisher by id (View detail)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storeId"></param>
        /// <param name="baseApi"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static async Task<Results<Ok<GenericResponse<PublisherDetailResponse>>, BadRequest<string>>> GetPublisherInfoByIdAsync
        (
            [FromRoute] long id,
            [FromRoute] long storeId,
            IBaseApi baseApi,
            [AsParameters] PublisherManagementService service
        )
        {
            if (baseApi.User.StoreId != storeId)
            {
                service.Logger.LogWarning("Unauthorization - {@IntegrationEvent}", storeId);
                throw new ArgumentException("Unauthorization StoreId Invalid");
            }
            try
            {
                PublisherDetailResponse data = await service.Mediator.Send(new GetPublisherInfoByIdQuery(id, storeId));

                GenericResponse<PublisherDetailResponse> results = new(HttpStatusCode.OK, "RRequest processed successfully.", data);

                return TypedResults.Ok(results);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Error {nameof(GetPublisherInfoByIdAsync)}: {ex.Message}");
                return TypedResults.Ok(new GenericResponse<PublisherDetailResponse>(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        /// <summary>
        /// Get publisher user manager
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="storeId"></param>
        /// <param name="baseApi"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static async Task<Results<Ok<GenericResponse<List<PublisherManagerResponse>>>, BadRequest<string>>> GetPublisherUserManagerAsync
        (
            [FromRoute] long goSellStoreId,
            [FromBody] PublisherUserManagerRequest request,
            IBaseApi baseApi,
            [AsParameters] PublisherManagementService service
        )
        {
            if (baseApi.User.StoreId != goSellStoreId)
            {
                service.Logger.LogWarning("Unauthorization - {@IntegrationEvent}", goSellStoreId);
                throw new ArgumentException("Unauthorization StoreId Invalid");
            }
            try
            {
                List<PublisherManagerResponse> data = await service.Mediator.Send(new GetPublisherUserManagerQuery
                {
                    Page = request.Page,
                    Size = request.Size,
                    AffiliateStoreId = request.AffiliateStoreId,
                    UserId = request.UserId,
                    GoSellStoreId = goSellStoreId,
                });

                GenericResponse<List<PublisherManagerResponse>> results = new(HttpStatusCode.OK, "RRequest processed successfully.", data);

                return TypedResults.Ok(results);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Error {nameof(GetPublisherInfoByIdAsync)}: {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<PublisherManagerResponse>>(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        /// <summary>
        /// Update publisher info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storeId"></param>
        /// <param name="request"></param>
        /// <param name="baseApi"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static async Task<Results<Ok<GenericResponse<bool>>, BadRequest<string>>> UpdatePublisherStoreAsync
        (
            [FromRoute] long id,
            [FromRoute] long storeId,
            UpdatePublisherStoreRequest request,
            IBaseApi baseApi,
            [AsParameters] PublisherManagementService service
        )
        {
            if (baseApi.User.StoreId != storeId)
            {
                service.Logger.LogWarning("Unauthorization - {@IntegrationEvent}", storeId);
                throw new ArgumentException("Unauthorization StoreId Invalid");
            }
            try
            {
                bool data = await service.Mediator.Send(new UpdatePublisherStoreCommand(id, storeId, request));

                GenericResponse<bool> results = new(HttpStatusCode.OK, "Request processed successfully.", data);

                return TypedResults.Ok(results);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Error {nameof(UpdatePublisherStoreAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update publisher status 
        /// Status: (approval-reject, active-inactive, block-unblock)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storeId"></param>
        /// <param name="request"></param>
        /// <param name="baseApi"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static async Task<Results<Ok<GenericResponse<bool>>, BadRequest<string>>> UpdatePublisherStoreStatusAsync
        (
            [FromRoute] long id,
            [FromRoute] long storeId,
            UpdatePublisherStoreStatusRequest request,
            IBaseApi baseApi,
            [AsParameters] PublisherManagementService service,
            HttpContext httpContext
        )
        {
            if (baseApi.User.StoreId != storeId)
            {
                service.Logger.LogWarning("Unauthorization - {@IntegrationEvent}", storeId);
                throw new ArgumentException("Unauthorization StoreId Invalid");
            }
            try
            {
                string javaAccessToken = string.Empty;
                var headers = httpContext.Request.Headers;
                if (headers.ContainsKey("Authorization"))
                {
                    var authorizationHeader = headers["Authorization"].FirstOrDefault();
                    if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                    {
                        javaAccessToken = authorizationHeader.Substring("Bearer ".Length).Trim();
                    }
                }

                GenericResponse<bool> results = await service.Mediator
                   .Send(new UpdatePublisherStoreStatusCommand
                   {
                       Id = id,
                       StoreId = storeId,
                       Status = request.Status,
                       Reason = request.Reason,
                       JavaAccessToken = javaAccessToken,
                       LangKey = request.LangKey,
                       ReasonDetail = request.ReasonDetail
                   });

                return TypedResults.Ok(results);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Error {nameof(UpdatePublisherStoreStatusAsync)}: {ex.Message}");
                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.BadRequest, ex.Message));
            }
        }
        public static async Task<Results<Ok<GenericResponse<bool>>, BadRequest<string>>> UpdateAutoApprovedStoreAsync
        (
            [FromRoute] long storeId,
            IBaseApi baseApi,
            [AsParameters] PublisherManagementService service
        )
        {
            try
            {
                bool data = await service.Mediator.Send(new UpdatePublisherStoreAutoApprovedCommand(storeId, baseApi.User.DisplayName));

                GenericResponse<bool> results = new(HttpStatusCode.OK, "Request successfully", data);

                return TypedResults.Ok(results);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Error {nameof(UpdateAutoApprovedStoreAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<GetPublisherStatusByStoreResponse>>, BadRequest<string>>> GetPublisherStatusByStoreAsync
        (
            [FromRoute] long storeId,
            IBaseApi baseApi,
            [AsParameters] PublisherManagementService service
        )
        {
            if (baseApi.User.StoreId != storeId)
            {
                service.Logger.LogWarning("Unauthorization - {@IntegrationEvent}", storeId);
                throw new ArgumentException("Unauthorization StoreId Invalid");
            }
            try
            {

                GetPublisherStatusByStoreResponse data = await service.Mediator.Send(new GetPublisherStatusByStoreQuery(storeId));

                GenericResponse<GetPublisherStatusByStoreResponse> results = new(HttpStatusCode.OK, "Request processed successfully.", data);

                return TypedResults.Ok(results);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Error {nameof(GetPublisherStatusByStoreAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<GetPublisherStatusByStoreResponse>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<bool>>, BadRequest<string>>> UpdateAllowPublisherRegisterAsync
        (
            [FromRoute] long storeId,
            IBaseApi baseApi,
            [AsParameters] PublisherManagementService service
        )
        {
            try
            {
                bool data = await service.Mediator.Send(new UpdateAllowPublisherRegisterCommand(storeId, baseApi.User.DisplayName));

                GenericResponse<bool> results = new(HttpStatusCode.OK, "Request successfully", data);

                return TypedResults.Ok(results);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Error {nameof(UpdateAllowPublisherRegisterAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<List<PublisherBaseResponse>>>, BadRequest<string>>> GetPublisherByFilterAsync
        (
            [FromBody] GetPublisherByFilterRequest request,
            [AsParameters] PublisherManagementService service
        )
        {
            try
            {
                List<PublisherBaseResponse> data = await service.Mediator.Send(new GetPublisherByFilterQuery(request));

                GenericResponse<List<PublisherBaseResponse>> results = new(HttpStatusCode.OK, "Request processed successfully.", data);

                return TypedResults.Ok(results);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Error {nameof(GetPublisherByStoreAsync)}: {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<PublisherBaseResponse>>(HttpStatusCode.BadRequest, ex.Message));
            }
        }
        public static async Task<Results<Ok<GenericResponse<PackageLimitResponse>>, BadRequest<string>>> CheckPackageLimitAsync
        (
            [FromRoute] long storeId,
            IBaseApi baseApi,
            [AsParameters] PublisherManagementService service,
            HttpContext httpContext
        )
        {
            try
            {
                var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var data = await service.Mediator.Send(new PackageLimitQuery(storeId, token));

                GenericResponse<PackageLimitResponse> results = new(HttpStatusCode.OK, "Request successfully", data);

                return TypedResults.Ok(results);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Error {nameof(CheckPackageLimitAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get list publisher and manager id (org chart)
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static async Task<Results<Ok<GenericResponse<List<GetAllPublisherManagerResponse>>>, BadRequest<string>>> GetAllPublisherUserManagerByStoreAsync
        (
            [FromRoute] long storeId,
            IBaseApi baseApi,
            [AsParameters] PublisherManagementService service
        )
        {
            try
            {
                {
                    List<GetAllPublisherManagerResponse> data = await service.Mediator.Send(new GetAllPublisherUserManagerByStoreQuery(storeId));

                    GenericResponse<List<GetAllPublisherManagerResponse>> results = new(HttpStatusCode.OK, "Request processed successfully.", data);

                    return TypedResults.Ok(results);
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Error {nameof(GetAllPublisherUserManagerByStoreAsync)}: {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<GetAllPublisherManagerResponse>>(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        /// <summary>
        /// Get list publisher and manager id (org chart)
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static async Task<Results<Ok<GenericResponse<List<GetAllPublisherManagerResponse>>>, BadRequest<string>>> GetAllPublisherUserManagerByAFFStoreAsync
        (
            [FromRoute] long storeId,
            IBaseApi baseApi,
            [AsParameters] PublisherManagementService service
        )
        {
            try
            {
                {
                    List<GetAllPublisherManagerResponse> data = await service.Mediator.Send(new GetAllPublisherUserManagerByStoreQuery(storeId));

                    GenericResponse<List<GetAllPublisherManagerResponse>> results = new(HttpStatusCode.OK, "Request processed successfully.", data);

                    return TypedResults.Ok(results);
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Error {nameof(GetAllPublisherUserManagerByStoreAsync)}: {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<GetAllPublisherManagerResponse>>(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        public static async Task<Results<Ok<GenericResponse<bool>>, BadRequest<string>>> UpdateAffiliateUserManagerAsync(UpdateAffiliateUserManagerCommand request, IBaseApi baseApi,
            [AsParameters] PublisherManagementService service)
        {
            try
            {
                var data = await service.Mediator.Send(request);

                GenericResponse<bool> results = new(HttpStatusCode.OK, "Request successfully", data);
                return TypedResults.Ok(results);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Error {nameof(UpdateAffiliateUserManagerAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }
        public static async Task<Results<Ok<GenericResponse<List<PublisherBaseResponse>>>, BadRequest<string>>> GetListFilterByNameAndPhone
       (
           GetPublisherByFilterNameAndPhoneQuery request,
           IBaseApi baseApi,
           [AsParameters] PublisherManagementService service
       )
        {
            try
            {
                request.GosellStoreId = baseApi.User.StoreId;
                List<PublisherBaseResponse> data = await service.Mediator.Send(request);

                GenericResponse<List<PublisherBaseResponse>> results = new(HttpStatusCode.OK, "Request successfully", data);

                return TypedResults.Ok(results);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Error {nameof(CheckPackageLimitAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        #region partner title
        public static async Task<Results<Ok<GenericResponse<GetPartnerTitleResponse>>, BadRequest<string>>> GetAffiliatePartnerTitleAsync(
           [AsParameters] GetPartnerTitleQuery request,
           [AsParameters] PublisherManagementService services)
        {
            try
            {
                Log.Logger.Information($"STARTING {nameof(GetAffiliatePartnerTitleAsync)}");

                var result = await services.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(GetAffiliatePartnerTitleAsync)}");

                return TypedResults.Ok(new GenericResponse<GetPartnerTitleResponse>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Error {nameof(GetAffiliatePartnerTitleAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }
        public static async Task<Results<Ok<GenericResponse<bool>>, BadRequest<string>>> DeleteAffiliatePartnerTitleAsync(
           [FromBody] DeletePartnerTitleQuery request,
           [AsParameters] PublisherManagementService services,
           IBaseApi baseApi)
        {
            try
            {
                Log.Logger.Information($"STARTING {nameof(DeleteAffiliatePartnerTitleAsync)}");
                request.UserName = baseApi.User.DisplayName;

                var result = await services.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(DeleteAffiliatePartnerTitleAsync)}");

                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Error {nameof(DeleteAffiliatePartnerTitleAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<GenericResponse<bool>>, BadRequest<string>>> InsertUpdateAffiliatePartnerTitleAsync(
           [FromBody] InsertUpdatePartnerTitleQuery request,
           [AsParameters] PublisherManagementService services,
           IBaseApi baseApi)
        {
            try
            {
                Log.Logger.Information($"STARTING {nameof(InsertUpdateAffiliatePartnerTitleAsync)}");
                request.UserName = baseApi.User.DisplayName;

                var result = await services.Mediator.Send(request);
                Log.Logger.Information($"DONE {nameof(InsertUpdateAffiliatePartnerTitleAsync)}");

                return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Error {nameof(InsertUpdateAffiliatePartnerTitleAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }

        public static async Task<Results<Ok<GenericResponse<List<GetPartnerTitleForDropdownResponse>>>, BadRequest<string>>> GetAffiliatePartnerTitleForDropdownAsync(
           [FromRoute] long affiliateStoreId,
           [AsParameters] PublisherManagementService services)
        {
            try
            {
                Log.Logger.Information($"STARTING {nameof(GetAffiliatePartnerTitleForDropdownAsync)}");

                var result = await services.Mediator.Send(new GetPartnerTitleForDropdownQuery { AffiliateStoreId = affiliateStoreId });
                Log.Logger.Information($"DONE {nameof(GetAffiliatePartnerTitleForDropdownAsync)}");

                return TypedResults.Ok(new GenericResponse<List<GetPartnerTitleForDropdownResponse>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Error {nameof(GetAffiliatePartnerTitleForDropdownAsync)} : {ex.Message}");
                return TypedResults.BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
