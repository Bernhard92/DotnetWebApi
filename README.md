# Registering Classes

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

**Or in Visual Studio** 
1.	Open PM-Console
2. Select SUKiiServer as startup project
3. Select SUKiiServer.Infrastructure as Default Project in the dropdown of the PM-Console
4. Write *Add-Migration [Mirgration name]* to create an new migration
5. Write *Update-Datbase* to migrate to the new version
