using MediatR;
using Restaurant.Application.Models;

namespace Restaurant.Application.Features.Catalog.Categories.Commands.Delete
{
    public record DeleteCategoryCommand(Guid Id) : IRequest<Result<object>>
    {
    }
}
