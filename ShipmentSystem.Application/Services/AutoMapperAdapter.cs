using AutoMapper;
using ShipmentSystem.Application.Interfaces;

namespace ShipmentSystem.Application.Services;

public class AutoMapperAdapter : IObjectMapper
{
    private readonly IMapper _mapper;

    public AutoMapperAdapter(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TDestination Map<TDestination>(object source) => _mapper.Map<TDestination>(source);

    public TDestination Map<TSource, TDestination>(TSource source) =>
        _mapper.Map<TSource, TDestination>(source);
}
