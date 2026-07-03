using Restaurant.Contract.DTOs.Inventory.ProductStocks;
using Restaurant.Domain.Informations.Inventory.ProductStocks;

namespace Restaurant.Application.Mapping.Inventory
{
    public static class ProductStockMapping
    {
        public static UpdateProductStockInformation ToInfo(this UpdateProductStockRequest request)
        {
            return new UpdateProductStockInformation(
                request.UnitPrice,
                request.Unit,
                request.StockQuantity
            );
        }
    }
}
