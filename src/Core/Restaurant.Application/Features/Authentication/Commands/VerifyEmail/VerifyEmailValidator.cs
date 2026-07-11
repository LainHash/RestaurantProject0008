using FluentValidation;

namespace Restaurant.Application.Features.Authentication.Commands.VerifyEmail
{
    internal class VerifyEmailValidator : AbstractValidator<VerifyEmailCommand>
    {
        public VerifyEmailValidator()
        {


            RuleFor(x => x.Body.Code)
                .NotEmpty().WithMessage("Verification Code is required.")
                .Length(6).WithMessage("Verification Code must be exactly 6 digits.");
        }
    }
}
