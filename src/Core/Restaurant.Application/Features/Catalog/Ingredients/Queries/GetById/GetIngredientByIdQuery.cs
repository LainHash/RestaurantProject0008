using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Catalog.Ingredients;

namespace Restaurant.Application.Features.Catalog.Ingredients.Queries.GetById
{
    public record GetIngredientByIdQuery(Guid Id) : IRequest<Result<IngredientResponse>>
    {
    }
}
