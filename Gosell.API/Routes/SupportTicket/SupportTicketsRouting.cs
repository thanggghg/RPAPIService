using GoSell.API.Service;
using GoSell.Library.Utils;

namespace GoSell.API.Routes.SupportTicket
{
    public static class SupportTicketsRouting
    {
        public static RouteGroupBuilder MapSupportTicketsApi(this RouteGroupBuilder app)
        {

            app.MapPost("/tickets", SupportTicketsApi.GetSupportTicketAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.SupportTicketAPI);

            app.MapGet("/ticket/{ticketId}", SupportTicketsApi.GetSupportTicketByIdAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.SupportTicketAPI);

            app.MapPost("/ticket-create", SupportTicketsApi.CreateSupportTicketAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.SupportTicketAPI)
                .DisableAntiforgery();

            app.MapPut("/ticket-update", SupportTicketsApi.UpdateSupportTicketAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.SupportTicketAPI);

            app.MapDelete("/ticket-delete/{ticketId}", SupportTicketsApi.DeleteSupportTicketAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.SupportTicketAPI);

            app.MapGet("/issue-type", SupportTicketsApi.GetAllIssueTypeAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.SupportTicketAPI);
              
            app.MapGet("/ticket-detail/{idOrKey}", SupportTicketsApi.GetSupportTicketDetailAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.SupportTicketAPI);

            app.MapPut("/ticket-update-status", SupportTicketsApi.UpdateStatusTicketAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithOpenApi()
                .WithTags(SwaggerConstants.SupportTicketAPI)
                .DisableAntiforgery();

            app.MapPost("/ticket/{idOrKey}/comment", SupportTicketsApi.CreateTicketCommentAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.SupportTicketAPI)
                .DisableAntiforgery();

            app.MapPost("ticket/{idOrKey}", SupportTicketsApi.UpdateLastUpdaterAsync)
                .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
                .WithTags(SwaggerConstants.SupportTicketAPI);

            app.MapGet("download-attachment", SupportTicketsApi.DownloadAttachmentContentAsync)
               .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
               .WithTags(SwaggerConstants.SupportTicketAPI);

            return app;
        }
    }
}
