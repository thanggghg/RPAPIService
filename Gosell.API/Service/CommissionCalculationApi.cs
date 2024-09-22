using System.Net;
using GoSell.Affiliate.Commissions.Application.Queries;
using GoSell.Affiliate.Commissions.Application.Queries.CommissionSetting;
using GoSell.Affiliate.Commissions.Application.Queries.Requests;
using GoSell.Affiliate.Commissions.Models.ResponseModel;
using GoSell.Affiliate.Commissions.Models.ResponseModel.CommissionReport;
using GoSell.Affiliate.Tracking.Services;
using GoSell.Commissions.Application.Queries;
using GoSell.Commissions.Services;
using GoSell.Common.Enums;
using GoSell.Common.Models;
using GoSell.Common.Models.Requests;
using GoSell.Common.Models.Responses;
using GoSell.Common.Queries;
using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Api;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using Serilog;

namespace GoSell.API.Service
{
    public static class CommissionCalculationApi
    {
        public static async Task<Results<Ok<GenericResponse<CommissionCalculationResponseModel>>, BadRequest<BaseResponse>>> GetCommissionCalculationAsync(
            IMediator mediator,
            [FromRoute] long goSellStoreId,
            ILogger<GetCommissionCalculationModelQuery> _logger,
            IBaseApi baseApi,
            [FromBody] GetCommissionCalculationRequest query)
        {
            var result = await mediator.Send(new GetCommissionCalculationModelQuery(goSellStoreId, query));

            _logger.LogInformation($"DONE {nameof(GetCommissionCalculationAsync)}");
            return TypedResults.Ok(new GenericResponse<CommissionCalculationResponseModel>(HttpStatusCode.OK, "Request succeeded", result));
        }

        public static async Task<Results<Ok<GenericResponse<bool>>, BadRequest<BaseResponse>>> UpdateStatusCommissionCalculationAsync(
            IMediator mediator,
            ILogger<UpdateStatusCommissionCalculationModelQuery> _logger,
            IBaseApi baseApi,
            [FromBody] UpdateStatusCommissionCalculationModelRequest query)
        {
            var result = await mediator.Send(new UpdateStatusCommissionCalculationModelQuery(baseApi.User.Sub, baseApi.User.StoreId, query));

            _logger.LogInformation($"DONE {nameof(UpdateStatusCommissionCalculationAsync)}");
            return TypedResults.Ok(new GenericResponse<bool>(HttpStatusCode.OK, "Request succeeded", result));
        }

        public static async Task<FileContentHttpResult> ExportOrderCommissionReportAsync(
            [FromRoute] string type,
            [FromRoute] long goSellStoreId,
            ILogger<GetCommissionCalculationModelQuery> _logger,
            IBaseApi baseApi,
            IMediator mediator,
            [FromBody] ExportCommonRequest exportRequest)
        {
            if (string.IsNullOrEmpty(type) || !Enum.TryParse(type, out ExportCommonServiceType exportServiceType))
            {
                Log.Logger.Warning("Invalid request - type is missing - {@IntegrationEvent}", type);
                throw new ArgumentException("Type is missing or invalid.");
            }

            if (exportRequest == null)
            {
                Log.Logger.Warning("Invalid request - exportRequest is null.");
                throw new ArgumentException("Export request is null.");
            }

            try
            {
                var conditions = JsonConvert.DeserializeObject<GetCommissionCalculationRequest>(exportRequest.Conditions);
                if (conditions != null)
                {
                    var exportData = await mediator.Send(new GetCommissionCalculationModelQuery(goSellStoreId, conditions));

                    if (exportData != null && exportData.Data.Count > 0)
                    {
                        var exportAffOrderCommissionReportQuery = new ExportAffOrderCommissionReportQuery(exportData.Data, conditions.currencyCode);

                        var exportQuery = new ExportCommonQuery<ExportAffOrderCommissionReportQuery>(exportRequest, exportServiceType, goSellStoreId, exportAffOrderCommissionReportQuery);

                        ExportCommonQueryResponse result = await mediator.Send(exportQuery);

                        if (result != null && result.File != null && result.File.Length > 0)
                        {
                            return TypedResults.File(result.File, result.TemplateType, result.TemplateName);
                        }
                    }

                }
                else
                {
                    throw new ArgumentException("Invalid JSON format in export conditions.");
                }
                Log.Logger.Warning("No valid export data found.");
                throw new InvalidOperationException("No valid export data found.");
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Error exporting data.");
                throw;
            }
        }

        #region Report publisher page
        public static async Task<Results<Ok<GetComissionSummaryResponseModel>, NotFound>> GetComissionSummaryAsync(
            [FromQuery] long externalStoreId,
            [AsParameters] CommissionService services,
            IBaseApi baseApi)
        {
            try
            {
                var request = new GetComissionSummaryModelQuery(externalStoreId);

                var result = await services.Mediator.Send(request);
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }


        public static async Task<Results<Ok<GetCommissionOrderForChartResponseModel>, NotFound>> GetCommissionOrderForChartAsync(
            [FromQuery] long affiliateStoreId,
            [FromQuery] long publisherId,
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [AsParameters] CommissionService services,
            IBaseApi baseApi)
        {
            try
            {
                var request = new GetCommissionOrderForChartQuery
                {
                    AffiliateStoreId = affiliateStoreId,
                    PubliserId = publisherId,
                    StartDate = startDate,
                    EndDate = endDate,
                };

                var result = await services.Mediator.Send(request);
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<GenericResponse<PaginatedList<TopSellingProductResponseModel>>>, BadRequest<string>>> GetTopSellingProductByAffStoreIdAsync(
           [FromQuery] long externalStoreId,
           [FromQuery] DateTime? startDate,
           [FromQuery] DateTime? endDate,
           [AsParameters] AffiliateProductServices services,
           IBaseApi baseApi,
           [FromQuery] int pageNumber = 1,
           [FromQuery] int pageSize = 10)
        {
            try
            {
                var request = new GetTopSellingProductByAffStoreIdQuery()
                {
                    ExternalStoreId = externalStoreId,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    StartDate = startDate,
                    EndDate = endDate,
                };
                var result = await services.Mediator.Send(request);
                return TypedResults.Ok(new GenericResponse<PaginatedList<TopSellingProductResponseModel>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetTopSellingProductByAffStoreIdAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<PaginatedList<TopSellingProductResponseModel>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        #endregion

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> RunCronJobCommissionCalculationAsync(
            [FromBody] CronJobCommissionCalculationQuery query,
            [AsParameters] CommissionService services)
        {
            try
            {
                string jobType = query.CronJobType == 1 ? "Temp" : "Final";
                var result = await services.Mediator.Send(new CronJobCommissionCalculationQuery()
                {
                    CronJobType = query.CronJobType,
                    AffiliateStoreId = query.AffiliateStoreId
                });
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.OK, $"Run cron job {jobType} succeeded"));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL Run Cron Job : {ex.Message}");
                return TypedResults.Ok(new BaseResponse(HttpStatusCode.BadRequest, "Run cron job failed"));
            }
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CronJobUpdateCommisstionSettingExpiredAsync(
            [FromBody] CronJobCommissionExpiredQuery query,
            [AsParameters] CommissionService services)
        {
            try
            {
                var result = await services.Mediator.Send(new CronJobCommissionExpiredQuery()
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
    }
}
