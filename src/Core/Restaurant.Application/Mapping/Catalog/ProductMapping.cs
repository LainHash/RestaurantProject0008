using Restaurant.Contract.DTOs.Catalog.Products;
using Restaurant.Domain.Entities.Inventory;
using Restaurant.Domain.Informations.Catalog;

namespace Restaurant.Application.Mapping.Catalog
{
    public static class ProductMapping
    {
        public static ProductInformation ToInfo(this CreateProductRequest request)
        {
            return new ProductInformation(
                request.Name,
                request.Description,
                request.IsMadeToOrder,
                request.IsAvailable,
                request.CategoryId,
                ProductStock.Create(
                    request.UnitPrice,
                    request.Unit,
                    request.StockQuantity));
        }
    }
}
