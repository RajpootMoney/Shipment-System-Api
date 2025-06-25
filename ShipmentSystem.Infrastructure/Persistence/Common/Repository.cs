using Microsoft.EntityFrameworkCore;
using ShipmentSystem.Application.Interfaces.Common;

namespace ShipmentSystem.Infrastructure.Persistence.Common;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    protected readonly ShipmentDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public Repository(ShipmentDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default
    ) => await _dbSet.FindAsync(new object[] { id }, cancellationToken);

    public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _dbSet.ToListAsync(cancellationToken);

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default) =>
        await _dbSet.AddAsync(entity, cancellationToken);

    public void Update(TEntity entity) => _dbSet.Update(entity);

    public void Remove(TEntity entity) => _dbSet.Remove(entity);
}
