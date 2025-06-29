using ShipmentSystem.Domain.Common;

namespace ShipmentSystem.Domain.ValueObjects;

public class VehicleType : ValueObject
{
    public string Value { get; private set; }

    private VehicleType() { }

    public VehicleType(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Vehicle type cannot be null or empty.", nameof(value));

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
