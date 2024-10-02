
## RP Architecture Overview

The **RP Architecture** is a modern microservices-based structure built using **.NET Core 8**, leveraging **CQRS** (Command Query Responsibility Segregation) and the **Mediator** pattern for handling complex business logic in a clean and efficient way. The architecture employs the **Database First** approach, ensuring that the database schema drives the application model, allowing for quick adaptability to database changes.

### Key Components:

- **RP.API**: The gateway service that orchestrates the communication between client requests and backend services, providing a secure entry point to the system.
- **RP.Common**: Manages shared business logic across the architecture, promoting code reuse and consistency, acting as a utility for common functionalities.
- **RP.GobalCore**: The heart of the system, responsible for executing the main business processes. It uses CQRS and Mediator to handle both command and query responsibilities, enabling efficient and maintainable code.
- **RP.Library**: Acts as a repository of shared functions and resources that support the entire system, promoting modularity and service independence.
- **ProxyClient**: A dedicated project that facilitates API communication between the services. It abstracts the inter-service communication and ensures secure and reliable API interactions, allowing the services to communicate without direct dependencies, enhancing the scalability and fault tolerance of the architecture.

At the core of the architecture is **SQL Server**, which stores and manages all critical data, integrated via the **Database First** methodology. This ensures that the data model is in sync with the evolving database schema, making it adaptable and easier to manage over time.

By utilizing **CQRS** and **Mediator**, this architecture ensures separation of concerns, making it easier to scale, maintain, and adapt to changing business requirements. With **.NET Core 8** at its foundation, it offers high performance, cross-platform support, and cloud-native capabilities, making it ideal for modern, distributed applications.

![RP Architecture Overview](images/RP_architecture.webp)