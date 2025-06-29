using ShipmentSystem.Domain.Common;
using ShipmentSystem.Domain.ValueObjects;

namespace ShipmentSystem.Domain.Entities;

public class Vehicle : BaseEntity<Guid>
{
    public string VehicleNumber { get; private set; }
    public VehicleType VehicleType { get; private set; }
    public decimal Capacity { get; private set; }

    public ICollection<Shipment> Shipments { get; private set; } = new List<Shipment>();

    // EF Core needs a parameterless constructor
    private Vehicle() { }

    public Vehicle(string vehicleNumber, VehicleType vehicleType, decimal capacity)
    {
        if (string.IsNullOrWhiteSpace(vehicleNumber))
            throw new ArgumentException(
                "Vehicle number cannot be null or empty.",
                nameof(vehicleNumber)
            );
        if (capacity <= 0)
            throw new ArgumentException("Capacity must be greater than 0.", nameof(capacity));

        VehicleNumber = vehicleNumber;
        VehicleType = vehicleType ?? throw new ArgumentNullException(nameof(vehicleType));
        Capacity = capacity;
    }

    public void UpdateDetails(VehicleType vehicleType, decimal capacity)
    {
        if (vehicleType == null)
            throw new ArgumentNullException(nameof(vehicleType));
        if (capacity <= 0)
            throw new ArgumentException("Capacity must be greater than 0.", nameof(capacity));

        VehicleType = vehicleType;
        Capacity = capacity;
    }

    public void UpdateVehicleNumber(string vehicleNumber)
    {
        if (string.IsNullOrWhiteSpace(vehicleNumber))
            throw new ArgumentException(
                "Vehicle number cannot be null or empty.",
                nameof(vehicleNumber)
            );

        VehicleNumber = vehicleNumber;
    }
}
