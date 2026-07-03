namespace Restaurant.Domain.Informations.Catalog.Products
{
    public sealed record UpdateProductInformation(
        string Name,
        string? Description,
        bool IsMadeToOrder,
        bool IsAvailable,
        Guid CategoryId);
}
