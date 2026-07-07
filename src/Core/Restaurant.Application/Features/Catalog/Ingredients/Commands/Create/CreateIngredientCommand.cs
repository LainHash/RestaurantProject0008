using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Catalog.Ingredients;

namespace Restaurant.Application.Features.Catalog.Ingredients.Commands.Create
{
    public record CreateIngredientCommand(CreateIngredientRequest Body) : IRequest<Result<IngredientResponse>>
    {
    }
}
