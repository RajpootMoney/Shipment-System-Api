using ShipmentSystem.Domain.Common;

namespace ShipmentSystem.Domain.Entities;

public class Package : BaseEntity<Guid>
{
    public Guid ShipmentId { get; private set; }
    public decimal Weight { get; private set; }
    public string Dimensions { get; private set; }
    public string ContentDescription { get; private set; }

    public Shipment Shipment { get; private set; }

    private Package() { }

    public Package(Guid shipmentId, decimal weight, string dimensions, string contentDescription)
    {
        ShipmentId = shipmentId;
        Weight = weight;
        Dimensions = dimensions ?? throw new ArgumentNullException(nameof(dimensions));
        ContentDescription =
            contentDescription ?? throw new ArgumentNullException(nameof(contentDescription));
    }

    public void UpdatePackageDetails(decimal weight, string dimensions, string contentDescription)
    {
        Weight = weight;
        Dimensions = dimensions;
        ContentDescription = contentDescription;
    }
}
