using Restaurant.Contract.DTOs.Inventory.ProductStocks;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Inventory.ProductStocks.Commands.Update
{
    public class UpdateProductStockSpecification : BaseSpecification<Product>
    {
        public UpdateProductStockRequest Body { get; set; }
        public UpdateProductStockSpecification(UpdateProductStockCommand command)
        {
            Criteria = p => p.Id == command.Id;
            Body = command.Body;

            AddInclude(p => p.Category);
            AddInclude(p => p.ProductStock);
        }
    }
}
