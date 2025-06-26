namespace ShipmentSystem.Application.DTOs.Shipments;

public class CreateShipmentDto
{
    public Guid CustomerId { get; set; }
    public Guid DriverId { get; set; }
    public Guid VehicleId { get; set; }

    public AddressDto Origin { get; set; }
    public AddressDto Destination { get; set; }

    public DateTime ShippedDate { get; set; }
    public DateTime? EstimatedDeliveryDate { get; set; }

    public string Status { get; set; }

    public List<PackageDto> Packages { get; set; }
}
