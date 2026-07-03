using Restaurant.Contract.DTOs.Catalog.Products;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Catalog.Products.Commands.Update
{
    public class UpdateProductSpecification : BaseSpecification<Product>
    {
        public UpdateProductRequest Body { get; set; }
        public UpdateProductSpecification(UpdateProductCommand command)
        {
            Criteria = p => p.Id == command.Id;
            Body = command.Body;

            AddInclude(p => p.Category);
            AddInclude(p => p.ProductStock);
        }
    }
}
