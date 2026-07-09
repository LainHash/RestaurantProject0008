using MediatR;
using Restaurant.Application.Models.Abstraction;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.Recipes;

namespace Restaurant.Application.Features.Production.Recipes.Queries.GetAll
{
    public record GetAllRecipesQuery : PageQuery, IRequest<PageResult<IEnumerable<RecipeResponse>>>
    {
    }
}

