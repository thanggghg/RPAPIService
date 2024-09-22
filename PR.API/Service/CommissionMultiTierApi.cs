using GoSell.Commissions.Application.Queries;
using GoSell.Commissions.Models.ResponseModel;
using GoSell.Commissions.Services;
using GoSell.Library.Helpers.Api;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;
using static GoSell.Commissions.Utils.UtilsConstants;

namespace GoSell.API.Service
{
    public static class CommissionMultiTierApi
    {
        #region MultiTier Setting
        public static async Task<Results<Ok<CommissionResponseSingleBaseModel>, NotFound>> GetMultiTierCommissionSettingAsync(long multiTierSettingId, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                var comments = await services.Mediator.Send(new GetMultiTierSettingModelQuery() { MultiTierSettingId = multiTierSettingId });
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseSingleBaseModel>, NotFound>> CreateMultiTierCommissionSettingAsync(MultiTierSettingModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                request.Status = MultiTierSettingStatus.DRAFT.ToString();
                var comments = await services.Mediator.Send(request);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseSingleBaseModel>, NotFound>> CreateAndPublishMultiTierCommissionSettingAsync(MultiTierSettingModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                request.UserId = baseApi.User.Sub;
                request.Status = MultiTierSettingStatus.ACTIVE.ToString();
                var comments = await services.Mediator.Send(request);
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound>> StopMultiTierCommissionSettingAsync(StopMultiTierSettingModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
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

        public static async Task<Results<Ok<CommissionResponseSingleBaseModel>, NotFound>> EditMultiTierCommissionSettingAsync(MultiTierSettingModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
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

        public static async Task<Results<Ok<CommissionResponseSingleBaseModel>, NotFound>> DeleteMultiTierCommissionSettingAsync(long multiTierSettingId, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                DeleteMultiTierSettingModelQuery query = new DeleteMultiTierSettingModelQuery();
                query.MultiTierSettingId = multiTierSettingId;
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

        public static async Task<Results<Ok<CommissionResponseBaseModel>, NotFound>> SearchMultiTierCommissionSettingAsync(SearchMultiTierSettingModelQuery request, [AsParameters] CommissionService services, IBaseApi baseApi)
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

        public static async Task<Results<Ok<CommissionResponseSingleBaseModel>, NotFound>> GetMultiTracesAsync(long id, string paramName, [AsParameters] CommissionService services, IBaseApi baseApi)
        {
            try
            {
                var comments = await services.Mediator.Send(new GetMultiTracesModelQuery() { Id = id, ParamName = paramName });
                return TypedResults.Ok(comments);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }
        #endregion
    }

}
