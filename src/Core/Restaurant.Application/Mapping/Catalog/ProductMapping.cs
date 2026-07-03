using Restaurant.Contract.DTOs.Catalog.Products;
using Restaurant.Domain.Entities.Inventory;
using Restaurant.Domain.Informations.Catalog.Products;

namespace Restaurant.Application.Mapping.Catalog
{
    public static class ProductMapping
    {
        public static CreateProductInformation ToInfo(this CreateProductRequest request)
        {
            return new CreateProductInformation(
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

        public static UpdateProductInformation ToInfo(this UpdateProductRequest request)
        {
            return new UpdateProductInformation(
                request.Name,
                request.Description,
                request.IsMadeToOrder,
                request.IsAvailable,
                request.CategoryId);
        }
    }
}
