using AutoMapper;
using ShipmentSystem.Application.DTOs;
using ShipmentSystem.Domain.ValueObjects;

namespace ShipmentSystem.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddressDto, Address>();
    }
}
