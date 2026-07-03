using MediatR;
using Restaurant.Application.Models.Results;

namespace Restaurant.Application.Features.Catalog.Products.Commands.Restore
{
    public record RestoreProductCommand(Guid Id) : IRequest<Result<object>>
    {
    }
}
