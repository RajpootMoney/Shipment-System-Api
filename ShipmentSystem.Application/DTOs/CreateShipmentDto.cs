namespace ShipmentSystem.Application.DTOs;

public class CreateShipmentDto
{
    public required AddressDto Origin { get; set; }
    public required AddressDto Destination { get; set; }
    public DateTime ShippedDate { get; set; }
}

public class AddressDto
{
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string ZipCode { get; set; }
}
