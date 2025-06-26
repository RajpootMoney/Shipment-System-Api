using FluentValidation;
using ShipmentSystem.Application.DTOs;
using ShipmentSystem.Application.Shipments.Commands;

namespace ShipmentSystem.Application.Validators;

public class CreateShipmentCommandValidator : AbstractValidator<CreateShipmentCommand>
{
    public CreateShipmentCommandValidator()
    {
        RuleFor(x => x.Dto.Origin.PostalCode)
            .NotEmpty()
            .WithMessage("Origin ZIP code is required.");
        RuleFor(x => x.Dto.ShippedDate)
            .GreaterThanOrEqualTo(DateTime.Today)
            .WithMessage("Shipment date cannot be in the past.");
    }
}
