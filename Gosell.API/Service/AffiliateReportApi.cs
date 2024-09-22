using System.Net;
using GoSell.Common.Helpers;
using GoSell.Common.Models;
using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Api;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

namespace GoSell.API.Service
{
    public static class AffiliateReportApi
    {
        public static async Task<Results<Ok<GenericResponse<SummaryDashboardReportResponse>>, BadRequest<BaseResponse>>> GetSummaryDashboardReportAsync(
            IMediator mediator,
            IBaseApi baseApi,
            [FromBody] DashboardReportBaseQuery query)
        {
            Log.Logger.Information($"Starting calling {nameof(GetSummaryDashboardReportAsync)}");
            var dateRangeAndValidate = GetDateRangeToUTCValidateReport(query.GoSellStoreId, query.FromDate, query.ToDate);
            query.FromDate = dateRangeAndValidate.FromDate;
            query.ToDate = dateRangeAndValidate.ToDate;
            var result = await mediator.Send(new GetCommisionOrderSummaryDashboardReportQuery
            {
                AffiliateStoreId = query.AffiliateStoreId,
                FromDate = query.FromDate,
                ToDate = query.ToDate,
                GoSellStoreId = query.GoSellStoreId,
                StoreStatus = query.StoreStatus
            });
            Log.Logger.Information($"Done {nameof(GetSummaryDashboardReportAsync)}");
            return TypedResults.Ok(new GenericResponse<SummaryDashboardReportResponse>(HttpStatusCode.OK, "Request succeeded", result));
        }

        public static async Task<Results<Ok<GenericResponse<List<TopPublishersReportResponse>>>, BadRequest<BaseResponse>>> GetTopSellingPublisherReportAsync(
           IMediator mediator,
           IBaseApi baseApi,
           [FromBody] GetTopPublishersReportQuery query)
        {
            Log.Logger.Information($"Starting calling {nameof(GetTopSellingPublisherReportAsync)}");
            var dateRangeAndValidate = GetDateRangeToUTCValidateReport(query.GoSellStoreId, query.FromDate, query.ToDate);
            query.FromDate = dateRangeAndValidate.FromDate;
            query.ToDate = dateRangeAndValidate.ToDate;
            var commissionRevenueReport = await mediator.Send(query);
            if (commissionRevenueReport.Any())
            {
                var publisherInfo = await mediator.Send(new GetAffiliateUserStoreByIdsCommand { Ids = commissionRevenueReport.Select(s => s.PublisherId).ToList() });
                var result = commissionRevenueReport.Join(publisherInfo.AffiliateUserStoreModels,
                    com => com.PublisherId,
                    pub => pub.Id,
                    (com, pub) => new TopPublishersReportResponse
                    {
                        PublisherId = com.PublisherId,
                        PublisherCode = pub.PublisherCode,
                        PublisherName = pub.PublisherName,
                        Revenue = com.Revenue,
                        Commission = com.Commission
                    }).ToList();
                Log.Logger.Information($"Done {nameof(GetTopSellingPublisherReportAsync)}");
                return TypedResults.Ok(new GenericResponse<List<TopPublishersReportResponse>>(HttpStatusCode.OK, "Request succeeded", result));
            }
            Log.Logger.Information($"Done {nameof(GetTopSellingPublisherReportAsync)}");
            return TypedResults.Ok(new GenericResponse<List<TopPublishersReportResponse>>(HttpStatusCode.OK, "Request succeeded", commissionRevenueReport));
        }
        public static async Task<Results<Ok<GenericResponse<List<TopProductsReportResponse>>>, BadRequest<BaseResponse>>> GetTopSellingProductReportAsync(
          IMediator mediator,
          IBaseApi baseApi,
          [FromBody] GetTopProductReportQuery query)
        {
            Log.Logger.Information($"Starting calling {nameof(GetTopSellingProductReportAsync)}");
            var dateRangeAndValidate = GetDateRangeToUTCValidateReport(query.GoSellStoreId, query.FromDate, query.ToDate);
            query.FromDate = dateRangeAndValidate.FromDate;
            query.ToDate = dateRangeAndValidate.ToDate;
            var topProducts = await mediator.Send(query);
            Log.Logger.Information($"Done {nameof(GetTopSellingProductReportAsync)}");
            return TypedResults.Ok(new GenericResponse<List<TopProductsReportResponse>>(HttpStatusCode.OK, "Request succeeded", topProducts.Skip(query.Page * query.Size).Take(query.Size).ToList()));
        }

