using Hangfire;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ShipmentSystem.API.Middleware;
using ShipmentSystem.Application;
using ShipmentSystem.Infrastructure;
using ShipmentSystem.Infrastructure.Persistence;
using ShipmentSystem.Infrastructure.Persistence.SeedData;

var builder = WebApplication.CreateBuilder(args);

// Serilog Configuration
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructure(builder.Configuration);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // For Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ShipmentDbContext>();
    context.Database.Migrate();

    await SeedData.SeedAsync(context);
}

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHangfireDashboard("/hangfire");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
