using ShipmentSystem.Domain.Common;
using ShipmentSystem.Domain.ValueObjects;

namespace ShipmentSystem.Domain.Entities;

public class Shipment : BaseEntity<Guid>
{
    public Address Origin { get; private set; }
    public Address Destination { get; private set; }
    public DateTime ShippedDate { get; private set; }

    // EF Core needs this
    private Shipment() { }

    // Domain constructor
    public Shipment(Address origin, Address destination, DateTime shippedDate)
    {
        Origin = origin;
        Destination = destination;
        ShippedDate = shippedDate;
    }
}
