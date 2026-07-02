using MediatR;
using Restaurant.Application.Models;

namespace Restaurant.Application.Features.Catalog.Categories.Commands.Restore
{
    public record RestoreCategoryCommand(Guid Id) : IRequest<Result<object>>
    {
    }
}
