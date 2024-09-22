using System.Net;
using GoSell.Affiliate.Commissions.Application.Queries;
using GoSell.Affiliate.Commissions.Application.Queries.CommissionSetting;
using GoSell.Affiliate.Commissions.Application.Queries.ManualCommissionCalculation;
using GoSell.Affiliate.Commissions.Models.ResponseModel.MultitierCommission;
using GoSell.Commissions.Application.Queries;
using GoSell.Commissions.Models.Entities;
using GoSell.Commissions.Models.ResponseModel;
using GoSell.Commissions.Services;
using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Api;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

namespace GoSell.API.Service
{
    public static class CommissionApi
    {
        #region Commission Frequency Setting
        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound>> SearchCommissionFrequencySettingAsync(SearchCommissionFrequencySettingModelQuery query, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                var comments = await services.Mediator.Send(query);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseSingleBaseModel>, NotFound>> GetCommissionFrequencySettingAsync(long storeId, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                GetCommissionFrequencySettingModelQuery query = new GetCommissionFrequencySettingModelQuery();
                query.StoreId = storeId;
                var comments = await services.Mediator.Send(query);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseSingleBaseModel>, NotFound>> GetFinalCommissionFrequencySettingAsync(long affiliateStoreId, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                GetFinalCommissionFrequencySettingModelQuery query = new GetFinalCommissionFrequencySettingModelQuery();
                query.AffiliateStoreId = affiliateStoreId;
                var result = await services.Mediator.Send(query);
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseSingleBaseModel>, NotFound>> CreateOrEditCommissionFrequencySettingAsync(CreateCommissionFrequencySettingModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
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
        #endregion

        #region Commission Setting
        public static async Task<Results<Ok<CommissionResponseSingleBaseModel>, NotFound>> GetCommissionSettingAsync(long commissionSettingId, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                GetCommissionSettingModelQuery query = new GetCommissionSettingModelQuery();
                query.CommissionSettingId = commissionSettingId;
                var comments = await services.Mediator.Send(query);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound>> GetCommissionProductAsync(GetCommissionProductModelQuery query, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                var comments = await services.Mediator.Send(query);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseSingleBaseModel>, NotFound>> CreateCommissionSettingAsync(CreateCommissionSettingModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                request.IsPublish = false;
                var comments = await services.Mediator.Send(request);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseSingleBaseModel>, NotFound>> CreateAndPublishCommissionSettingAsync(CreateCommissionSettingModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                request.IsPublish = true;
                var comments = await services.Mediator.Send(request);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<StopCommissionSettingResponseModel>, NotFound>> StopCommissionSettingAsync(StopCommissionSettingModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
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

        public static async Task<Results<Ok<CommissionResponseSingleBaseModel>, NotFound>> EditCommissionSettingAsync(EditCommissionSettingModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
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

        public static async Task<Results<Ok<CommissionResponseSingleBaseModel>, NotFound>> DeleteCommissionSettingAsync(long commissionSettingId, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                DeleteCommissionSettingModelQuery query = new DeleteCommissionSettingModelQuery();
                query.CommissionSettingId = commissionSettingId;
                query.UserId = baseApi.User.Sub;
                var comments = await services.Mediator.Send(query);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<SearchCommisionSettingResponseModel>, NotFound>> SearchCommissionSettingAsync(SearchCommissionSettingModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                var comments = await services.Mediator.Send(request);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<SearchCommisionSettingResponseModel>, NotFound, BadRequest<string[]>>> GetCommissionSettingOfPublisherAsync(GetCommissionSettingOfPublisherModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi, IValidator<GetCommissionSettingOfPublisherModelQuery> validator)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return TypedResults.BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToArray());
            }

            try
            {
                var commission = await services.Mediator.Send(request);
                return TypedResults.Ok(commission);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound>> GetDefaultCommissionSettingAsync(GetDefaultCommissionSettingModelQuery request, [AsParameters] CommissionService services)
        {
            try
            {
                var commission = await services.Mediator.Send(request);
                return TypedResults.Ok(commission);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }
        #endregion

        #region Commission Collection
        public static async Task<Results<Ok<CreateCommisionCollectionResponseModel>, NotFound>> CreateCommissionCollectionAsync(CreateCommissionCollectionModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
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

        public static async Task<Results<Ok<EditCommisionCollectionResponseModel>, NotFound>> EditCommissionCollectionAsync(EditCommissionCollectionModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
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

        public static async Task<Results<Ok<DeleteCommisionCollectionResponseModel>, NotFound>> DeleteCommissionCollectionAsync(long CommissionCollectionId, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                DeleteCommissionCollectionModelQuery query = new DeleteCommissionCollectionModelQuery();
                query.CommissionCollectionId = CommissionCollectionId;
                query.UserId = baseApi.User.Sub;
                var comments = await services.Mediator.Send(query);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseSingleBaseModel>, NotFound>> SearchCommissionCollectionAsync(EditCommissionSettingModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
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
        #endregion

        #region Commission Affiliate
        public static async Task<Results<Ok<CreateCommisionAffiliateResponseModel>, NotFound>> CreateCommissionAffiliateAsync(CreateCommissionAffiliateModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var affiliates = await services.Mediator.Send(request);
                return TypedResults.Ok(affiliates);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<EditCommisionAffiliateResponseModel>, NotFound>> EditCommissionAffiliateAsync(EditCommissionAffiliateModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var affiliates = await services.Mediator.Send(request);
                return TypedResults.Ok(affiliates);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<DeleteCommisionAffiliateResponseModel>, NotFound>> DeleteCommissionAffiliateAsync(long Id, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                DeleteCommissionAffiliateModelQuery query = new DeleteCommissionAffiliateModelQuery();
                query.Id = Id;
                query.UserId = baseApi.User.Sub;
                var comments = await services.Mediator.Send(query);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }
        #endregion

        #region Commission Campaign
        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound>> CreateCommissionCampaignAsync(CreateCommissionCampaignModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var commissions = await services.Mediator.Send(request);
                return TypedResults.Ok(commissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound>> EditCommissionCampaignAsync(EditCommissionCampaignModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var commissions = await services.Mediator.Send(request);
                return TypedResults.Ok(commissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound>> DeleteCommissionCampaignAsync(long id, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                DeleteCommissionCampaignModelQuery query = new DeleteCommissionCampaignModelQuery();
                query.Id = id;
                query.UserId = baseApi.User.Sub;
                var commissions = await services.Mediator.Send(query);
                return TypedResults.Ok(commissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }
        #endregion

        #region Commission Product
        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound>> CreateCommissionProductAsync(CreateCommissionProductModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var commissions = await services.Mediator.Send(request);
                return TypedResults.Ok(commissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound>> EditCommissionProductAsync(EditCommissionProductModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var commissions = await services.Mediator.Send(request);
                return TypedResults.Ok(commissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound>> DeleteCommissionProductAsync(long id, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                DeleteCommissionProductModelQuery query = new DeleteCommissionProductModelQuery();
                query.Id = id;
                query.UserId = baseApi.User.Sub;
                var commissions = await services.Mediator.Send(query);
                return TypedResults.Ok(commissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }
        #endregion

        #region Commission Rule
        public static async Task<Results<Ok<CreateCommisionRuleResponseModel>, NotFound>> CreateCommissionRuleAsync(CreateCommissionRuleModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var affiliates = await services.Mediator.Send(request);
                return TypedResults.Ok(affiliates);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<EditCommisionRuleResponseModel>, NotFound>> EditCommissionRuleAsync(EditCommissionRuleModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var affiliates = await services.Mediator.Send(request);
                return TypedResults.Ok(affiliates);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<DeleteCommisionRuleResponseModel>, NotFound>> DeleteCommissionRuleAsync(long Id, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                DeleteCommissionRuleModelQuery query = new DeleteCommissionRuleModelQuery();
                query.Id = Id;
                query.UserId = baseApi.User.Sub;
                var comments = await services.Mediator.Send(query);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }
        #endregion

        #region Commission Setting Extra
        public static async Task<Results<Ok<CreateCommisionSettingExtraResponseModel>, NotFound>> CreateCommissionSettingExtraAsync(CreateCommissionSettingExtraModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var affiliates = await services.Mediator.Send(request);
                return TypedResults.Ok(affiliates);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<EditCommisionSettingExtraResponseModel>, NotFound>> EditCommissionSettingExtraAsync(EditCommissionSettingExtraModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var affiliates = await services.Mediator.Send(request);
                return TypedResults.Ok(affiliates);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<DeleteCommisionSettingExtraResponseModel>, NotFound>> DeleteCommissionSettingExtraAsync(long commissionSettingExtraId, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                DeleteCommissionSettingExtraModelQuery query = new DeleteCommissionSettingExtraModelQuery();
                query.CommissionSettingExtraId = commissionSettingExtraId;
                query.UserId = baseApi.User.Sub;
                var comments = await services.Mediator.Send(query);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }
        #endregion

        #region Commission Group Multiple Level
        public static async Task<Results<Ok<CreateCommissionGroupMultiLevelResponseModel>, NotFound>> CreateCommissionGroupMultiLevelAsync(CreateCommissionGroupMultiLevelModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var settingMultipleLevels = await services.Mediator.Send(request);
                return TypedResults.Ok(settingMultipleLevels);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<EditCommisionSettingExtraResponseModel>, NotFound>> EditCommissionGroupMultiLevelAsync(EditCommissionSettingExtraModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var settingMultipleLevels = await services.Mediator.Send(request);
                return TypedResults.Ok(settingMultipleLevels);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<DeleteCommissionGroupMultiLevelResponseModel>, NotFound>> DeleteCommissionGroupMultiLevelAsync(long Id, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                DeleteCommissionGroupMultiLevelModelQuery query = new DeleteCommissionGroupMultiLevelModelQuery();
                query.Id = Id;
                query.UserId = baseApi.User.Sub;
                var settingMultipleLevels = await services.Mediator.Send(query);
                return TypedResults.Ok(settingMultipleLevels);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }
        #endregion

        #region Commission Priority
        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound, BadRequest<string[]>>> CreateCommissionPriorityAsync(CreateCommissionPriorityModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var commissions = await services.Mediator.Send(request);
                return TypedResults.Ok(commissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound, BadRequest<string[]>>> EditCommissionPriorityAsync(EditCommissionPriorityModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var commissions = await services.Mediator.Send(request);
                return TypedResults.Ok(commissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound>> DeleteCommissionPriorityAsync(long id, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                DeleteCommissionPriorityModelQuery query = new DeleteCommissionPriorityModelQuery();
                query.Id = id;
                query.UserId = baseApi.User.Sub;
                var commissions = await services.Mediator.Send(query);
                return TypedResults.Ok(commissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }
        #endregion

        #region Commission Revenue
        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound, BadRequest<string[]>>> CreateCommissionRevenueAsync(CreateCommissionRevenueModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var commissions = await services.Mediator.Send(request);
                return TypedResults.Ok(commissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound, BadRequest<string[]>>> EditCommissionRevenueAsync(EditCommissionRevenueModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var commissions = await services.Mediator.Send(request);
                return TypedResults.Ok(commissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound>> DeleteCommissionRevenueAsync(long id, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                DeleteCommissionRevenueModelQuery query = new DeleteCommissionRevenueModelQuery();
                query.Id = id;
                query.UserId = baseApi.User.Sub;
                var commissions = await services.Mediator.Send(query);
                return TypedResults.Ok(commissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }
        #endregion

        #region Commission Revenue Quantity
        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound, BadRequest<string[]>>> CreateCommissionRevenueQuantityAsync(CreateCommissionRevenueQuantityModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var commissions = await services.Mediator.Send(request);
                return TypedResults.Ok(commissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound, BadRequest<string[]>>> EditCommissionRevenueQuantityAsync(EditCommissionRevenueQuantityModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var commissions = await services.Mediator.Send(request);
                return TypedResults.Ok(commissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound>> DeleteCommissionRevenueQuantityAsync(long id, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                DeleteCommissionRevenueQuantityModelQuery query = new DeleteCommissionRevenueQuantityModelQuery();
                query.Id = id;
                query.UserId = baseApi.User.Sub;
                var commissions = await services.Mediator.Send(query);
                return TypedResults.Ok(commissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }
        #endregion

        #region Commission Category
        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound, BadRequest<string[]>>> CreateCommissionCategoryAsync(CreateCommissionCategoryModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var commissions = await services.Mediator.Send(request);
                return TypedResults.Ok(commissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound, BadRequest<string[]>>> EditCommissionCategoryAsync(EditCommissionCategoryModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var commissions = await services.Mediator.Send(request);
                return TypedResults.Ok(commissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound>> DeleteCommissionCategoryAsync(long id, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                DeleteCommissionCategoryModelQuery query = new DeleteCommissionCategoryModelQuery();
                query.Id = id;
                query.UserId = baseApi.User.Sub;
                var commissions = await services.Mediator.Send(query);
                return TypedResults.Ok(commissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }
        #endregion

        #region Commission ExpandOption
        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound, BadRequest<string[]>>> CreateCommissionExpandOptionAsync(CreateCommissionExpandOptionModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var commissions = await services.Mediator.Send(request);
                return TypedResults.Ok(commissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound, BadRequest<string[]>>> EditCommissionExpandOptionAsync(EditCommissionExpandOptionModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                var commissions = await services.Mediator.Send(request);
                return TypedResults.Ok(commissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound>> DeleteCommissionExpandOptionAsync(long id, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                DeleteCommissionExpandOptionModelQuery query = new DeleteCommissionExpandOptionModelQuery();
                query.Id = id;
                query.UserId = baseApi.User.Sub;
                var commissions = await services.Mediator.Send(query);
                return TypedResults.Ok(commissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }
        #endregion

        #region Affiliate Group
        public static async Task<Results<Ok<SearchAffiliateGroupResponseModel>, NotFound>> ListAffiliateGroupAsync([AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                SearchAffiliateGroupModelQuery query = new SearchAffiliateGroupModelQuery();
                var settingMultipleLevels = await services.Mediator.Send(query);
                return TypedResults.Ok(settingMultipleLevels);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }
        #endregion

        #region Calculate Commission
        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound>> CalculateCommissionAsync(CalculateCommissionModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                //request.UserId = baseApi.User.Sub;
                var resultCaculate = await services.Mediator.Send(request);
                return TypedResults.Ok(resultCaculate);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<MultitierCommissionResponseBaseModel>, NotFound>> CalculateMultitierCommissionAsync(CalculateMultitierCommissionModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                var resultCaculate = await services.Mediator.Send(request);
                return TypedResults.Ok(resultCaculate);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<string>, NotFound>> CronJobCalculateMultitierCommissionAsync(CronJobCalculateMultitierModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                var resultCaculate = await services.Mediator.Send(request);
                return TypedResults.Ok(resultCaculate);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }


        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CronJobUpdateMultitierSettingExpiredAsync(
            [FromBody] CronJobMultiterSettingExpiredQuery query,
            [AsParameters] CommissionService services)
        {
            try
            {
                var result = await services.Mediator.Send(new CronJobMultiterSettingExpiredQuery()
                {
                    AffiliateStoreId = query.AffiliateStoreId
                });
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.OK, $"Run cron job {query.AffiliateStoreId} succeeded"));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL Run Cron Job : {ex.Message}");
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Run cron job failed"));
            }
        }
        #endregion

        #region Manual Calculate Commission    
        public static async Task<Results<Ok<GenericResponse<List<CommissionCalculation>>>, BadRequest<string>>> ManualCalculateCommissionAsync(ManualCommissionCalculationQuery request, [AsParameters] CommissionService services)
        {
            try
            {
                var result = await services.Mediator.Send(request);
                return TypedResults.Ok(new GenericResponse<List<CommissionCalculation>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(ManualCalculateCommissionAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<CommissionCalculation>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        #endregion  

        #region Manual Calculate Commission By Publisher Id
        public static async Task<Results<Ok<GenericResponse<List<CommissionCalculation>>>, BadRequest<string>>> ManualCalculateCommissionByPublisherIdAsync(long publisherId, long affiliateStoreId, [AsParameters] CommissionService services)
        {
            try
            {
                var request = new ManualCommissionCalculationByPublisherIdQuery()
                {
                    AffiliateStoreId = affiliateStoreId,
                    PublisherId = publisherId,
                };
                var result = await services.Mediator.Send(request);
                return TypedResults.Ok(new GenericResponse<List<CommissionCalculation>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(ManualCalculateCommissionAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<CommissionCalculation>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        #endregion
    }

}