        public static async Task<Results<Ok<GenericResponse<OrderTrendReportResponse>>, BadRequest<BaseResponse>>> GetOrderTrendReportAsync(
          IMediator mediator,
          IBaseApi baseApi,
          [FromBody] GetOrderTrendReportQuery query)
        {
            Log.Logger.Information($"Starting calling {nameof(GetOrderTrendReportAsync)}");
            var dateRangeAndValidate = GetDateRangeToUTCValidateReport(query.GoSellStoreId, query.FromDate, query.ToDate);
            query.FromDate = dateRangeAndValidate.FromDate;
            query.ToDate = dateRangeAndValidate.ToDate;
            var result = await mediator.Send(query);
            Log.Logger.Information($"Done {nameof(GetOrderTrendReportAsync)}");
            return TypedResults.Ok(new GenericResponse<OrderTrendReportResponse>(HttpStatusCode.OK, "Request succeeded", result));
        }

        public static async Task<Results<Ok<GenericResponse<ProductCommissionReportResponse>>, BadRequest<BaseResponse>>> GetProductCommissionReportAsync(
          IMediator mediator,
          IBaseApi baseApi,
          [FromQuery] long goSellStoreId,
          [FromBody] GetProductCommissionReportQuery query)
        {
            Log.Logger.Information($"Starting calling {nameof(GetProductCommissionReportAsync)}");
            query.GoSellStoreId = goSellStoreId;
            var result = await mediator.Send(query);
            Log.Logger.Information($"Done {nameof(GetProductCommissionReportAsync)}");
            return TypedResults.Ok(new GenericResponse<ProductCommissionReportResponse>(HttpStatusCode.OK, "Request successfully", result));
        }

        public static async Task<Results<Ok<GenericResponse<CampaignCommissionReportResponse>>, BadRequest<BaseResponse>>> GetCampaignCommissionReportAsync(
          IMediator mediator,
          IBaseApi baseApi,
          [FromQuery] long goSellStoreId,
          [FromBody] GetCampaignCommissionReportQuery query)
        {
            Log.Logger.Information($"Starting calling {nameof(GetCampaignCommissionReportAsync)}");
            query.GoSellStoreId = goSellStoreId;
            var result = await mediator.Send(query);
            Log.Logger.Information($"Done {nameof(GetCampaignCommissionReportAsync)}");
            return TypedResults.Ok(new GenericResponse<CampaignCommissionReportResponse>(HttpStatusCode.OK, "Request successfully", result));
        }

        public static async Task<Results<Ok<GenericResponse<ProductPublisherCommissionReportResponse>>, BadRequest<BaseResponse>>> GetProductCommissionPublisherReportAsync(
          IMediator mediator,
          IBaseApi baseApi,
          [FromBody] GetProductPublisherCommissionReportQuery query)
        {
            Log.Logger.Information($"Starting calling {nameof(GetProductCommissionPublisherReportAsync)}");
            var userToken = baseApi.User;
            var result = await mediator.Send(new GetProductPublisherCommissionReportQuery
            {
                UserId = userToken.userAffiliateStoreId,
                FromDate = query.FromDate,
                ToDate = query.ToDate,
                Page = query.Page,
                SearchKeyword = query.SearchKeyword,
                SearchType = query.SearchType,
                Size = query.Size,
                AffiliateStoreId = userToken.AffiliateStoreId
            });
            Log.Logger.Information($"Done {nameof(GetProductCommissionPublisherReportAsync)}");
            return TypedResults.Ok(new GenericResponse<ProductPublisherCommissionReportResponse>(HttpStatusCode.OK, "Request successfully", result));
        }

        private static (DateTime? FromDate, DateTime? ToDate) GetDateRangeToUTCValidateReport(long goSellStoreId, DateTime? fromDate, DateTime? toDate)
        {
            if (goSellStoreId == 0)
            {
                throw new Exception("GoSellStoreId does not exist");
            }

            DateTime? from = fromDate.HasValue ? Helpers.CustomStartDateToUtc(fromDate.Value) : null;
            DateTime? to = toDate.HasValue ? Helpers.CustomEndDateToUtc(toDate.Value) : null;

            return (from, to);
        }
    }
}
