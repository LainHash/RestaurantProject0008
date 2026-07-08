using Microsoft.EntityFrameworkCore;
using Restaurant.Contract.DTOs.Production.Recipes;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Production.Recipes.Commands.Create
{
    public class CreateRecipeSpecification : BaseSpecification<Recipe>
    {
        public CreateRecipeRequest Body { get; set; }
        public CreateRecipeSpecification(CreateRecipeCommand command)
        {
            Body = command.Body;

            AddInclude(r => r.Product);
            AddInclude(r => r.RecipeSteps);
            AddIncludeAggregator(x => x.Include(r => r.RecipeIngredients)
                                        .ThenInclude(ri => ri.Ingredient)
                                        .ThenInclude(i => i.Category));
            AddIncludeAggregator(x => x.Include(r => r.RecipeIngredients)
                                        .ThenInclude(ri => ri.Ingredient)
                                        .ThenInclude(i => i.IngredientStock));
        }

        public void ApplyCriteria(Guid id)
        {
            Criteria = p => p.Id == id;
        }
    }
}
