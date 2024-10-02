

## Implementing CQRS with Mediator in .NET

We will use the **MediatR** library to implement **CQRS with Mediator** in a .NET application. Below are steps to implement both **commands** and **queries**.

### Step 1: Install MediatR
`dotnet add package MediatR dotnet add package MediatR.Extensions.Microsoft.DependencyInjection`

First, install the **MediatR** and **MediatR.Extensions.Microsoft.DependencyInjection** packages into your project:


dotnet add package MediatR
dotnet add package MediatR.Extensions.Microsoft.DependencyInjection

enter code here

### Step 2: Define a Command and Command Handler
**Example Command:** CreateOrderCommand
This command represents an action to create a new order in the system.


    public class CreateOrderCommand : IRequest<int> {
        public string ProductName { get; set; }
        public int Quantity { get; set; } }

**IRequest<int>**: This indicates that the command will return an integer (the ID of the newly created order).

**Command Handler**: CreateOrderCommandHandler
The handler processes the CreateOrderCommand and performs the action (e.g., saving the order to a database).

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        public Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // Simulate saving to a database
            int newOrderId = 1;  // This would normally come from the database
            Console.WriteLine($"Order created: {request.ProductName}, Quantity: {request.Quantity}");
            
            return Task.FromResult(newOrderId);
        }
    }

### Step 3: Define a Query and Query Handler

#### Example Query: `GetOrderByIdQuery`

This query retrieves an order by its ID.

    public class GetOrderByIdQuery : IRequest<Order>
    {
        public int OrderId { get; set; }
    }
#### Query Handler: `GetOrderByIdQueryHandler`

This handler processes the query and returns the requested order.

    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        public Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            // Simulate fetching from a database
            var order = new Order
            {
                OrderId = request.OrderId,
                ProductName = "Sample Product",
                Quantity = 2
            };
            
            return Task.FromResult(order);
        }
    }
**Step 4: Register MediatR in ASP.NET Core**
In your `Program.cs` or `Startup.cs`, register **MediatR** so that it can resolve handlers for commands and queries:
using MediatR;

    using Microsoft.Extensions.DependencyInjection;
    
    var builder = WebApplication.CreateBuilder(args);
    
    // Register MediatR services
    builder.Services.AddMediatR(typeof(Program).Assembly);
    
    var app = builder.Build();
    app.MapControllers();
    
    app.Run();
**Step 5: Using CQRS in Controllers**
You can now use **MediatR** to send commands and queries in your controllers.

#### Example of sending a Command:

    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
    
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
    
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var orderId = await _mediator.Send(command);
            return Ok(new { OrderId = orderId });
        }
    }
Example of sending a Query:

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var query = new GetOrderByIdQuery { OrderId = id };
        var order = await _mediator.Send(query);
        
        if (order == null)
        {
            return NotFound();
        }
    
        return Ok(order);
    }
### Conclusion

By using **CQRS with the Mediator pattern**, you can cleanly separate read and write operations, ensuring that your application is scalable, maintainable, and easy to extend. The **MediatR** library makes it simple to implement this pattern by abstracting the dispatching of commands and queries, allowing your application logic to remain clean and decoupled.

### Summary

This file introduces **CQRS** and **Mediator** with examples in .NET using **MediatR**. It explains how to define commands and queries, and how to handle them using the **Mediator** pattern. This structure can be extended further depending on your documentation needs.

