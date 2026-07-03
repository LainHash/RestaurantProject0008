using Restaurant.Domain.Entities.Inventory;

namespace Restaurant.Domain.Informations.Catalog.Products
{
    public sealed record CreateProductInformation(
        string Name,
        string? Description,
        bool IsMadeToOrder,
        bool IsAvailable,
        Guid CategoryId,
        ProductStock ProductStock);
}
