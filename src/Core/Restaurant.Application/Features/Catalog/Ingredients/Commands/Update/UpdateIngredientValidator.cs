using FluentValidation;

namespace Restaurant.Application.Features.Catalog.Ingredients.Commands.Update
{
    internal class UpdateIngredientValidator : AbstractValidator<UpdateIngredientCommand>
    {
        public UpdateIngredientValidator()
        {
            RuleFor(x => x.Body.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");

            RuleFor(x => x.Body.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.Body.CategoryId)
                .NotEmpty().WithMessage("Category Id is required.");
        }
    }
}
