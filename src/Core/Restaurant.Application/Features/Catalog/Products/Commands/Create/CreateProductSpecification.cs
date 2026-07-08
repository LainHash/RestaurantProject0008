using Microsoft.EntityFrameworkCore;
using Restaurant.Contract.DTOs.Catalog.Products;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Entities.Misc;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Catalog.Products.Commands.Create
{
    public class CreateProductSpecification : BaseSpecification<Product>
    {
        public CreateProductRequest Body { get; set; }

        public CreateProductSpecification(CreateProductCommand command)
        {
            Body = command.Body;

            AddInclude(p => p.Category);
            AddInclude(p => p.ProductStock);
            AddIncludeAggregator(q => q.Include(p => p.ProductImages)
                                       .ThenInclude((ProductImage pi) => pi.Image));
        }

        public void ApplyCriteria(Guid id)
        {
            Criteria = p => p.Id == id;
        }
    }
}
