namespace Restaurant.Contract.DTOs.Production.RecipeIngredients
{
    public class AddIngredientRequest
    {
        public Guid RecipeId { get; set; }
        public IEnumerable<Guid> IngredientIds { get; set; } = [];

        public AddIngredientRequest(Guid recipeId, IEnumerable<Guid> ingredientIds)
        {
            RecipeId = recipeId;
            IngredientIds = ingredientIds;
        }
    }
}
