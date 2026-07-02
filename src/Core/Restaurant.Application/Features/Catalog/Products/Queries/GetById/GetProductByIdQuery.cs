using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Catalog.Products;

namespace Restaurant.Application.Features.Catalog.Products.Queries.GetById
{
    public record GetProductByIdQuery(Guid Id) : IRequest<Result<ProductResponse>>
    {
    }
}
