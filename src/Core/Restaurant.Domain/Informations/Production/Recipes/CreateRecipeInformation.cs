namespace Restaurant.Domain.Informations.Production.Recipes
{
    public record CreateRecipeInformation(
        string Name,
        string? Inspiration,
        string Note,
        Guid ProductId);
}
