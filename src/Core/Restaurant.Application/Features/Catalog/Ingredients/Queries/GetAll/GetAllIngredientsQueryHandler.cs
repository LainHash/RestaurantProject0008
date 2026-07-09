using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Catalog;
using Restaurant.Contract.DTOs.Catalog.Ingredients;

namespace Restaurant.Application.Features.Catalog.Ingredients.Queries.GetAll
{
    internal class GetAllIngredientsQueryHandler : IRequestHandler<GetAllIngredientsQuery, PageResult<IEnumerable<IngredientResponse>>>
    {
        private readonly IIngredientService _ingredientService;
        public GetAllIngredientsQueryHandler(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public async Task<PageResult<IEnumerable<IngredientResponse>>> Handle(GetAllIngredientsQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllIngredientsSpecification(request);
            var response = await _ingredientService.GetAllAsync(specification, cancellationToken);
            return response;
        }
    }
}

