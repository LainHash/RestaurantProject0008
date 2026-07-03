using MediatR;
using Restaurant.Application.Models.Results;

namespace Restaurant.Application.Features.Catalog.Products.Commands.Delete
{
    internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<object>>
    {
        public Task<Result<object>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
