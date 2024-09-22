using System.Net;
using GoSell.Affiliate.Commissions.Application.Queries;
using GoSell.Affiliate.Commissions.Application.Queries.ManualCommissionCalculation;
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
    public static class CommissionBonusApi
    {
        #region Commission Setting
        public static async Task<Results<Ok<CommissionResponseSingleBaseModel>, NotFound>> GetBonusCommissionSettingAsync(long bonusSettingId, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                GetBonusSettingVM query = new GetBonusSettingVM();
                query.BonusSettingId = bonusSettingId;
                var comments = await services.Mediator.Send(query);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseSingleBaseModel>, NotFound>> CreateBonusCommissionSettingAsync(CreateBonusSettingVM request, [AsParameters] CommissionService services, IBaseApi baseApi)
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

        public static async Task<Results<Ok<CommissionResponseSingleBaseModel>, NotFound>> CreateAndPublishBonusCommissionSettingAsync(CreateBonusSettingVM request, [AsParameters] CommissionService services, IBaseApi baseApi)
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

        public static async Task<Results<Ok<StopBonusSettingResponseVM>, NotFound>> StopBonusCommissionSettingAsync(StopBonusSettingVM request, [AsParameters] CommissionService services, IBaseApi baseApi)
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

        public static async Task<Results<Ok<CommissionResponseSingleBaseModel>, NotFound>> EditBonusCommissionSettingAsync(EditBonusSettingVM request, [AsParameters] CommissionService services, IBaseApi baseApi)
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

        public static async Task<Results<Ok<CommissionResponseSingleBaseModel>, NotFound>> DeleteBonusCommissionSettingAsync(long bonusSettingId, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                DeleteBonusSettingVM query = new DeleteBonusSettingVM();
                query.BonusSettingId = bonusSettingId;
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

        public static async Task<Results<Ok<SearchBonusSettingResponseVM>, NotFound>> SearchBonusCommissionSettingAsync(SearchBonusSettingVM request, [AsParameters] CommissionService services, IBaseApi baseApi)
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

        public static async Task<Results<Ok<SearchBonusSettingResponseVM>, NotFound, BadRequest<string[]>>> GetBonusCommissionSettingOfPublisherAsync(GetBonusSettingOfPublisherVM request, [AsParameters] CommissionService services, IBaseApi baseApi, IValidator<GetBonusSettingOfPublisherVM> validator)
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

        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound>> GetDefaultBonusCommissionSettingAsync(GetDefaultBonusSettingVM request, [AsParameters] CommissionService services)
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


        //public static async Task<Results<Ok<SearchBonusSettingResponseVM>, NotFound, BadRequest<string[]>>> GetBonusByPublisherAnsync(GetBonusByPublisherVM request, [AsParameters] CommissionService services, IBaseApi baseApi, IValidator<GetBonusByPublisherVM> validator)
        public static async Task<Results<Ok<SearchBonusSettingResponseVM>, NotFound, BadRequest<string[]>>> GetBonusByPublisherAnsync(GetBonusByPublisherVM request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            //var validationResult = await validator.ValidateAsync(request);
            //if (!validationResult.IsValid)
            //{
            //    return TypedResults.BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToArray());
            //}

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


        #region Affiliate Group
        //public static async Task<Results<Ok<SearchAffiliateGroupResponseModel>, NotFound>> ListAffiliateGroupAsync([AsParameters] CommissionService services, IBaseApi baseApi)
        //{
        //    try
        //    {
        //        SearchAffiliateGroupModelQuery query = new SearchAffiliateGroupModelQuery();
        //        var settingMultipleLevels = await services.Mediator.Send(query);
        //        return TypedResults.Ok(settingMultipleLevels);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex.Message);
        //        return TypedResults.NotFound();
        //    }
        //}
        #endregion

        #region Calculate Commission
        //public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound>> CalculateCommissionAsync(CalculateCommissionModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        //{
        //    try
        //    {
        //        //request.UserId = baseApi.User.Sub;
        //        var resultCaculate = await services.Mediator.Send(request);
        //        return TypedResults.Ok(resultCaculate);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex.Message);
        //        return TypedResults.NotFound();
        //    }
        //}
        #endregion

        #region Manual Calculate Commission    
        public static async Task<Results<Ok<GenericResponse<List<CommissionCalculation>>>, BadRequest<string>>> ManualCalculateBonusCommissionAsync(ManualCommissionCalculationQuery request, [AsParameters] CommissionService services)
        {
            try
            {
                var result = await services.Mediator.Send(request);
                return TypedResults.Ok(new GenericResponse<List<CommissionCalculation>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(ManualCalculateBonusCommissionAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<List<CommissionCalculation>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        #endregion  

        #region Manual Calculate Commission By Publisher Id
        //public static async Task<Results<Ok<GenericResponse<List<CommissionCalculation>>>, BadRequest<string>>> ManualCalculateCommissionByPublisherIdAsync(long publisherId, long affiliateStoreId, [AsParameters] CommissionService services)
        //{
        //    try
        //    {
        //        var request = new ManualCommissionCalculationByPublisherIdQuery()
        //        {
        //            AffiliateStoreId = affiliateStoreId,
        //            PublisherId = publisherId,
        //        };
        //        var result = await services.Mediator.Send(request);
        //        return TypedResults.Ok(new GenericResponse<List<CommissionCalculation>>(HttpStatusCode.OK, "Request successfully", result));
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Logger.Error(ex, $"FAIL {nameof(ManualCalculateCommissionAsync)} : {ex.Message}");
        //        return TypedResults.Ok(new GenericResponse<List<CommissionCalculation>>(HttpStatusCode.BadRequest, "Request failed"));
        //    }
        //}
        #endregion
    }

}
