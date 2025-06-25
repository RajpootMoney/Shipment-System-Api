namespace ShipmentSystem.Infrastructure.BackgroundJobs.Interfaces;

public interface IShipmentJobService
{
    Task ProcessShipmentAsync(Guid shipmentId);
}
