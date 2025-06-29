namespace ShipmentSystem.Domain.ValueObjects;

public static class VehicleTypes
{
    public static readonly VehicleType Small = new VehicleType("Small");
    public static readonly VehicleType Medium = new VehicleType("Medium");
    public static readonly VehicleType Large = new VehicleType("Large");

    public static IEnumerable<VehicleType> List() => new[] { Small, Medium, Large };

    public static VehicleType From(string value) =>
        List().FirstOrDefault(t => t.Value.Equals(value, StringComparison.OrdinalIgnoreCase))
        ?? throw new ArgumentException($"Invalid vehicle type: {value}");
}
