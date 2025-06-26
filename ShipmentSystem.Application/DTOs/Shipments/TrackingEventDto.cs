namespace ShipmentSystem.Application.DTOs.Shipments;

public class TrackingEventDto
{
    public Guid Id { get; set; }
    public string Event { get; set; }
    public DateTime Timestamp { get; set; }
    public string Location { get; set; }
}
