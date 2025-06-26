namespace ShipmentSystem.Application.DTOs.Shipments;

public class PackageDto
{
    public Guid Id { get; set; }
    public decimal Weight { get; set; }
    public string Dimensions { get; set; }
    public string ContentDescription { get; set; }
}
