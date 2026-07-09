using Restaurant.Contract.DTOs.Catalog.Ingredients;
using Restaurant.Contract.DTOs.Production.RecipeIngredients;
using Restaurant.Contract.DTOs.Production.RecipeSteps;
using Restaurant.Domain.Entities.Production;

namespace Restaurant.Contract.DTOs.Production.Recipes
{
    public class RecipeResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Inspiration { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;

        public IEnumerable<RecipeIngredientResponse> RecipeIngredients { get; set; } = [];
        public IEnumerable<RecipeStepResponse> RecipeSteps { get; set; } = [];

        public RecipeResponse(Recipe recipe)
        {
            Id = recipe.Id;
            Name = recipe.Name;
            Inspiration = recipe.Inspiration;
            Note = recipe.Note;
            ProductName = recipe.Product.Name;
            RecipeIngredients = recipe.RecipeIngredients
                .Select(x => new RecipeIngredientResponse(x.Ingredient, x.Quantity))
                .ToList();
            RecipeSteps = recipe.RecipeSteps
                .Select(x => new RecipeStepResponse(x))
                .ToList();
        }
    }
}
