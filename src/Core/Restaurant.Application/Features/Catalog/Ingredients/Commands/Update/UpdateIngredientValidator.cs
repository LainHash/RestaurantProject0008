using FluentValidation;
using Restaurant.Contract.DTOs.Catalog.Ingredients;

namespace Restaurant.Application.Features.Catalog.Ingredients.Commands.Update
{
    internal class UpdateIngredientValidator : AbstractValidator<UpdateIngredientRequest>
    {
        public UpdateIngredientValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category Id is required.");
        }
    }
}
