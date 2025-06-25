namespace ShipmentSystem.Application.Constants;

public static class ErrorMessages
{
    public static class Shipment
    {
        public const string OriginAndDestinationSame = "Origin and Destination cannot be the same.";
        public const string NotFound = "Shipment not found.";
    }

    public static class Address
    {
        public const string InvalidZipCode = "Invalid Zip Code.";
    }
}
