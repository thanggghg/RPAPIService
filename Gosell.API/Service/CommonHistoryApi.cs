using GoSell.CommonHistory.Command;
using GoSell.CommonHistory.Models.Requests;
using GoSell.CommonHistory.Queries;
using GoSell.CommonHistory.Services;
using GoSell.Library.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GoSell.API.Service
{
    public static class CommonHistoryApi
    {
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CreateHistoryNodeAsync([FromBody] CreateHistoryNodeRequestModel request, [AsParameters] CommonHistoryService commonHistoryService)
        {
            var input = new CreateHistoryNodeCommand(request);
            var res = await commonHistoryService.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetHistoryAsync([FromBody] GetHistoryRequestModel request, [AsParameters] CommonHistoryService commonHistoryService)
        {
            var input = new GetHistoryQuery(request);
            var res = await commonHistoryService.Mediator.Send(input);
            return TypedResults.Ok(res);
        }
    }
}
