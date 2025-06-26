using ShipmentSystem.Domain.Common;
using ShipmentSystem.Domain.Enums;

namespace ShipmentSystem.Domain.Entities;

public class Customer : BaseEntity<Guid>
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public CustomerType Type { get; private set; }
    public ICollection<Shipment> Shipments { get; private set; } = new List<Shipment>();

    private Customer() { }

    public Customer(string name, string email, string phone, CustomerType type)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Phone = phone ?? throw new ArgumentNullException(nameof(phone));
        Type = type;
    }

    public void UpdateContactInfo(string email, string phone)
    {
        Email = email;
        Phone = phone;
    }

    public void ChangeType(CustomerType type)
    {
        Type = type;
    }
}
