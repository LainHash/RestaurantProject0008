using Microsoft.EntityFrameworkCore;
using Restaurant.Contract.DTOs.Production.RecipeSteps;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Production.Recipes.Commands.AddStep
{
    public class AddStepSpecification : BaseSpecification<Recipe>
    {
        public Guid RecipeId { get; set; }
        public IEnumerable<AddStepRequest> Body {  get; set; }
        public AddStepSpecification(AddStepCommand command)
        {
            RecipeId = command.RecipeId;
            Body = command.Body;

            Criteria = r => r.Id == RecipeId;

            AddInclude(r => r.Product);
            AddInclude(r => r.RecipeSteps);
            AddIncludeAggregator(x => x.Include(r => r.RecipeIngredients)
                                        .ThenInclude(ri => ri.Ingredient)
                                        .ThenInclude(i => i.Category));
            AddIncludeAggregator(x => x.Include(r => r.RecipeIngredients)
                                        .ThenInclude(ri => ri.Ingredient)
                                        .ThenInclude(i => i.IngredientStock));
        }
    }
}
