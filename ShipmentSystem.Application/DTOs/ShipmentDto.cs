namespace ShipmentSystem.Application.DTOs;

public class ShipmentDto
{
    public Guid Id { get; set; }
    public AddressDto Origin { get; set; } = default!;
    public AddressDto Destination { get; set; } = default!;
    public DateTime ShippedDate { get; set; }
    public DateTime CreatedAt { get; set; }
}
