using ShipmentSystem.Domain.Enums;

namespace ShipmentSystem.Domain.Entities;

public class Driver : User
{
    public string LicenseNumber { get; private set; }
    public ICollection<Shipment> Shipments { get; private set; } = new List<Shipment>();

    private Driver() { }

    public Driver(
        string name,
        string email,
        string phone,
        string passwordHash,
        string licenseNumber
    )
        : base(name, email, phone, passwordHash, UserRole.Driver)
    {
        LicenseNumber = licenseNumber;
    }
}
