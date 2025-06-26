namespace ShipmentSystem.Application.DTOs.Shipments;

public class ShipmentDto
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; }

    public Guid DriverId { get; set; }
    public string DriverName { get; set; }

    public Guid VehicleId { get; set; }
    public string VehicleNumber { get; set; }

    public AddressDto Origin { get; set; }
    public AddressDto Destination { get; set; }

    public DateTime ShippedDate { get; set; }
    public DateTime? EstimatedDeliveryDate { get; set; }

    public string Status { get; set; }

    public List<TrackingEventDto> TrackingEvents { get; set; }
    public List<PackageDto> Packages { get; set; }
}
