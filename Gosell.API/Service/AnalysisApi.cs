using GoSell.Analysis.Application.Queries;
using GoSell.Analysis.Models;
using GoSell.Analysis.Models.Dto;
using GoSell.Analysis.Models.Dto.Promotion;
using GoSell.Analysis.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

namespace GoSell.API.Service
{
    public static class AnalysisApi
    {
        public static async Task<Results<Ok<AnalysisChartResponseModel>, NotFound>> SearchAnalysisChartAsync(AnalysisChartModelQuery request, [AsParameters] AnalysisService services)
        {
            try
            {
                if (request.ProductIds.Count > Utils.UtilsConstants.ProductIdLimit || request.CollectionIds.Count > Utils.UtilsConstants.ProductIdLimit)
                {
                    Log.Error("ProductIds length exceeds limit");
                    return TypedResults.NotFound();
                }

                var orders = await services.Mediator.Send(request);

                return TypedResults.Ok(orders);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<AnalysisResponseModel>, NotFound>> SearchAnalystMetricAsync(AnalysisChartMetricQuery request, [AsParameters] AnalysisService services)
        {
            try
            {
                var rep = await services.Mediator.Send(request);
                return TypedResults.Ok(rep);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<AnalysisChartResponseModel>, NotFound>> SearchAnalystTopBestSellAsync(AnalystTopBestSellQuery request, [AsParameters] AnalysisService services)
        {
            try
            {
                var rep = await services.Mediator.Send(request);
                return TypedResults.Ok(rep);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<AnalysisChartResponseModel>, NotFound>> SearchAnalystTopMostViewedAsync(AnalystTopMostViewedQuery request, [AsParameters] AnalysisService services)
        {
            try
            {
                var rep = await services.Mediator.Send(request);
                return TypedResults.Ok(rep);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<AnalysisChartResponseModel>, NotFound>> SearchAnalystTopInCompleteCheckoutAsync(AnalystTopInCompleteCheckoutQuery request, [AsParameters] AnalysisService services)
        {
            try
            {
                var rep = await services.Mediator.Send(request);
                return TypedResults.Ok(rep);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<AnalysisResponseModel>, NotFound>> SearchAnalystInitDataByStoreAsync(AnalystInitDataQuery request, [AsParameters] AnalysisService services)
        {
            try
            {
                var rep = await services.Mediator.Send(request);
                return TypedResults.Ok(rep);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<AnalysisResponseModel>, NotFound>> SearchAnalystInitSpecialDataByStoreAsync(AnalystInitSpecialDataQuery request, [AsParameters] AnalysisService services)
        {
            try
            {
                var rep = await services.Mediator.Send(request);
                return TypedResults.Ok(rep);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }


        #region Promotion Analytics
        public static async Task<Results<Ok<PromotionResponseModel>, NotFound>> SearchAnalystPromotionMetricAsync(AnalysisPromotionMetricQuery request, [AsParameters] AnalysisService services)
        {
            try
            {
                var rep = await services.Mediator.Send(request);
                return TypedResults.Ok(rep);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<PromotionResponseModel>, NotFound>> SearchPromotionAnalystInitDataByStoreAsync(AnalystPromotionInitDataQuery request, [AsParameters] AnalysisService services)
        {
            try
            {
                var rep = await services.Mediator.Send(request);
                return TypedResults.Ok(rep);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<PromotionChartResponseModel>, NotFound>> SearchAnalystPromotionTopRevenueAsync(AnalystPromotionTopRevenueQuery request, [AsParameters] AnalysisService services)
        {
            try
            {
                var rep = await services.Mediator.Send(request);
                return TypedResults.Ok(rep);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<PromotionChartResponseModel>, NotFound>> SearchAnalystPromotionTopProductAsync(AnalystPromotionTopProductQuery request, [AsParameters] AnalysisService services)
        {
            try
            {
                var rep = await services.Mediator.Send(request);
                return TypedResults.Ok(rep);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<PromotionChartResponseModel>, NotFound>> SearchAnalysistPromotionChartTypeDistributionAsync(AnalystPromotionTypeDistributionQuery request, [AsParameters] AnalysisService services)
        {
            try
            {
                var rep = await services.Mediator.Send(request);
                return TypedResults.Ok(rep);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<PromotionChartResponseModel>, NotFound>> SearchAnalysistPromotionChartRevenueTypeDistributionAsync(AnalystPromotionRevenueTypeDistributionQuery request, [AsParameters] AnalysisService services)
        {
            try
            {
                var rep = await services.Mediator.Send(request);
                return TypedResults.Ok(rep);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }
        #endregion

        #region REPORT JOB
        public static async Task<Results<Ok<List<string>>, NotFound>> ReportItemJobAsync(
            [FromBody] ReportItemJobModelQuery request,
            [AsParameters] AnalysisService services)
        {
            try
            {
                var res = await services.Mediator.Send(request);
                return TypedResults.Ok(res);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<List<string>>, NotFound>> ReportOrderJobAsync(
            [FromBody] ReportOrderJobModelQuery request,
            [AsParameters] AnalysisService services)
        {
            try
            {
                var res = await services.Mediator.Send(request);
                return TypedResults.Ok(res);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<List<string>>, NotFound>> ReportLazadaJobAsync(
            [FromBody] ReportLazadaJobModelQuery request,
            [AsParameters] AnalysisService services)
        {
            try
            {
                var res = await services.Mediator.Send(request);
                return TypedResults.Ok(res);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<List<string>>, NotFound>> ReportShopeeJobAsync(
            [FromBody] ReportShopeeJobModelQuery request,
            [AsParameters] AnalysisService services)
        {
            try
            {
                var res = await services.Mediator.Send(request);
                return TypedResults.Ok(res);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<Ok<List<string>>, NotFound>> ReportTiktokJobAsync(
            [FromBody] ReportTiktokJobModelQuery request,
            [AsParameters] AnalysisService services)
        {
            try
            {
                var res = await services.Mediator.Send(request);
                return TypedResults.Ok(res);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return TypedResults.NotFound();
            }
        }
        #endregion END REPORT JOB

    }
}
