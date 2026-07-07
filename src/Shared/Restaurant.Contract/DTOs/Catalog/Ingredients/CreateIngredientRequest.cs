namespace Restaurant.Contract.DTOs.Catalog.Ingredients
{
    public class CreateIngredientRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public Guid CategoryId { get; set; }

        public decimal UnitPrice { get; init; }
        public string Unit { get; init; } = string.Empty;
        public decimal StockQuantity { get; init; }
    }
}
