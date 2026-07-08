using FluentValidation;

namespace Restaurant.Application.Features.Inventory.IngredientStocks.Commands.Update
{
    internal class UpdateIngredientStockValidator : AbstractValidator<UpdateIngredientStockCommand>
    {
        public UpdateIngredientStockValidator()
        {
            RuleFor(x => x.Body.UnitPrice)
                .GreaterThanOrEqualTo(0).WithMessage("Unit price must be greater than or equal to 0.");

            RuleFor(x => x.Body.Unit)
                .NotEmpty().WithMessage("Unit is required.");

            RuleFor(x => x.Body.StockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Stock quantity must be greater than or equal to 0.");
        }
    }
}
