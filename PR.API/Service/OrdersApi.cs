using GoSell.Orders.Commands;
using GoSell.Orders.Queries;
using GoSell.Orders.Services;
using Microsoft.AspNetCore.Http.HttpResults;
namespace GoSell.API.Service
{
    public static class OrdersApi
    {
        public static async Task<Results<Ok, BadRequest<string>>> CreateOrderAsync(
            [FromHeader(Name = "x-requestid")] Guid requestId,
            CreateOrderRequest request,
            [AsParameters] OrderServices services)
        {
            services.Logger.LogInformation(
                "Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                "",
                nameof(request.UserId),
                request.UserId,
                request);

            if (requestId == Guid.Empty)
            {
                services.Logger.LogWarning("Invalid IntegrationEvent - RequestId is missing - {@IntegrationEvent}", request);
                return TypedResults.BadRequest("RequestId is missing.");
            }
            var createOrderCommand = new CreateOrderCommand(request.UserId, request.UserName, request.City, request.Street,
                request.State, request.Country, request.ZipCode,
                request.CardNumber, request.CardHolderName, request.CardExpiration,
                request.CardSecurityNumber, request.CardTypeId);

            var result = await services.Mediator.Send(createOrderCommand);

            if (result)
            {
                services.Logger.LogInformation("CreateOrderCommand succeeded - RequestId: {RequestId}", requestId);
            }
            else
            {
                services.Logger.LogWarning("CreateOrderCommand failed - RequestId: {RequestId}", requestId);
            }

            return TypedResults.Ok();
        }

        public static async Task<Results<Ok<List<OrderViewModel>>, NotFound>> GetOrderAsync(int orderId, [AsParameters] OrderServices services)
        {
            try
            {
                //var orders = await services.Mediator.Send(new GetOrdersListQuery
                //{
                //    ordernumber = orderId
                //});
                await Task.Delay(1000);
                return TypedResults.Ok(new List<OrderViewModel>());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return TypedResults.NotFound();
            }
        }

    }

    public record CreateOrderRequest(
        string UserId,
        string UserName,
        string City,
        string Street,
        string State,
        string Country,
        string ZipCode,
        string CardNumber,
        string CardHolderName,
        DateTime CardExpiration,
        string CardSecurityNumber,
        int CardTypeId,
        string Buyer);
}
