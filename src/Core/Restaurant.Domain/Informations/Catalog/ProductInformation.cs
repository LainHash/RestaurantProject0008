using Restaurant.Domain.Entities.Inventory;

namespace Restaurant.Domain.Informations.Catalog
{
    public sealed record ProductInformation(
        string Name,
        string? Description,
        bool IsMadeToOrder,
        bool IsAvailable,
        Guid CategoryId,
        ProductStock ProductStock);
}
