using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SUKiiServer.Application.Common.Interfaces.Services;
using SUKiiServer.Application.Services;

namespace SUKiiServer.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(assembly));

        services.AddValidatorsFromAssembly(assembly);


        // Register your own services or classes here
        services.AddScoped<ITodoService, TodoService>();

        return services;
    }
}   