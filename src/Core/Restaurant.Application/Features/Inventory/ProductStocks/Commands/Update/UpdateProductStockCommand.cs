using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Catalog.Products;
using Restaurant.Contract.DTOs.Inventory.ProductStocks;

namespace Restaurant.Application.Features.Inventory.ProductStocks.Commands.Update
{
    public record UpdateProductStockCommand(Guid Id, UpdateProductStockRequest Body) : IRequest<Result<ProductResponse>>
    {
    }
}
