using Restaurant.Contract.Abstraction;
using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Contract.DTOs.Catalog.Categories
{
    public class CategoryResponse
    {
        public Guid Id {  get; init; }
        public string Name { get; init; } = string.Empty;
        public string? Description { get; init; }

        public CategoryResponse(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            Description = category.Description;
        }
    }
}
