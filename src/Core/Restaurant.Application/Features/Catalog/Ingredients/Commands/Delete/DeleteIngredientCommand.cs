using MediatR;
using Restaurant.Application.Models.Results;

namespace Restaurant.Application.Features.Catalog.Ingredients.Commands.Delete
{
    public record DeleteIngredientCommand(Guid Id) : IRequest<Result<object>>
    {
    }
}
