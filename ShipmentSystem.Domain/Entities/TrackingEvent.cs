using ShipmentSystem.Domain.Common;

namespace ShipmentSystem.Domain.Entities;

public class TrackingEvent : BaseEntity<Guid>
{
    public Guid ShipmentId { get; private set; }

    public string Event { get; private set; }
    public DateTime Timestamp { get; private set; }
    public string Location { get; private set; }

    public Shipment Shipment { get; private set; }

    private TrackingEvent() { }

    public TrackingEvent(Guid shipmentId, string @event, DateTime timestamp, string location)
    {
        ShipmentId = shipmentId;
        Event = @event ?? throw new ArgumentNullException(nameof(@event));
        Timestamp = timestamp;
        Location = location ?? throw new ArgumentNullException(nameof(location));
    }

    // Optional domain method to update event
    public void UpdateEvent(string @event, string location, DateTime timestamp)
    {
        Event = @event;
        Location = location;
        Timestamp = timestamp;
    }
}
