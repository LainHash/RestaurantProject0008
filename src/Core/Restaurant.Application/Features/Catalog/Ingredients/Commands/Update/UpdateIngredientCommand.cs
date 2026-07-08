using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Catalog.Ingredients;

namespace Restaurant.Application.Features.Catalog.Ingredients.Commands.Update
{
    public record UpdateIngredientCommand(Guid Id, UpdateIngredientRequest Body)
        : IRequest<Result<IngredientResponse>>
    {
    }
}
