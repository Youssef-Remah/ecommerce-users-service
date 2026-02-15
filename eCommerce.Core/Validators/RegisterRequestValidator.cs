using eCommerce.Core.DTOs;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(prop => prop.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address format");

        RuleFor(prop => prop.Password)
            .NotEmpty().WithMessage("Password is required");

        RuleFor(prop => prop.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(1, 50).WithMessage("Name should be between 1 and 50 characters long");

        RuleFor(prop => prop.Gender)
            .IsInEnum().WithMessage("Invalid gender option");
    }
}
