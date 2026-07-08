using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.RecipeIngredients;
using Restaurant.Contract.DTOs.Production.Recipes;

namespace Restaurant.Application.Features.Production.Recipes.Commands.AddIngredient
{
    public record AddIngredientCommand(Guid RecipeId, AddIngredientRequest Body) 
        : IRequest<Result<RecipeResponse>>
    {
    }
}
