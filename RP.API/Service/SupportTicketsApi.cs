using GoSell.Library.Helpers;
using GoSell.SupportTicket.Application.Commands.SupportTicket;
using GoSell.SupportTicket.Command.SupportTicket;
using GoSell.SupportTicket.Models.Requests;
using GoSell.SupportTicket.Models.Responses;
using GoSell.SupportTicket.Services.SupportTicket;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GoSell.API.Service
{
    public static class SupportTicketsApi
    {
        public static async Task<Results<Ok<GenericResponse<TicketResultModel>>, BadRequest<string>>> GetSupportTicketAsync(GetTicketRequestModel request, [AsParameters] SupportTicketService supportTicketService)
        {
            var input = new GetListTicketCommand(request);
            var res = await supportTicketService.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetSupportTicketByIdAsync(string ticketId, string[] field, [AsParameters] SupportTicketService supportTicketService)
        {
            var input = new GetListTicketByIdCommand(ticketId, field);
            var res = await supportTicketService.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<GenericResponse<ResponseTicketModel>>, BadRequest<string>>> CreateSupportTicketAsync([FromForm] CreateTicketRequestModel request, [AsParameters] SupportTicketService supportTicketService)
        {
            var input = new CreateTicketCommand(request);
            var res = await supportTicketService.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> UpdateSupportTicketAsync([FromBody] TicketRequestModel request, [AsParameters] SupportTicketService supportTicketService)
        {
            var input = new UpdateTicketCommand(request);
            var res = await supportTicketService.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> DeleteSupportTicketAsync(long ticketId, [AsParameters] SupportTicketService supportTicketService)
        {
            var input = new DeleteListTicketByIdCommand(ticketId);
            var res = await supportTicketService.Mediator.Send(input);
            return TypedResults.Ok(res);
        }
        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetAllIssueTypeAsync([AsParameters] SupportTicketService supportTicketService)
        {
            var input = new GetAllIssueTypeCommand();
            var res = await supportTicketService.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> GetSupportTicketDetailAsync(string idOrKey, [AsParameters] SupportTicketService supportTicketService)
        {
            var res = await supportTicketService.Mediator.Send(new GetTicketDetailCommand { IdOrKey = idOrKey });
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> UpdateStatusTicketAsync([FromBody] UpdateStatusTicketRequestModel request, [AsParameters] SupportTicketService supportTicketService)
        {
            var input = new UpdateStatusTicketCommand(request);
            var res = await supportTicketService.Mediator.Send(input);
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<GenericResponse<ResponseTicketModel>>, BadRequest<string>>> CreateTicketCommentAsync([FromRoute] string idOrKey, [FromForm] CreateCommentRequestModel request, [AsParameters] SupportTicketService supportTicketService)
        {
            var res = await supportTicketService.Mediator.Send(new CreateTicketCommentCommand(idOrKey, request));
            return TypedResults.Ok(res);
        }

        public static async Task<Results<Ok<BaseResponse>, BadRequest<string>>> UpdateLastUpdaterAsync([FromRoute] string idOrKey, [FromBody] UpdateLastUpdaterRequestModel request, [AsParameters] SupportTicketService supportTicketService)
        {
            var res = await supportTicketService.Mediator.Send(new UpdateLastUpdaterCommand(idOrKey, request));
            return TypedResults.Ok(res);
        }

        public static async Task<FileContentHttpResult> DownloadAttachmentContentAsync(
            string id,
            string mimeTpe,
            [AsParameters] SupportTicketService supportTicketService)
        {
            var input = new DownloadAttachmentContentCommand(id, mimeTpe);
            var res = await supportTicketService.Mediator.Send(input);
            return res;
        }
    }
}
