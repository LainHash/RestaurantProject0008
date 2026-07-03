namespace Restaurant.Contract.DTOs.Catalog.Products
{
    public class CreateProductRequest
    {
        public string Name { get; init; } = string.Empty;
        public string? Description { get; init; }
        public bool IsMadeToOrder { get; init; }
        public bool IsAvailable { get; init; }

        public decimal UnitPrice { get; init; }
        public string Unit { get; init; } = string.Empty;
        public decimal StockQuantity { get; init; }

        public Guid CategoryId { get; init; }
    }
}
