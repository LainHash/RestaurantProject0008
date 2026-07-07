namespace Restaurant.Domain.Informations.Catalog.Ingredients
{
    public sealed record CreateIngredientInformation(
        string Name,
        string? Desctiption,
        Guid CategoryId,
        decimal UnitPrice,
        string Unit,
        decimal StockQuantity);
}
