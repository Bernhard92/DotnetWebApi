using Serilog;
using SUKiiServer;
using SUKiiServer.Application.DependencyInjection;
using SUKiiServer.Infrastructure.DependencyInjection;
using SUKiiServer.Presentation.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add project layers
builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddPresentation();

// Logging
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();
app.MapControllers();

// Adds request logging
//app.UseSerilogRequestLogging();

// to migrate on startup. TODO: find better migration strategy
PrepDB.PrepPopulation(app);


app.Run();
