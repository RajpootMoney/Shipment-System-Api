using ShipmentSystem.Application.Interfaces.Common;
using ShipmentSystem.Domain.Entities;

namespace ShipmentSystem.Application.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken = default);
}
