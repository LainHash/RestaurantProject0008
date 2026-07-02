using Restaurant.Contract.Abstraction;

namespace Restaurant.Contract.DTOs.Catalog.Categories
{
    public class CategoryResponse : SoftDeletableDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
