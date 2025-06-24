namespace ShipmentSystem.Application.Interfaces;

public interface IObjectMapper
{
    TDestination Map<TDestination>(object source);
    TDestination Map<TSource, TDestination>(TSource source);
}
