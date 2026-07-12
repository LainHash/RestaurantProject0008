using FluentValidation;

namespace Restaurant.Application.Features.Personnel.Positions.Commands.Create
{
    internal class CreatePositionValidator
        : AbstractValidator<CreatePositionCommand>
    {
        public CreatePositionValidator()
        {
            RuleFor(x => x.Body.Name)
                .NotEmpty().WithMessage("Position name is required.")
                .MaximumLength(100).WithMessage("Position name must not exceed 100 characters.");

            RuleFor(x => x.Body.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
        }
    }
}
