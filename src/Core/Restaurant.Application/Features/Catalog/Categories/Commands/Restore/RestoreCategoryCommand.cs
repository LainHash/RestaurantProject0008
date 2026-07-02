using MediatR;
using Restaurant.Application.Models.Results;

namespace Restaurant.Application.Features.Catalog.Categories.Commands.Restore
{
    public record RestoreCategoryCommand(Guid Id) : IRequest<Result<object>>
    {
    }
}
