using MediatR;
using Restaurant.Application.Models.Abstraction;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Catalog.Products;

namespace Restaurant.Application.Features.Catalog.Products.Queries.GetAll
{
    public record GetAllProductsQuery(string? CategoryName) : PageQuery, IRequest<Result<IEnumerable<ProductResponse>>>
    {
    }
}
