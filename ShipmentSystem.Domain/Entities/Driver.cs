using ShipmentSystem.Domain.Common;

namespace ShipmentSystem.Domain.Entities;

public class Driver : BaseEntity<Guid>
{
    public string Name { get; private set; }
    public string Phone { get; private set; }
    public string LicenseNumber { get; private set; }

    public ICollection<Shipment> Shipments { get; private set; } = new List<Shipment>();

    private Driver() { }

    public Driver(string name, string phone, string licenseNumber)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Phone = phone ?? throw new ArgumentNullException(nameof(phone));
        LicenseNumber = licenseNumber ?? throw new ArgumentNullException(nameof(licenseNumber));
    }

    public void UpdateDetails(string phone, string licenseNumber)
    {
        Phone = phone;
        LicenseNumber = licenseNumber;
    }
}
