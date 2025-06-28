using FluentValidation;
using ShipmentSystem.Application.Auth.Commands;
using ShipmentSystem.Domain.Enums;

namespace ShipmentSystem.Application.Validators;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Phone).NotEmpty();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
    }
}
