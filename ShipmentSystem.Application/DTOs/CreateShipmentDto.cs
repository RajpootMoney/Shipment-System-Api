namespace ShipmentSystem.Application.DTOs;

public class CreateShipmentDto
{
    public required AddressDto Origin { get; set; }
    public required AddressDto Destination { get; set; }
    public DateTime ShippedDate { get; set; }
}
