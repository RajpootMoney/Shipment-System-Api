using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
        services.AddDatabase(configuration);
        services.AddAuth(configuration);
        services.AddHangfireSetup();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IShipmentRepository, ShipmentRepository>();
        services.AddScoped<IShipmentJobService, ShipmentJobService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IAuth0Service, Auth0Service>();
        services.AddHttpContextAccessor();
        services.AddHttpClient<IAuth0Service, Auth0Service>();

        return services;
    }

    private static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration config
    )
    {
        services.AddDbContext<ShipmentDbContext>(options =>
            options.UseNpgsql(config.GetConnectionString("DefaultConnection"))
        );
        return services;
    }

    private static IServiceCollection AddAuth(
        this IServiceCollection services,
        IConfiguration config
    )
    {
        var section = config.GetSection("Auth0");
        services.Configure<Auth0Settings>(section);
        var auth0Settings = section.Get<Auth0Settings>();

        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = $"https://{auth0Settings.Domain}/";
                options.Audience = auth0Settings.Audience;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name",
                    RoleClaimType = "https://schemas.myapi.com/roles"
                };
            });

        services.AddAuthorization();
        return services;
    }

    private static IServiceCollection AddHangfireSetup(this IServiceCollection services)
    {
        services.AddHangfire(config => config.UseMemoryStorage());
        services.AddHangfireServer();
        return services;
    }
}
