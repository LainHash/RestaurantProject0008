namespace Restaurant.Contract.DTOs.Production.Recipes
{
    public class CreateRecipeRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Inspiration { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;

        public Guid ProductId { get; set; } 
    }
}
