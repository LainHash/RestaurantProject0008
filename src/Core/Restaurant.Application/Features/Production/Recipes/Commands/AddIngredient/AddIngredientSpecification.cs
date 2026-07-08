using Microsoft.EntityFrameworkCore;
using Restaurant.Contract.DTOs.Production.RecipeIngredients;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Production.Recipes.Commands.AddIngredient
{
    public class AddIngredientSpecification : BaseSpecification<Recipe>
    {
        public AddIngredientRequest Body { get; set; }
        public AddIngredientSpecification(AddIngredientCommand command)
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
