using MediatR;
using Restaurant.Application.Models.Abstraction;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Catalog.Ingredients;

namespace Restaurant.Application.Features.Catalog.Ingredients.Queries.GetAll
{
    public record GetAllIngredientsQuery(string? CategoryId) : PageQuery, IRequest<PageResult<IEnumerable<IngredientResponse>>>
    {
    }
}
