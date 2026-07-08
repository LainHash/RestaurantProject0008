namespace Restaurant.Contract.DTOs.Production.RecipeIngredients
{
    public class AddIngredientRequest
    {
        public IEnumerable<Guid> IngredientIds { get; set; } = [];

        public AddIngredientRequest(IEnumerable<Guid> ingredientIds)
        {
            IngredientIds = ingredientIds;
        }
    }
}
