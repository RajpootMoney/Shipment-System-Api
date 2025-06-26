using ShipmentSystem.Domain.Common;

namespace ShipmentSystem.Domain.Entities
{
    public class Vehicle : BaseEntity<Guid>
    {
        public string TruckNumber { get; private set; }
        public string TruckType { get; private set; }
        public decimal Capacity { get; private set; }

        public ICollection<Shipment> Shipments { get; private set; } = new List<Shipment>();

        private Vehicle() { }

        public Vehicle(string truckNumber, string truckType, decimal capacity)
        {
            TruckNumber = truckNumber ?? throw new ArgumentNullException(nameof(truckNumber));
            TruckType = truckType ?? throw new ArgumentNullException(nameof(truckType));
            Capacity = capacity;
        }

        public void UpdateDetails(string truckType, decimal capacity)
        {
            TruckType = truckType;
            Capacity = capacity;
        }
    }
}
