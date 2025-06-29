using ShipmentSystem.Domain.Entities;
using ShipmentSystem.Domain.ValueObjects;

namespace ShipmentSystem.Infrastructure.Persistence.SeedData;

public static class VehicleSeeder
{
    public static async Task SeedAsync(ShipmentDbContext context)
    {
        if (!context.Vehicles.Any())
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle("HR55-1234", VehicleTypes.Medium, 10000),
                new Vehicle("DL01-5678", VehicleTypes.Small, 8000),
                new Vehicle("PB10-4321", VehicleTypes.Large, 12000),
                new Vehicle("RJ14-1111", VehicleTypes.Large, 15000),
                new Vehicle("MH12-9999", VehicleTypes.Medium, 9000)
            };

            context.Vehicles.AddRange(vehicles);
            await context.SaveChangesAsync();
        }
    }
}
