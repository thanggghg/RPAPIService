using System.Net;
using GoSell.Affiliate.Commissions.Application.Commands;
using GoSell.Affiliate.Commissions.Application.Queries.CommissionPayments;
using GoSell.Affiliate.Commissions.Application.Queries.CommissionReport;
using GoSell.Affiliate.Commissions.Models.ResponseModel.CommissionPayment;
using GoSell.Affiliate.Commissions.Models.ResponseModel.CommissionReport;
using GoSell.Affiliate.Commissions.Services.CommissionPayments;
using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Api;
using GoSell.Library.Helpers.Pagination;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

namespace GoSell.API.Service
{
    public static class CommissionPaymentsApi
    {
        public static async Task<Results<Ok<GenericResponse<PagingItems<CommissionPaymentResponse>>>, BadRequest<string>>> GetCommissionPaymentAsync(
           [AsParameters] GetCommissionPaymentQuery request,
           [AsParameters] CommissionPaymentsService services)
        {
            try
            {
                var result = await services.Mediator.Send(request);

                return TypedResults.Ok(new GenericResponse<PagingItems<CommissionPaymentResponse>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetCommissionPaymentAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<PagingItems<CommissionPaymentResponse>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<PublisherPaymentTotalResponse>>, BadRequest<string>>> GetCommissionPaymentTotalAsync(
           [AsParameters] GetCommissionPaymentTotalQuery request,
           [AsParameters] CommissionPaymentsService services)
        {
            try
            {
                var result = await services.Mediator.Send(request);

                return TypedResults.Ok(new GenericResponse<PublisherPaymentTotalResponse>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetCommissionPaymentTotalAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<PublisherPaymentTotalResponse>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<PagingItems<CommissionPaymentHistoryResponse>>>, BadRequest<string>>> GetCommissionPaymentHistoriesAsync(
           [AsParameters] GetCommissionPaymentHistoriesRequet request,
           [AsParameters] CommissionPaymentsService services,
            IBaseApi baseApi)
        {
            try
            {
                var query = new GetCommissionPaymentHistoriesQuery
                {
                    AffiliateStoreId = request.AffiliateStoreId,
                    FromDate = request.FromDate,
                    ToDate = request.ToDate,
                    IsPaging = request.IsPaging,
                    Keyword = request.Keyword,
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    SearchType = request.SearchType,
                    CurrencyCode = request.CurrencyCode,
                    StoreStatus = request.StoreStatus,
                    StoreId = baseApi.User.StoreId
                };
                var result = await services.Mediator.Send(query);

                return TypedResults.Ok(new GenericResponse<PagingItems<CommissionPaymentHistoryResponse>>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetCommissionPaymentHistoriesAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<PagingItems<CommissionPaymentHistoryResponse>>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }

        public static async Task<Results<Ok<GenericResponse<CommissionPaymentHistoriesTotalResponse>>, BadRequest<string>>> GetCommissionPaymentHistoriesTotalAsync(
           [AsParameters] GetCommissionPaymentHistoriesTotalQuery request,
           [AsParameters] CommissionPaymentsService services)
        {
            try
            {
                var result = await services.Mediator.Send(request);

                return TypedResults.Ok(new GenericResponse<CommissionPaymentHistoriesTotalResponse>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetCommissionPaymentHistoriesTotalAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<CommissionPaymentHistoriesTotalResponse>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        public static async Task<Results<Ok<GenericResponse<ImportCommissionPaymentPaidAmountResponse>>, BadRequest<string>>> ImportPaymentPaidAmountAsync(
            [FromForm] IFormFile file,
            string langKey,
            int timeZoneInMinutes,
            long affiliateStoreId,
            IBaseApi baseApi,
            [AsParameters] CommissionPaymentsService services)
        {
            try
            {
                var command = new ImportCommissionPaymentPaidAmountQuery(file, langKey, timeZoneInMinutes, affiliateStoreId, baseApi.User.StoreId);

                var result = await services.Mediator.Send(command);

                Log.Logger.Information($"DONE {nameof(ImportPaymentPaidAmountAsync)}");
                return TypedResults.Ok(new GenericResponse<ImportCommissionPaymentPaidAmountResponse>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(ImportPaymentPaidAmountAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<ImportCommissionPaymentPaidAmountResponse>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        #region Payment History
        public static async Task<Results<Ok<GenericResponse<byte[]>>, BadRequest<string>>> ExportPaymentHistoryAsync(
            [AsParameters] ExportPaymentHistoryRequest request,
            [AsParameters] CommissionPaymentsService services,
            IBaseApi baseApi)
        {
            try
            {
                var query = new ExportPaymentHistoryQuery
                {
                    AffiliateStoreId = request.AffiliateStoreId,
                    Keyword = request.Keyword,
                    LangKey = request.LangKey,
                    SearchType = request.SearchType,
                    TimeZoneInMinutes = request.TimeZoneInMinutes,
                    ToDate = request.ToDate,
                    FromDate = request.FromDate,
                    StoreId = baseApi.User.StoreId,
                    CurrencyCode = request.CurrencyCode,
                    StoreStatus = request.StoreStatus
                };

                var result = await services.Mediator.Send(query);

                Log.Logger.Information($"DONE {nameof(ExportPaymentHistoryAsync)}");
                return TypedResults.Ok(new GenericResponse<byte[]>(HttpStatusCode.OK, "Export payment history successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(ExportPaymentHistoryAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<byte[]>(HttpStatusCode.BadRequest, $"Export payment history failed {ex.Message}", null));
            }
        }
        public static async Task<Results<Ok<GenericResponse<byte[]>>, BadRequest<string>>> ExportPaymentImportTemplate(
        [AsParameters] ExportPaymentImportTemplateQuery query,
        [AsParameters] CommissionPaymentsService services)
        {
            try
            {
                var result = await services.Mediator.Send(query);

                Log.Logger.Information($"DONE {nameof(ExportPaymentImportTemplate)}");
                return TypedResults.Ok(new GenericResponse<byte[]>(HttpStatusCode.OK, "Export payment import template successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(ExportPaymentImportTemplate)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<byte[]>(HttpStatusCode.BadRequest, "Export payment import template failed", null));
            }
        }
        public static async Task<Results<Ok<GenericResponse<byte[]>>, BadRequest<string>>> ExportPaymentInformationAsync(
           [AsParameters] ExportPaymentInformationQuery query,
           [AsParameters] CommissionPaymentsService services)
        {
            try
            {
                var temp = TimeZoneInfo.Local;
                var result = await services.Mediator.Send(query);

                Log.Logger.Information($"DONE {nameof(ExportPaymentInformationAsync)}");
                return TypedResults.Ok(new GenericResponse<byte[]>(HttpStatusCode.OK, "Export payment information successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(ExportPaymentInformationAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<byte[]>(HttpStatusCode.BadRequest, "Export payment information failed", null));
            }
        }

        public static async Task<Results<Ok<GenericResponse<BaseResponse>>, BadRequest<string>>> CreateAffiliatePaymentHistoryAsync(
          CreatePaymentHistoryCommand request,
          [AsParameters] CommissionPaymentsService services)
        {
            try
            {
                var result = await services.Mediator.Send(request);

                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.OK, "Request successfully", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateAffiliatePaymentHistoryAsync)} : {ex.Message}");
                return TypedResults.Ok(new GenericResponse<BaseResponse>(HttpStatusCode.BadRequest, "Request failed"));
            }
        }
        #endregion

        public static async Task<Results<Ok<GenericResponse<PaymentReportByPublisherModel>>, BadRequest<object>>> GetPaymentReportByPublisherIdAsync(
             [FromRoute] long publisherId,
             [FromQuery] int? pageSize,
             [FromQuery] int? pageNumber,
             [FromQuery] DateTime? fromDate,
             [FromQuery] DateTime? toDate,
             IMediator mediator,
             IBaseApi baseApi)
        {
            Log.Logger.Information($"Sending GetPaymentReportByPublisherIdAsync: {publisherId}");

            try
            {
                if (baseApi.User?.Sub != publisherId.ToString())
                {
                    throw new Exception("User does not have permission!");
                }

                var result = await mediator.Send(new GetPaymentReportByPublisherIdQuery
                {
                    FromDate = fromDate,
                    ToDate = toDate,
                    PageNumber = pageNumber ?? 0,
                    PageSize = pageSize ?? 10,
                    PublisherId = publisherId
                });

                return TypedResults.Ok(new GenericResponse<PaymentReportByPublisherModel>(HttpStatusCode.OK, "Request succeeded", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "GetPaymentReportByPublisherIdAsync failed: {Message}", ex.Message);
                return TypedResults.BadRequest<object>(ex.Message);
            }
        }

        public static async Task<Results<Ok<GenericResponse<byte[]>>, BadRequest<object>>> ExportPaymentReportByPublisherIdAsync(
           [FromRoute] long publisherId,
           [FromQuery] int? pageSize,
           [FromQuery] int? pageNumber,
           [FromQuery] DateTime? fromDate,
           [FromQuery] DateTime? toDate,
           [FromQuery] string langKey,
           IMediator mediator,
           IBaseApi baseApi)
        {
            Log.Logger.Information($"Sending ExportPaymentReportByPublisherIdAsync: {publisherId}");

            try
            {
                if (baseApi.User?.Sub != publisherId.ToString())
                {
                    throw new Exception("User does not have permission!");
                }

                var result = await mediator.Send(new ExportPaymentReportByPublisherIdQuery
                {
                    FromDate = fromDate,
                    ToDate = toDate,
                    PageNumber = pageNumber ?? 0,
                    PageSize = pageSize ?? 5000,
                    PublisherId = publisherId,
                    LangKey = langKey
                });

                return TypedResults.Ok(new GenericResponse<byte[]>(HttpStatusCode.OK, "Request succeeded", result));
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ExportPaymentReportByPublisherIdAsync failed: {Message}", ex.Message);
                return TypedResults.BadRequest<object>(ex.Message);
            }
        }
    }
}

