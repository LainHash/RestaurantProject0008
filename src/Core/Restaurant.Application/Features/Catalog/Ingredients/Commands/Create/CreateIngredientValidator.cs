using FluentValidation;
using Restaurant.Contract.DTOs.Catalog.Ingredients;
using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Application.Features.Catalog.Ingredients.Commands.Create
{
    internal class CreateIngredientValidator : AbstractValidator<CreateIngredientRequest>
    {
        public CreateIngredientValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category Id is required.");

            RuleFor(x => x.UnitPrice)
                .GreaterThanOrEqualTo(0).WithMessage("Unit price must be greater than or equal to 0.");

            RuleFor(x => x.Unit)
                .NotEmpty().WithMessage("Unit is required.");

            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Stock quantity must be greater than or equal to 0.");
        }
    }
}
