using GoSell.CommonTicket.Command.CommonTicket;
using GoSell.CommonTicket.Command.Store;
using GoSell.CommonTicket.Models.Requests;
using GoSell.CommonTicket.Queries;
using GoSell.CommonTicket.Services.CommonTicket;
using GoSell.CommonTicket.Services.Store;
using GoSell.Library.Helpers;
using GoSell.SupportTicket.Models.Requests;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

namespace GoSell.API.Service
{
    public static class CommonTicketsApi
    {
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> CreateCommonTicketAsync([FromBody] GoSell.CommonTicket.Models.Requests.CreateTicketRequestModel request, [AsParameters] CommonTicketService commonTicketService)
        {
            var input = new CreateTicketCommand(request);
            var res = await commonTicketService.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetListCommonTicketsAsync([FromBody] GetListTicketsRequestModel request, [AsParameters] CommonTicketService commonTicketService)
        {
            var input = new GetTicketsQuery(request);
            var res = await commonTicketService.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetTicketDetailAsync([FromRoute] long ticketId, [AsParameters] CommonTicketService commonTicketService)
        {
            var input = new GetTicketDetailQuery(ticketId);
            var res = await commonTicketService.Mediator.Send(input);
            Log.Logger.Information($"DONE {nameof(GetTicketDetailQuery)}");
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetTicketWorkflowAsync([FromBody] GetTicketWorkflowRequestModel request, [AsParameters] CommonTicketService commonTicketService)
        {
            var input = new GetTicketWorkflowQuery(request);
            var res = await commonTicketService.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetStaffsAsync([FromBody] GetStaffsRequestModel request, [AsParameters] StoreService storeService)
        {
            var input = new GetStaffsQuery(request);
            var res = await storeService.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> UpdateCommonTicketAsync([FromBody] UpdateTicketCommand request, [AsParameters] CommonTicketService commonTicketService)
        {
            var res = await commonTicketService.Mediator.Send(request);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> DeleteTicketsAsync([FromBody] DeleteMultipleTicketCommand request, [AsParameters] CommonTicketService commonTicketService)
        {
            var res = await commonTicketService.Mediator.Send(request);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> SaveCommonTicketWorkflow([FromBody] SaveTicketWorkflowCommand request, [AsParameters] CommonTicketService commonTicketService)
        {
            var res = await commonTicketService.Mediator.Send(request);
            return TypedResults.Ok(res);
        }
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetTicketsByType([AsParameters] GetTicketsByTypeQuery request, [AsParameters] StoreService storeService)
        {
            var res = await storeService.Mediator.Send(request);
            return TypedResults.Ok(res);
        }
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> PrintTicketData([FromRoute] long ticketId, [AsParameters] StoreService storeService)
        {
            var res = await storeService.Mediator.Send(new PrintTicketQuery(ticketId));
            return TypedResults.Ok(res);
        }
    }
}
