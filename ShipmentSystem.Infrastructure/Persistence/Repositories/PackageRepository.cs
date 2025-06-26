using ShipmentSystem.Application.Interfaces;
using ShipmentSystem.Domain.Entities;
using ShipmentSystem.Infrastructure.Persistence.Common;

namespace ShipmentSystem.Infrastructure.Persistence.Repositories;

public class PackageRepository : Repository<Package>, IPackageRepository
{
    public PackageRepository(ShipmentDbContext context)
        : base(context) { }
}
