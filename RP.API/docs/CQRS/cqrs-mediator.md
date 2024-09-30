# Introduction to CQRS with Mediator

## What is CQRS?

**CQRS** stands for **Command Query Responsibility Segregation**. It is an architectural pattern where the responsibility for reading data (queries) and modifying data (commands) is separated into different models.

### 1.1 Key Concepts of CQRS:

- **Command**: Represents operations that change the state of the system (e.g., create, update, or delete actions).
- **Query**: Represents operations that retrieve data without changing the system's state.

By separating these two concerns, **CQRS** allows you to optimize and scale your application more efficiently. For example, you can use one database optimized for writing (commands) and another optimized for reading (queries).

### 1.2 Benefits of CQRS:

- **Scalability**: You can scale read and write operations independently, which is useful in high-performance systems.
- **Separation of concerns**: The logic for writing data and reading data is isolated, making the system more maintainable.
- **Better performance**: You can optimize read operations separately from write operations, often using different data stores or denormalized views for queries.

## What is Mediator?

The **Mediator** pattern is used to reduce the complexity of communication between different components by introducing a central mediator object. This pattern helps in decoupling the sender and receiver, meaning that the sender doesn't need to know who will handle its request.

In the context of **CQRS**, the **Mediator** pattern is used to manage and route **Commands** and **Queries** to their respective handlers. This ensures that the application remains loosely coupled, and changes in one part of the system do not require changes in others.

### 2.1 How CQRS and Mediator Work Together

In a CQRS architecture, **Commands** and **Queries** are sent through the **Mediator**, which dispatches them to the correct handler. 

- **Command Handler**: Responsible for processing commands that modify the system state.
- **Query Handler**: Responsible for handling queries to retrieve data without modifying the system state.

### Example Flow:

1. A **Command** (e.g., "CreateOrder") is sent by the application to the **Mediator**.
2. The **Mediator** routes the command to the appropriate **Command Handler** that processes the command and modifies the system state (e.g., creates a new order).
3. A **Query** (e.g., "GetOrderById") is sent to the **Mediator** to retrieve data from the system.
4. The **Mediator** routes the query to the appropriate **Query Handler**, which returns the required data.

## Implementing CQRS with Mediator in .NET

In .NET, you can implement **CQRS** with **Mediator** using the popular [**MediatR**](https://github.com/jbogard/MediatR) library. This library simplifies the implementation of the Mediator pattern by providing built-in mechanisms for routing commands and queries to their handlers.

### Example Command and Query:

#### Command:

```csharp
public class CreateOrderCommand : IRequest<int>
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}
