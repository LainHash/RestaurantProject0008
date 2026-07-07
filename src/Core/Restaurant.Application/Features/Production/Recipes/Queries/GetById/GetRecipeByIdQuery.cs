using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.Recipes;

namespace Restaurant.Application.Features.Production.Recipes.Queries.GetById
{
    public record GetRecipeByIdQuery(Guid Id) : IRequest<Result<RecipeResponse>>
    {
    }
}
