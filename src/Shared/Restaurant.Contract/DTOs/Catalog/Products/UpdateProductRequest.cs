namespace Restaurant.Contract.DTOs.Catalog.Products
{
    public class UpdateProductRequest
    {
        public string Name { get; init; } = string.Empty;
        public string? Description { get; init; }
        public bool IsMadeToOrder { get; init; }
        public bool IsAvailable { get; init; }

        public Guid CategoryId { get; init; }
    }
}
