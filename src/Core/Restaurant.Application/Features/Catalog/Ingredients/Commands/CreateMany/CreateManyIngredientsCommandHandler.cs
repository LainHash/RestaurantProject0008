using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Catalog;
using Restaurant.Contract.DTOs.Catalog.Ingredients;

namespace Restaurant.Application.Features.Catalog.Ingredients.Commands.CreateMany
{
    internal class CreateManyIngredientsCommandHandler
        : IRequestHandler<CreateManyIngredientsCommand, Result<IEnumerable<IngredientResponse>>>
    {
        private readonly IIngredientService _ingredientService;

        public CreateManyIngredientsCommandHandler(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public async Task<Result<IEnumerable<IngredientResponse>>> Handle(CreateManyIngredientsCommand request, CancellationToken cancellationToken)
        {
            var specification = new CreateManyIngredientsSpecification(request);
            var response = await _ingredientService.CreateManyAsync(specification, cancellationToken);
            return response;
        }
    }
}
