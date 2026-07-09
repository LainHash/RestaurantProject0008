using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.Recipes;
using Restaurant.Contract.DTOs.Production.RecipeSteps;

namespace Restaurant.Application.Features.Production.Recipes.Commands.AddStep
{
    public record AddStepCommand(Guid RecipeId, IEnumerable<AddStepRequest> Body)
        : IRequest<Result<RecipeResponse>>
    {
    }
}
