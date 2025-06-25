using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShipmentSystem.Application.Interfaces;
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
        /*        services.AddDbContext<ShipmentDbContext>(options =>
                    options.UseInMemoryDatabase("ShipmentDb")
                );*/
        // or UseSqlServer()

        services.AddScoped<IShipmentRepository, ShipmentRepository>();

        return services;
    }
}
