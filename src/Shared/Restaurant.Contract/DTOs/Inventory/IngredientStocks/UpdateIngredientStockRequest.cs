namespace Restaurant.Contract.DTOs.Inventory.IngredientStocks
{
    public class UpdateIngredientStockRequest
    {
        public decimal UnitPrice { get; set; }
        public string Unit { get; set; } = string.Empty;
        public decimal StockQuantity { get; set; }
    }
}
