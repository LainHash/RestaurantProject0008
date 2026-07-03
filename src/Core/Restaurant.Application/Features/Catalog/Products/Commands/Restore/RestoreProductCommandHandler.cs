using MediatR;
using Restaurant.Application.Models.Results;

namespace Restaurant.Application.Features.Catalog.Products.Commands.Restore
{
    internal class RestoreProductCommandHandler : IRequestHandler<RestoreProductCommand, Result<object>>
    {
        public Task<Result<object>> Handle(RestoreProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
