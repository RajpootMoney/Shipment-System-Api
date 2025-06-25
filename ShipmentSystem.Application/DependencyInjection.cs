using Microsoft.Extensions.DependencyInjection;
using ShipmentSystem.Application.Interfaces;
using ShipmentSystem.Application.Mapping;
using ShipmentSystem.Application.Services;

namespace ShipmentSystem.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register AutoMapper
        services.AddAutoMapper(typeof(MappingProfile));

        // Register abstraction over AutoMapper
        services.AddScoped<IObjectMapper, AutoMapperAdapter>();

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly)
        );

        return services;
    }
}
