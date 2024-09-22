using GoSell.Affiliate.Commissions.Application.Queries;
using GoSell.API.Utils;
using GoSell.Common.Models;
using GoSell.Exports.Commons.Enums;
using GoSell.Exports.Models.Requests;
using GoSell.Exports.Queries;
using GoSell.Library.Helpers.Api;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

namespace GoSell.API.Service
{
    public class ExportApi
    {
        public static async Task<FileContentHttpResult> ExportAsync
        (
            [FromRoute] string type,
            [FromRoute] long storeId,
            [FromBody] ExportRequest exportRequest,
            [FromHeader] string Langkey,
            IMediator mediator,
            ILogger<ExportQueryResult> logger,
            IBaseApi baseApi
        )
        {
            Log.Logger.Information("Sending queries: {CommandName} - {IdProperty}: {CommandId} ({@Command})", "", nameof(type), type, exportRequest);

            if (baseApi.User.StoreId != storeId)
            {
                Log.Logger.Warning("Unauthorization - {@IntegrationEvent}", storeId);
                throw new ArgumentException("Unauthorization StoreId invalid");
            }

            if (string.IsNullOrEmpty(type) || !Enum.TryParse(type, out ExportServiceType exportServiceType))
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
                ExportQuery exportQuery = new ExportQuery(exportRequest, exportServiceType, Langkey, storeId);
                ExportQueryResult result = await mediator.Send(exportQuery);

                if (result != null && result.File != null && result.File.Length > 0)
                {
                    return TypedResults.File(result.File, result.TemplateType, result.TemplateName);
                }

                Log.Logger.Warning("No valid export data found.");
                throw new InvalidOperationException("No valid export data found.");
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ExportAsync failed: {Message}", ex.Message);
                throw;
            }
        }

        public static async Task<FileContentHttpResult> ExportProductCommissionReportAsync(
            [FromRoute] string langKey,
            IMediator mediator,
            [FromBody] GetProductCommissionReportQuery query)
        {
            try
            {
                var exportData = await mediator.Send(query);

                if (exportData != null && exportData.Data.Count > 0)
                {
                    var soldTime = string.Format("{0} - {1}", string.Format("{0: dd/MM/yy}", query.FromDate), string.Format("{0: dd/MM/yy}", query.ToDate));
                    var exportQuery = new ExportProductCommissionReportQuery(exportData.Data, langKey ?? UtilsConstants.DefaultLang, soldTime);
                    var result = await mediator.Send(exportQuery);
                    return TypedResults.File(result.File.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", result.FileName);
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

        public static async Task<FileContentHttpResult> ExportCampaignCommissionReportAsync(
            [FromRoute] string langKey,
            IMediator mediator,
            [FromBody] GetCampaignCommissionReportQuery query)
        {
            try
            {
                var exportData = await mediator.Send(query);

                if (exportData != null && exportData.Data.Count > 0)
                {
                    var campaignTime = string.Format("{0} - {1}", string.Format("{0: dd/MM/yy}", query.FromDate), string.Format("{0: dd/MM/yy}", query.ToDate));
                    var exportQuery = new ExportCampaignCommissionReportQuery(exportData.Data, langKey ?? UtilsConstants.DefaultLang, campaignTime);
                    var result = await mediator.Send(exportQuery);
                    return TypedResults.File(result.File.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", result.FileName);
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

        public static async Task<FileContentHttpResult> ExportProductPublisherCommissionReportAsync(
            [FromRoute] string langKey,
            IBaseApi baseApi,
            IMediator mediator,
            [FromBody] GetProductPublisherCommissionReportQuery query)
        {
            try
            {
                var userToken = baseApi.User;
                var exportData = await mediator.Send(new GetProductPublisherCommissionReportQuery
                {
                    UserId = userToken.userAffiliateStoreId,
                    FromDate = query.FromDate,
                    ToDate = query.ToDate,
                    Page = 0,
                    SearchKeyword = query.SearchKeyword,
                    SearchType = query.SearchType,
                    Size = int.MaxValue,
                    AffiliateStoreId = userToken.AffiliateStoreId,
                });

                if (exportData != null && exportData.Data.Count > 0)
                {
                    var soldTime = string.Format("{0} - {1}", string.Format("{0: dd/MM/yy}", query.FromDate), string.Format("{0: dd/MM/yy}", query.ToDate));
                    var exportQuery = new ExportProductPublisherCommissionReportQuery(exportData.Data, langKey ?? UtilsConstants.DefaultLang, query.FromDate != null && query.ToDate != null ? soldTime : null);
                    var result = await mediator.Send(exportQuery);
                    return TypedResults.File(result.File.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", result.FileName);
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
    }
}
