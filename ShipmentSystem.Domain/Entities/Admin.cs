using ShipmentSystem.Domain.Enums;

namespace ShipmentSystem.Domain.Entities;

public class Admin : User
{
    private Admin() { }

    public Admin(string name, string email, string phone, string passwordHash)
        : base(name, email, phone, passwordHash, UserRole.Admin) { }
}
