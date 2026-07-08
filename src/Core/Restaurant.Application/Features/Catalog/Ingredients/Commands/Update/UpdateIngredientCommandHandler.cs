using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Catalog;
using Restaurant.Contract.DTOs.Catalog.Ingredients;

namespace Restaurant.Application.Features.Catalog.Ingredients.Commands.Update
{
    internal class UpdateIngredientCommandHandler : IRequestHandler<UpdateIngredientCommand, Result<IngredientResponse>>
    {
        private readonly IIngredientService _ingredientService;

        public UpdateIngredientCommandHandler(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public async Task<Result<IngredientResponse>> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
        {
            var response = await _ingredientService.UpdateAsync(request.Id, request.Body, cancellationToken);
            return response;
        }
    }
}
