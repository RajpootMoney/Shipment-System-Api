using ShipmentSystem.Domain.Common;
using ShipmentSystem.Domain.Enums;

namespace ShipmentSystem.Domain.Entities;

public abstract class User : BaseEntity<Guid>
{
    public string Name { get; protected set; }
    public string Email { get; protected set; }
    public string Phone { get; protected set; }
    public string PasswordHash { get; protected set; }

    public UserRole Role { get; protected set; }

    protected User() { }

    protected User(string name, string email, string phone, string passwordHash, UserRole role)
    {
        Name = name;
        Email = email;
        Phone = phone;
        PasswordHash = passwordHash;
        Role = role;
    }
}
