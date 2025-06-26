using ShipmentSystem.Domain.Common;
using ShipmentSystem.Domain.Enums;
using ShipmentSystem.Domain.ValueObjects;

namespace ShipmentSystem.Domain.Entities;

public class Shipment : BaseEntity<Guid>
{
    public Guid CustomerId { get; private set; }
    public Guid DriverId { get; private set; }
    public Guid VehicleId { get; private set; }

    public Address Origin { get; private set; }
    public Address Destination { get; private set; }

    public DateTime ShippedDate { get; private set; }
    public DateTime? EstimatedDeliveryDate { get; private set; }

    public ShipmentStatus Status { get; private set; }

    public ICollection<TrackingEvent> TrackingEvents { get; private set; } =
        new List<TrackingEvent>();
    public ICollection<Package> Packages { get; private set; } = new List<Package>();
    public Customer Customer { get; private set; }
    public Driver Driver { get; private set; }
    public Vehicle Vehicle { get; private set; }

    private Shipment() { }

    public Shipment(
        Guid customerId,
        Guid driverId,
        Guid vehicleId,
        Address origin,
        Address destination,
        DateTime shippedDate,
        ShipmentStatus status,
        DateTime? estimatedDeliveryDate = null
    )
    {
        CustomerId = customerId;
        DriverId = driverId;
        VehicleId = vehicleId;
        Origin = origin ?? throw new ArgumentNullException(nameof(origin));
        Destination = destination ?? throw new ArgumentNullException(nameof(destination));
        ShippedDate = shippedDate;
        Status = status;
        EstimatedDeliveryDate = estimatedDeliveryDate;
    }

    public void UpdateStatus(ShipmentStatus newStatus)
    {
        Status = newStatus;
    }

    public void SetEstimatedDeliveryDate(DateTime estimatedDate)
    {
        EstimatedDeliveryDate = estimatedDate;
    }
}
