using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Catalog;

namespace Restaurant.Application.Features.Catalog.Products.Commands.Delete
{
    internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<object>>
    {
        private readonly IProductService _productService;
        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public Task<Result<object>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var response = _productService.DeleteAsync(request.Id, cancellationToken);
            return response;
        }
    }
}
