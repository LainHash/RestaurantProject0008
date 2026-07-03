namespace Restaurant.Contract.DTOs.Inventory.ProductStocks
{
    public class UpdateProductStockRequest
    {
        public decimal UnitPrice { get; set; }
        public string Unit { get; set; } = string.Empty;
        public decimal StockQuantity { get; set; }
    }
}
