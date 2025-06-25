using Microsoft.Extensions.Logging;
using ShipmentSystem.Infrastructure.BackgroundJobs.Interfaces;

namespace ShipmentSystem.Infrastructure.BackgroundJobs.Services;

public class ShipmentJobService : IShipmentJobService
{
    private readonly ILogger<ShipmentJobService> _logger;

    public ShipmentJobService(ILogger<ShipmentJobService> logger)
    {
        _logger = logger;
    }

    public async Task ProcessShipmentAsync(Guid shipmentId)
    {
        _logger.LogInformation("🔧 Background processing shipment with ID: {Id}", shipmentId);

        // Simulate work
        await Task.Delay(2000);

        _logger.LogInformation("✅ Finished processing shipment: {Id}", shipmentId);
    }
}
