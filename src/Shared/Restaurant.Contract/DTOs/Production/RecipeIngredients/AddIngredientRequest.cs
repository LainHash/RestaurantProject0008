namespace Restaurant.Contract.DTOs.Production.RecipeIngredients
{
    public class AddIngredientRequest
    {
        public Guid IngredientId { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
    }
}
