using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShipmentSystem.Application.Interfaces;
using ShipmentSystem.Application.Interfaces.Auth;
using ShipmentSystem.Infrastructure.BackgroundJobs.Interfaces;
using ShipmentSystem.Infrastructure.BackgroundJobs.Services;
using ShipmentSystem.Infrastructure.Persistence;
using ShipmentSystem.Infrastructure.Persistence.Repositories;
using ShipmentSystem.Infrastructure.Services.Auth;

namespace ShipmentSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<ShipmentDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"))
        );
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IShipmentRepository, ShipmentRepository>();
        services.AddScoped<IShipmentJobService, ShipmentJobService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddHangfire(config =>
        {
            config.UseMemoryStorage(); // For dev, or use .UseSqlServerStorage(...)
        });

        services.AddHangfireServer();

        return services;
    }
}
