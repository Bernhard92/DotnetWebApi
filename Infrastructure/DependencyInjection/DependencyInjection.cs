using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SUKiiServer.Application.Common.Interfaces;
using SUKiiServer.Domain.Common.Interfaces;
using SUKiiServer.Infrastructure.DataAccess;
using SUKiiServer.Infrastructure.Repositories;

namespace SUKiiServer.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var server = Environment.GetEnvironmentVariable("DBServer")??"localhost";
        var port = Environment.GetEnvironmentVariable("DBPort")??"1433";
        var user = Environment.GetEnvironmentVariable("DBUser")??"SA";
        var password = Environment.GetEnvironmentVariable("DBPassword")?? "S3Cr3tPa??Word?1";
        var database = Environment.GetEnvironmentVariable("Database")?? "sukii-debug";

        var connectionString =
            $"Server={server},{port};Initial Catalog={database};User ID={user};Password={password};TrustServerCertificate=True";
        
        Console.WriteLine("Connection string: " + connectionString);

        services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(connectionString,
                x => x.MigrationsAssembly("SUKiiServer.Infrastructure")));

        services.AddDatabaseDeveloperPageExceptionFilter();

        // Register classes here
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        services.AddScoped<ITodoRepository, TodoRepository>();

        return services;
    }
}