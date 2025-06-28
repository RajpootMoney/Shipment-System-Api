using AutoMapper;
using ShipmentSystem.Application.Auth.Commands;
using ShipmentSystem.Application.Auth.Models;
using ShipmentSystem.Application.DTOs.Shipments;
using ShipmentSystem.Domain.Entities;
using ShipmentSystem.Domain.ValueObjects;

namespace ShipmentSystem.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddressDto, Address>();
        CreateMap<User, JwtUserPayload>();

        // Mapping Register Commands to Entities
        CreateMap<RegisterCustomerCommand, Customer>()
            .ConstructUsing(cmd => new Customer(
                cmd.Name,
                cmd.Email,
                cmd.Phone,
                BCrypt.Net.BCrypt.HashPassword(cmd.Password),
                cmd.CompanyName
            ));

        CreateMap<RegisterDriverCommand, Driver>()
            .ConstructUsing(cmd => new Driver(
                cmd.Name,
                cmd.Email,
                cmd.Phone,
                BCrypt.Net.BCrypt.HashPassword(cmd.Password),
                cmd.LicenseNumber
            ));
    }
}
