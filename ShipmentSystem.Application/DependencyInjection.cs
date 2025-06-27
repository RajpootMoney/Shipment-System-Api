using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShipmentSystem.Application.Behaviors;
using ShipmentSystem.Application.Interfaces;
using ShipmentSystem.Application.Mapping;
using ShipmentSystem.Application.Services;

namespace ShipmentSystem.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddScoped<IObjectMapper, AutoMapperAdapter>();
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly)
        );

        return services;
    }
}
