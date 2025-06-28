using Microsoft.EntityFrameworkCore;
using ShipmentSystem.Application.Interfaces;
using ShipmentSystem.Domain.Entities;
using ShipmentSystem.Infrastructure.Persistence.Common;

namespace ShipmentSystem.Infrastructure.Persistence.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly ShipmentDbContext _context;

    public UserRepository(ShipmentDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<User?> FindByEmailAsync(
        string email,
        CancellationToken cancellationToken = default
    )
    {
        return await _context
            .Users.Where(u => u.Email == email)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
