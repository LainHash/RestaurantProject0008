namespace Restaurant.Domain.Informations.Inventory.ProductStocks
{
    public sealed record UpdateProductStockInformation(
        decimal UnitPrice,
        string Unit,
        decimal StockQuantity);
}
