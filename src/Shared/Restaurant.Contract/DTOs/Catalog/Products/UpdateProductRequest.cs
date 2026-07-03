namespace Restaurant.Contract.DTOs.Catalog.Products
{
    public class UpdateProductRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsMadeToOrder { get; set; }
        public bool IsAvailable { get; set; }

        public Guid CategoryId { get; set; }
    }
}
