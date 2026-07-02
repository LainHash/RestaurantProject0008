using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Catalog.Products.Queries.GetAll
{
    public class GetAllProductSpecification : BaseSpecification<Product>
    {
        public GetAllProductSpecification(GetAllProductsQuery query)
        {
            AddInclude(p => p.Category);
            AddInclude(p => p.ProductStock);
        }
    }
}
