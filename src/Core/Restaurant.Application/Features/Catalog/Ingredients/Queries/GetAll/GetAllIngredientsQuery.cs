using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Catalog.Ingredients;

namespace Restaurant.Application.Features.Catalog.Ingredients.Queries.GetAll
{
    public record GetAllIngredientsQuery : IRequest<Result<IEnumerable<IngredientResponse>>>
    {
    }
}
