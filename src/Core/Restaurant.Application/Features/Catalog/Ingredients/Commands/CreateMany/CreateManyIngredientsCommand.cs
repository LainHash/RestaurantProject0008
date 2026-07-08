using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Catalog.Ingredients;

namespace Restaurant.Application.Features.Catalog.Ingredients.Commands.CreateMany
{
    public record CreateManyIngredientsCommand(IEnumerable<CreateIngredientRequest> Body)
        : IRequest<Result<IEnumerable<IngredientResponse>>>
    {
    }
}
