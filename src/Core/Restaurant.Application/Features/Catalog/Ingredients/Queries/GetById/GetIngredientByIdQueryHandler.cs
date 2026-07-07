using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Catalog;
using Restaurant.Contract.DTOs.Catalog.Ingredients;

namespace Restaurant.Application.Features.Catalog.Ingredients.Queries.GetById
{
    internal class GetIngredientByIdQueryHandler : IRequestHandler<GetIngredientByIdQuery, Result<IngredientResponse>>
    {
        private readonly IIngredientService _ingredientService;
        public GetIngredientByIdQueryHandler(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public async Task<Result<IngredientResponse>> Handle(GetIngredientByIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetIngredientByIdSpecification(request);
            var response = await _ingredientService.GetByIdAsync(specification, cancellationToken);
            return response;
        }
    }
}
