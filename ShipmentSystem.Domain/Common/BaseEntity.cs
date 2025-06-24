namespace ShipmentSystem.Domain.Common;

public abstract class BaseEntity<T>
{
    public T Id { get; protected set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
