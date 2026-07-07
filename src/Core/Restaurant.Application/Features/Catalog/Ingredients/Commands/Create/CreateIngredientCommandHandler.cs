using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Catalog;
using Restaurant.Contract.DTOs.Catalog.Ingredients;

namespace Restaurant.Application.Features.Catalog.Ingredients.Commands.Create
{
    internal class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand, Result<IngredientResponse>>
    {
        private readonly IIngredientService _ingredientService;

        public CreateIngredientCommandHandler(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public async Task<Result<IngredientResponse>> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
        {
            var response = await _ingredientService.CreateAsync(request.Body, cancellationToken);
            return response;
        }
    }
}
