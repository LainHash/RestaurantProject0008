using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Catalog;
using Restaurant.Contract.DTOs.Catalog.Ingredients;

namespace Restaurant.Application.Features.Inventory.IngredientStocks.Commands.Update
{
    internal class UpdateIngredientStockCommandHandler
        : IRequestHandler<UpdateIngredientStockCommand, Result<IngredientResponse>>
    {
        private readonly IIngredientService _ingredientService;

        public UpdateIngredientStockCommandHandler(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public async Task<Result<IngredientResponse>> Handle(UpdateIngredientStockCommand request, CancellationToken cancellationToken)
        {
            var specification = new UpdateIngredientStockSpecification(request);
            var response = await _ingredientService.UpdateStockAsync(specification, cancellationToken);
            return response;
        }
    }
}
