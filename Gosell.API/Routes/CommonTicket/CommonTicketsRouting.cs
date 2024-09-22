using GoSell.API.Service;
using GoSell.Library.Utils;

namespace GoSell.API.Routes.CommonTicket
{
    public static class CommonTicketsRouting
    {
        public static RouteGroupBuilder MapCommonTicketsApi(this RouteGroupBuilder app)
        {
            app.MapPost("/ticket-create", CommonTicketsApi.CreateCommonTicketAsync)
             .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
             .WithTags(SwaggerConstants.CommonTicketAPI)
             .WithOpenApi()
             .DisableAntiforgery();

            app.MapPost("/get-tickets", CommonTicketsApi.GetListCommonTicketsAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags(SwaggerConstants.CommonTicketAPI)
            .WithOpenApi()
            .DisableAntiforgery();

            app.MapGet("/get-ticket/{ticketId}", CommonTicketsApi.GetTicketDetailAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags(SwaggerConstants.CommonTicketAPI)
            .WithOpenApi()
            .DisableAntiforgery();

            app.MapPost("/get-staffs", CommonTicketsApi.GetStaffsAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags(SwaggerConstants.CommonTicketAPI)
            .WithOpenApi()
            .DisableAntiforgery();

            app.MapPost("/get-ticket-workflow", CommonTicketsApi.GetTicketWorkflowAsync)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags(SwaggerConstants.CommonTicketAPI)
            .WithOpenApi()
            .DisableAntiforgery();

            app.MapPut("/update-ticket", CommonTicketsApi.UpdateCommonTicketAsync)
           .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
           .WithTags(SwaggerConstants.CommonTicketAPI)
           .WithOpenApi()
           .DisableAntiforgery();

            app.MapDelete("/delete-tickets", CommonTicketsApi.DeleteTicketsAsync)
           .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
           .WithTags(SwaggerConstants.CommonTicketAPI)
           .WithOpenApi()
           .DisableAntiforgery();

            app.MapPost("/save-workflow", CommonTicketsApi.SaveCommonTicketWorkflow)
             .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
             .WithTags(SwaggerConstants.CommonTicketAPI)
             .WithOpenApi()
             .DisableAntiforgery();


            app.MapGet("/get-tickets-by-type", CommonTicketsApi.GetTicketsByType)
             .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
             .WithTags(SwaggerConstants.CommonTicketAPI)
             .WithOpenApi()
             .DisableAntiforgery();

            app.MapGet("/print-ticket/{ticketId}", CommonTicketsApi.PrintTicketData)
            .AddRequireAuthorizationJWTToken(AuthoritiesConstants.USER)
            .WithTags(SwaggerConstants.CommonTicketAPI)
            .WithOpenApi()
            .DisableAntiforgery();
            return app;
        }
    }
}
