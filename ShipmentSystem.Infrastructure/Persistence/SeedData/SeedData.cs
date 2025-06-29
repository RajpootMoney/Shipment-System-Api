namespace ShipmentSystem.Infrastructure.Persistence.SeedData;

public static class SeedData
{
    public static async Task SeedAsync(ShipmentDbContext context)
    {
        await UserSeeder.SeedAsync(context);
        await VehicleSeeder.SeedAsync(context);
    }
}
