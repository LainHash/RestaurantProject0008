using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.Recipes;

namespace Restaurant.Application.Features.Production.Recipes.Commands.Create
{
    public record CreateRecipeCommand(CreateRecipeRequest Body)
        : IRequest<Result<RecipeResponse>>
    {
    }
}
