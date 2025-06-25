using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShipmentSystem.Application.Interfaces;
using ShipmentSystem.Infrastructure.BackgroundJobs.Interfaces;
using ShipmentSystem.Infrastructure.BackgroundJobs.Services;
using ShipmentSystem.Infrastructure.Persistence;
using ShipmentSystem.Infrastructure.Persistence.Repositories;

namespace ShipmentSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ShipmentDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IShipmentRepository, ShipmentRepository>();
        services.AddScoped<IShipmentJobService, ShipmentJobService>();
        services.AddHangfire(config =>
        {
            config.UseMemoryStorage(); // For dev, or use .UseSqlServerStorage(...)
        });

        services.AddHangfireServer();

        return services;
    }
}
