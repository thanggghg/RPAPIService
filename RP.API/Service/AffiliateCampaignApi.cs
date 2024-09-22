using System.Net;
using GoSell.Affiliate.Tracking.Commands.AffiliateCampaign;
using GoSell.Affiliate.Tracking.Models.Requests;
using GoSell.Affiliate.Tracking.Queries.AffiliateCampaign;
using GoSell.Affiliate.Tracking.Services;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Api;
using GoSell.Library.Helpers.Pagination;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

namespace GoSell.API.Service
{
    public class AffiliateCampaignApi
    {
        public static async Task<Results<Ok<GenericResponse<PagingItems<AffiliateCampaignViewModel>>>, BadRequest<string>>> GetAllAffiliateCampaignAsync(
           [AsParameters] GetAllAffiliateCampaignRequest request,
           [AsParameters] AffiliateCampaignServices services,
           IBaseApi baseApi)
        {
            try
            {
                var command = new GetAllAffiliateCampaignQuery
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    IsPaging = request.IsPaging,
                    Keyword = request.Keyword,
                    SearchType = request.SearchType,
                    FromDate = request.FromDate,
                    ToDate = request.ToDate,
                    Status = request.Status,
                    AffiliateStoreId = request.AffiliateStoreId,
                    AffiliateStoreFilterStatus = request.AffiliateStoreFilterStatus,
                    StoreId = baseApi.User.StoreId
                };
                var result = await services.Mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(GetAllAffiliateCampaignAsync)}");
                return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateCampaignViewModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateCampaignAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateCampaignViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<AffiliateCampaignDetailViewModel>>, BadRequest<string>>> GetSpecificAffiliateCampaignAsync(
            long id,
            IBaseApi baseApi,
            [AsParameters] AffiliateCampaignServices services)
        {
            try
            {
                var query = new GetSpecificAffiliateCampaignQuery(baseApi.User.StoreId, id);

                var result = await services.Mediator.Send(query);

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetSpecificAffiliateCampaignAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<AffiliateCampaignDetailViewModel>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<PagingItems<AffiliateCampaignViewModel>>>, BadRequest<string>>> GetAllAffiliateCampaignByStoreIdAsync(
            [AsParameters] GetAllAffiliateCampaignByStoreIdQuery request,
            [AsParameters] AffiliateCampaignServices services)
        {
            try
            {
                var query = new GetAllAffiliateCampaignByStoreIdQuery
                {
                    AffiliateStoreId = request.AffiliateStoreId,
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                };

                var result = await services.Mediator.Send(query);

                Log.Logger.Information($"DONE {nameof(GetAllAffiliateCampaignByStoreIdAsync)}");
                return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateCampaignViewModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateCampaignByStoreIdAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<PagingItems<AffiliateCampaignViewModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<BaseResponseCode>, BadRequest<string>>> CreateOrUpdateAffiliateCampaignAsync(
            AffiliateCampaignRequest campaignRequest,
           [AsParameters] AffiliateCampaignServices services,
           IBaseApi baseApi)
        {
            try
            {
                var commandCampaign = new CreateOrUpdateAffiliateCampaignCommand()
                {
                    Id = campaignRequest.Id,
                    AffiliateStoreId = campaignRequest.AffiliateStoreId,
                    StoreId = baseApi.User.StoreId,
                    UserLogin = baseApi.User.Sub,
                    Name = campaignRequest.Name?.Trim(),
                    StartDate = campaignRequest.StartDate,
                    EndDate = campaignRequest.EndDate,
                    Products = campaignRequest.Products,
                    IsPublish = campaignRequest.IsPublish
                };
                if (campaignRequest.currentStatus != null)
                    commandCampaign.currentStatus = campaignRequest.currentStatus;
                var result = await services.Mediator.Send(commandCampaign);

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateOrUpdateAffiliateCampaignAsync)} : {ex.Message}");
                return TypedResults.Ok(new BaseResponseCode(400, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<BaseResponse>>, BadRequest<string>>> DeleteAffiliateCampaignAsync(
            long id,
            IBaseApi baseApi,
           [AsParameters] AffiliateCampaignServices services)
        {
            try
            {
                var commandCampaign = new DeleteAffiliateCampaignCommand(id, baseApi.User.StoreId);

                var result = await services.Mediator.Send(commandCampaign);

                Log.Logger.Information($"DONE {nameof(DeleteAffiliateCampaignAsync)}");
                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(DeleteAffiliateCampaignAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<int>>, BadRequest<string>>> PublishAffiliateCampaignAsync(
            PublishAffiliateCampaignCommand campaignRequest,
           [AsParameters] AffiliateCampaignServices services)
        {
            try
            {
                var commandCampaign = new PublishAffiliateCampaignCommand()
                {
                    Id = campaignRequest.Id,
                    AffiliateStoreId = campaignRequest.AffiliateStoreId,
                    Name = campaignRequest.Name?.Trim(),
                    StartDate = campaignRequest.StartDate,
                    EndDate = campaignRequest.EndDate,
                    Products = campaignRequest.Products,
                };

                var result = await services.Mediator.Send(commandCampaign);

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(PublishAffiliateCampaignAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<int>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<int>>, BadRequest<string>>> TerminateAffiliateCampaignAsync(
            TerminateAffiliateCampaignCommand campaignRequest,
           [AsParameters] AffiliateCampaignServices services)
        {
            try
            {
                var commandCampaign = new TerminateAffiliateCampaignCommand()
                {
                    Id = campaignRequest.Id
                };

                var result = await services.Mediator.Send(commandCampaign);

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(TerminateAffiliateCampaignAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<int>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<int>>, BadRequest<string>>> ValidateAffiliateCampaignAsync(
            ValidateAffiliateCampaignQuery campaignRequest,
           [AsParameters] AffiliateCampaignServices services)
        {
            try
            {
                var commandCampaign = new ValidateAffiliateCampaignQuery()
                {
                    Id = campaignRequest.Id,
                    AffiliateStoreId = campaignRequest.AffiliateStoreId,
                    Name = campaignRequest.Name?.Trim(),
                    StartDate = campaignRequest.StartDate,
                    EndDate = campaignRequest.EndDate,
                    Products = campaignRequest.Products,
                };

                var result = await services.Mediator.Send(commandCampaign);

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(ValidateAffiliateCampaignAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<int>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<List<CampaignToCalculateCommissionModel>>>, BadRequest<string>>> GetCampaignsToCalculateCommissionAsync(
            [AsParameters] GetCampaignsToCalculateCommissionQuery request,
            [AsParameters] AffiliateCampaignServices services)
        {
            try
            {
                var result = await services.Mediator.Send(request);

                return TypedResults.Ok(new GenericResponse<List<CampaignToCalculateCommissionModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetCampaignsToCalculateCommissionAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<CampaignToCalculateCommissionModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<List<CampaignsHappeningForPublisherIncludeProductModel>>>, BadRequest<string>>> GetCampaignsHappeningForPublisherIncludeProductAsync(
            [AsParameters] AffiliateCampaignServices services,
            [FromQuery] string keyword,
            [FromQuery] long? campaignId,
            IBaseApi baseApi)
        {
            try
            {
                var query = new GetCampaignsHappeningForPublisherIncludeProductQuery
                {
                    AffiliateStoreId = baseApi.User.AffiliateStoreId,
                    CampaignId = campaignId,
                    Keyword = keyword,
                };

                var result = await services.Mediator.Send(query);

                return TypedResults.Ok(new GenericResponse<List<CampaignsHappeningForPublisherIncludeProductModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetCampaignsHappeningForPublisherIncludeProductAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<CampaignsHappeningForPublisherIncludeProductModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<List<CampaignsHappeningForPublisherModel>>>, BadRequest<string>>> GetCampaignsHappeningForPublisherAsync(
            [AsParameters] AffiliateCampaignServices services,
            IBaseApi baseApi)
        {
            try
            {
                var query = new GetCampaignsHappeningForPublisherQuery
                {
                    AffiliateStoreId = baseApi.User.AffiliateStoreId
                };

                var result = await services.Mediator.Send(query);

                return TypedResults.Ok(new GenericResponse<List<CampaignsHappeningForPublisherModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetCampaignsHappeningForPublisherAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<CampaignsHappeningForPublisherModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<int>>, BadRequest<string>>> CronJobUpdateAllExpriredCampaignAsync(
            UpdateAllExpriredCampaignCommand request,
           [AsParameters] AffiliateCampaignServices services)
        {
            try
            {
                var result = await services.Mediator.Send(request);
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CronJobUpdateAllExpriredCampaignAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<int>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
    }
}
