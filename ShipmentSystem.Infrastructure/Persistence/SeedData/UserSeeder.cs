using System.Security.Cryptography;
using System.Text;
using ShipmentSystem.Domain.Entities;

namespace ShipmentSystem.Infrastructure.Persistence.SeedData;

public static class UserSeeder
{
    public static async Task SeedAsync(ShipmentDbContext context)
    {
        if (!context.Set<User>().Any())
        {
            var password = "Admin@123#";

            var users = new List<User>
            {
                new Admin("System Admin", "admin@system.com", "9999999999", HashPassword(password)),
                new Customer(
                    "John Customer",
                    "customer@system.com",
                    "8888888888",
                    HashPassword(password),
                    "Acme Corp"
                ),
                new Driver(
                    "David Driver",
                    "driver@system.com",
                    "7777777777",
                    HashPassword(password),
                    "DL-12345"
                )
            };

            context.AddRange(users);
            await context.SaveChangesAsync();
        }
    }

    private static string HashPassword(string password)
    {
        using var sha = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}
