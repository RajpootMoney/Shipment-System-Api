using ShipmentSystem.Domain.Enums;

namespace ShipmentSystem.Domain.Entities;

public class Customer : User
{
    public string CompanyName { get; private set; }
    public CustomerType Type { get; private set; }
    public ICollection<Shipment> Shipments { get; private set; } = new List<Shipment>();

    private Customer() { }

    public Customer(
        string name,
        string email,
        string phone,
        string passwordHash,
        string companyName
    )
        : base(name, email, phone, passwordHash, UserRole.Customer)
    {
        CompanyName = companyName;
    }
}
