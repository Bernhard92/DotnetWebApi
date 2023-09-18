
# SUKiiServer

## Chapter 1: Onion Architecture

- [Overview](#onion-architecture)
- [Project Structure](#project-structure-overview)
  - [Domain Project Folder Structure](#domain-project-folder-structure)
  - [Application Project Folder Structure](#application-project-folder-structure)
  - [Infrastructure Project Folder Structure](#infrastructure-project-folder-structure)
  - [Presentation Project Folder Structure](#presentation-project-folder-structure)

## Chapter 2: Registering Classes (Dependency Injection)

- [Dependency Injection](#Registering-Classes-(Dependency-Injection))


## Chapter 3: Create a Migration

- [Database Migrations](#Create-a-Migraion)
  - [Entity Framework Migrations](#entity-framework-migrations)
  - [Using Visual Studio](#using-visual-studio)


# Onion Architecture
**Project Structure Overview**

The project structure follows Domain-Driven Design (DDD) principles and implements the Command Query Responsibility Segregation (CQRS) pattern for a .NET Core Web API. It promotes a clean and maintainable architecture that separates concerns, making it scalable and easy to work with.

**1. Solution**
   - The solution is organized into multiple projects, each serving a specific purpose.

**2. Domain Project**
   - At the core of the application, this project contains the fundamental domain logic.
   - It defines entities, aggregates, value objects, and domain events.
   - It houses business rules and validations.
   - It provides the foundation for the application's behavior.

**3. Application Project**
   - Serving as an application layer, this project acts as an intermediary between the domain and presentation layers.
   - It implements the CQRS pattern by defining commands and queries.
   - This is where command handlers and query handlers are located.
   - It orchestrates the flow of data between the domain and presentation layers.
  
**4. Presentation Project (Web API)**
   - Representing the user interface layer of the application.
   - It contains controllers responsible for handling HTTP requests and responses.
   - Utilizes DTOs (Data Transfer Objects) for communication with the application layer.
   - Relies on query handlers to retrieve data and command handlers to perform actions.

**5. Infrastructure Project**
   - Provides infrastructure concerns such as data access, external services, and cross-cutting concerns.
   - Contains repositories responsible for data access to domain entities.
   - Manages database connections using Entity Framework.
   - May include caching, logging, and other infrastructure-related components.
   - Focuses on database-related configurations.
   - Contains Entity Framework Core DbContext configurations.
   - Manages migrations and database schema changes.

**7. Shared Kernel Project**
   - Contains shared domain concepts used across multiple subdomains.
   - Ensures consistency and prevents duplication of domain logic.

**8. Tests Projects**
   - Includes unit tests, integration tests, and other test-related projects.
   - Ensures the correctness and reliability of the application.
   - Adheres to a Test-Driven Development (TDD) approach.


## Domain Project Folder Structure

The Domain Project is at the core of the application, housing the domain logic and concepts. It is organized into various folders, each serving a specific purpose:

**1. Entities**
   - *Description*: This folder contains the primary building blocks of the domain, known as entities. Entities represent real-world objects with a distinct identity.
   - *Usage*: Entities encapsulate the state and behavior of domain objects. They often have unique identifiers and are the cornerstone of the domain model.

**2. Aggregates**
   - *Description*: Aggregates are a higher-level concept that groups related entities and value objects together. They are defined in this folder.
   - *Usage*: Aggregates ensure consistency and transactional boundaries within the domain. They are often manipulated as a single unit.

**3. **ValueObjects****
   - *Description*: This folder contains value objects, which are objects without a distinct identity. Value objects are immutable and represent characteristics or attributes of domain entities.
   - *Usage*: Value objects are shared across entities and aggregates to represent data that doesn't require its own identity.

**4. **DomainEvents****
   - *Description*: Domain events represent significant changes or occurrences within the domain. They are defined in this folder.
   - *Usage*: Domain events are used to decouple parts of the domain, allowing different components to react to events without direct dependencies.

**5. **Repositories****
   - *Description*: The repositories folder houses repository interfaces that define the contract for data access and persistence.
   - *Usage*: Repositories are used to interact with the data store, allowing the application to retrieve and persist domain objects.

**6. **Services****
   - *Description*: Services related to domain logic but not directly tied to entities or aggregates are placed here.
   - *Usage*: Services often encapsulate complex domain logic that doesn't naturally fit within entities or aggregates.

**7. **Specifications****
   - *Description*: Specifications define criteria for selecting or filtering domain objects.
   - *Usage*: Specifications are used for querying and filtering entities based on specific conditions.

**8. **Exceptions****
   - *Description*: Custom domain-specific exceptions are placed in this folder.
   - *Usage*: These exceptions capture domain-specific error conditions and are used for error handling within the domain.

**9. **Enums****
   - *Description*: Enumeration types representing domain-specific values or states can be found here.
   - *Usage*: Enums provide a way to model discrete sets of values within the domain.

**10. Interfaces**
   - *Description*: This folder contains interfaces representing various contracts and abstractions within the domain.
   - *Usage*: Interfaces define the interactions between different parts of the application, promoting loose coupling.

**11. Events** (Optional)
   - *Description*: If you implement an event sourcing pattern, this folder may contain event sourcing-related components.
   - *Usage*: Event sourcing captures and persists changes to the state of entities as a series of events.

The folder structure within the Domain Project ensures a well-organized and maintainable domain model, facilitating the implementation of business rules and logic within the application.

## Application Project Folder Structure

The Application Project serves as the bridge between the domain logic and the presentation layer, implementing the CQRS pattern. It is organized into various folders, each serving a specific purpose:

**1. Commands**
   - *Description*: The "Commands" folder houses command definitions that represent actions or requests to change the state of the application.
   - *Usage*: Commands are used to encapsulate and validate user or system requests for modifying data within the domain.

**2. CommandHandlers**
   - *Description*: Command handlers are responsible for processing and executing commands, often invoking domain logic.
   - *Usage*: Command handlers orchestrate the execution of commands and ensure that they are processed correctly.

**3. Queries**
   - *Description*: The "Queries" folder contains query definitions that represent requests for retrieving data from the domain.
   - *Usage*: Queries define the data that should be retrieved and returned to the client.

**4. QueryHandlers**
   - *Description*: Query handlers are responsible for executing queries and retrieving data from the domain.
   - *Usage*: Query handlers retrieve data and map it to DTOs (Data Transfer Objects) to be returned to the client.

**5. DTOs**
   - *Description*: Data Transfer Objects (DTOs) are used to transfer data between the application and the presentation layer.
   - *Usage*: DTOs help in shaping and structuring the data to be returned to clients, ensuring that only relevant information is exposed.

**6. Validators**
   - *Description*: Validators are used to validate commands before they are executed. They enforce business rules and ensure that commands are well-formed.
   - *Usage*: Validators help maintain data integrity and ensure that only valid requests are processed.

**7. Services**
   - *Description*: The "Services" folder contains application-level services that provide additional functionality beyond command and query handling.
   - *Usage*: Services can perform tasks like authentication, authorization, or external service integration.

**8. Notifications** (Optional)
   - *Description*: If your application sends notifications or events, this folder may contain components related to event dispatching.
   - *Usage*: Notifications can be used to inform clients or other parts of the application about specific events or changes.

**9. Interfaces**
   - *Description*: Interfaces represent contracts and abstractions for application services.
   - *Usage*: Interfaces help decouple components, making it easier to switch implementations or introduce new features.

**10. Exceptions**
    - *Description*: Custom application-specific exceptions can be placed in this folder.
    - *Usage*: These exceptions capture application-specific error conditions and are used for error handling within the application.

The folder structure within the Application Project separates the responsibilities of handling commands and queries, ensuring that the application logic is well-organized and adheres to the principles of CQRS. This organization promotes maintainability and scalability, allowing for easier addition of new features and modifications to existing functionality.

## Infrastructure Project Folder Structure

The Infrastructure Project provides infrastructure concerns, such as data access, external services, and cross-cutting concerns. It is organized into various folders, each serving a specific purpose:

**1. Data**
   - *Description*: The "Data" folder contains components related to data access and persistence.
   - *Usage*: This folder typically includes repository implementations, database context configurations, and data access-related utilities.

**2. Repositories**
   - *Description*: Repository implementations that interact with the database or other data sources are placed here.
   - *Usage*: Repositories in this folder are responsible for data retrieval and storage, following the defined contracts from the domain.

**3. Migrations**
   - *Description*: If you're using Entity Framework Core or a similar ORM, this folder may contain database migration scripts.
   - *Usage*: Migrations are used to evolve the database schema as the application changes.

**4. ExternalServices**
   - *Description*: Components that interact with external services or APIs are stored in this folder.
   - *Usage*: This folder encapsulates the logic for communicating with external systems, such as third-party APIs or microservices.

**5. Logging**
   - *Description*: Components related to logging and log management are placed here.
   - *Usage*: Logging configurations and utilities ensure that application events and errors are properly logged for monitoring and debugging.

**6. Caching** (Optional)
   - *Description*: If your application includes caching mechanisms, caching-related components may be found here.
   - *Usage*: Caching can improve performance by storing frequently accessed data in memory or other cache stores.

**7. Configuration**
   - *Description*: Configuration-related files and utilities, such as app settings and environment-specific configurations, are stored here.
   - *Usage*: Configuration settings are used to configure various aspects of the application.

**8. Security** (Optional)
   - *Description*: Security-related components, such as authentication and authorization implementations, may be located in this folder.
   - *Usage*: Security components ensure that the application enforces access control and user authentication.

**9. CrossCuttingConcerns**
   - *Description*: Cross-cutting concerns like exception handling, performance monitoring, or request/response logging can be organized here.
   - *Usage*: Cross-cutting concerns are aspects of the application that affect multiple parts and are abstracted for reuse.

**10. Helpers**
    - *Description*: Utility classes or helper methods that are used across the infrastructure layer may be placed here.
    - *Usage*: Helpers simplify common tasks and improve code reuse within the infrastructure components.

**11. Interfaces**
    - *Description*: Interfaces representing contracts and abstractions for infrastructure services can be found in this folder.
    - *Usage*: Interfaces facilitate loose coupling and dependency injection for infrastructure components.

The folder structure within the Infrastructure Project manages infrastructure concerns separately from the application and domain layers, ensuring clear separation of responsibilities. This organization promotes maintainability, extensibility, and the encapsulation of infrastructure-specific logic.

## Presentation Project Folder Structure

The Presentation Project serves as the user interface layer of your application, responsible for handling HTTP requests and responses. It is typically organized into various folders, each serving a specific purpose:

**1. Controllers**
   - *Description*: The "Controllers" folder contains controller classes responsible for handling incoming HTTP requests and defining API endpoints.
   - *Usage*: Controllers receive and process HTTP requests, invoking the appropriate application layer commands or queries to fulfill client requests.

**2. Models**
   - *Description*: Models, often represented as DTOs (Data Transfer Objects), are defined in this folder to structure data sent to and received from clients.
   - *Usage*: DTOs define the shape of data exchanged between the presentation layer and the application layer, ensuring a clear contract.

**3. ViewModels** (Optional)
   - *Description*: If your application uses ViewModels for specific presentation logic, this folder may contain ViewModel classes.
   - *Usage*: ViewModels are used to shape data for rendering views in server-rendered web applications or for specific client-side requirements.

**4. Filters** (Optional)
   - *Description*: Custom action filters and result filters can be placed in this folder.
   - *Usage*: Filters are used to add cross-cutting concerns such as authentication, authorization, or logging to controller actions.

**5. Middleware** (Optional)
   - *Description*: Custom middleware components can be organized in this folder.
   - *Usage*: Middleware can handle various tasks like request/response logging, exception handling, or custom HTTP request processing.

**6. Extensions** (Optional)
   - *Description*: Extensions methods or utility classes that extend ASP.NET Core functionality can be placed here.
   - *Usage*: Extensions can simplify common tasks or provide custom behavior in your application.

**7. Views** (Optional)
   - *Description*: In server-rendered web applications, views (Razor views in ASP.NET Core) can be organized in this folder.
   - *Usage*: Views define the user interface layout and presentation logic for server-rendered pages.

**8. Scripts** (Optional)
   - *Description*: Client-side scripts, such as JavaScript or TypeScript files, can be organized in this folder.
   - *Usage*: Scripts enhance the functionality of client-side components in web applications.

**10. Content** (Optional)
    - *Description*: Static content like images, fonts, or other assets can be organized in this folder.
    - *Usage*: Content files are served to clients for use in web pages or applications.

**11. Interfaces**
    - *Description*: Interfaces representing contracts and abstractions for presentation layer services can be found in this folder.
    - *Usage*: Interfaces facilitate loose coupling and dependency injection for presentation components.

**12. Exceptions**
    - *Description*: Custom presentation-specific exceptions can be placed in this folder.
    - *Usage*: These exceptions capture presentation layer error conditions and are used for error handling within the presentation layer.

The folder structure within the Presentation Project helps organize and separate responsibilities, making it easier to develop and maintain the user interface of your application while adhering to DDD and CQRS principles.

# Registering Classes (Dependency Injection)

In ASP.NET Core's dependency injection container (often referred to as the _IServiceCollection_), there are several methods available for registering services with different lifetimes. The most commonly used ones include:

The choice of which method to use depends on the intended lifetime of the service and your application's requirements:

- Use **AddTransient** when you want a **new instance** of the service to be created **every** time it's **requested**. This is suitable for stateless, lightweight services.

- Use **AddScoped** when you want a **single instance** of the service **per HTTP request or per unit of work**. In a web application, this ensures that the service instance is shared within the same request but not across different requests.

- Use **AddSingleton** when you want a single, shared instance of the service throughout the entire **application's lifetime**. This is suitable for stateless, thread-safe services that should be reused across requests.

- Use the factory methods (e.g., AddTransient<TService>(Func<IServiceProvider, TService>)) when you need more control over how instances are created, such as when a service requires additional setup or configuration during instantiation.

- Additionally, you can use the generic methods (AddTransient<T>, AddScoped<T>, AddSingleton<T>) when you have a specific service interface and implementation to register.

# Create a Migraion

1. On the PM Console set the Default-Project to Infrastructure. 
2. Use the following command to create a new migration *dotnet ef --startup-project ../[NAME_OF_STARTUP_PROJECT] migrations add [NAME_OF_THE_MIGRATION]*

**Using Visual Studio** 
1.	Open PM-Console
2. Select SUKiiServer as startup project
3. Select SUKiiServer.Infrastructure as Default Project in the dropdown of the PM-Console
4. Write *Add-Migration [Mirgration name]* to create an new migration
5. Write *Update-Datbase* to migrate to the new version
