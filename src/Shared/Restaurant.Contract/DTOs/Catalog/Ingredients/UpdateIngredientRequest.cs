namespace Restaurant.Contract.DTOs.Catalog.Ingredients
{
    public class UpdateIngredientRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public Guid CategoryId { get; set; }
    }
}
