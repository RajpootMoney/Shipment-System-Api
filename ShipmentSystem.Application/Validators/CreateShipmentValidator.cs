using FluentValidation;
using ShipmentSystem.Application.DTOs;

namespace ShipmentSystem.Application.Validators;

public class CreateShipmentDtoValidator : AbstractValidator<CreateShipmentDto>
{
    public CreateShipmentDtoValidator()
    {
        RuleFor(x => x.Origin).NotNull();
        RuleFor(x => x.Destination).NotNull();
        RuleFor(x => x.ShippedDate).GreaterThan(DateTime.MinValue);
    }
}
