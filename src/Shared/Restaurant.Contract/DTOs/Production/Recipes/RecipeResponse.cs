using Restaurant.Contract.DTOs.Catalog.Ingredients;
using Restaurant.Contract.DTOs.Production.RecipeSteps;
using Restaurant.Domain.Entities.Production;

namespace Restaurant.Contract.DTOs.Production.Recipes
{
    public class RecipeResponse
    {
        public string Inspiration { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;

        public IEnumerable<IngredientResponse> Ingredients { get; set; } = [];
        public IEnumerable<RecipeStepResponse> RecipeSteps { get; set; } = [];

        public RecipeResponse(Recipe recipe)
        {
            Inspiration = recipe.Inspiration;
            Note = recipe.Note;
            ProductName = recipe.Product.Name;
            Ingredients = recipe.RecipeIngredients
                .Select(x => new IngredientResponse(x.Ingredient))
                .ToList();
            RecipeSteps = recipe.RecipeSteps
                .Select(x => new RecipeStepResponse(x))
                .ToList();
        }
    }
}
