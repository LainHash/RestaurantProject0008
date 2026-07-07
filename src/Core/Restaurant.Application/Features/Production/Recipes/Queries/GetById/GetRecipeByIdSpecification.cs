using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Production.Recipes.Queries.GetById
{
    public class GetRecipeByIdSpecification : BaseSpecification<Recipe>
    {
        public GetRecipeByIdSpecification(GetRecipeByIdQuery query)
        {
            Criteria = r => r.Id == query.Id;

            AddInclude(r => r.Product);
            AddIncludeAggregator(x => x.Include(r => r.RecipeIngredients)
                                        .ThenInclude(ri => ri.Ingredient)
                                        .ThenInclude(i => i.Category));
            AddIncludeAggregator(x => x.Include(r => r.RecipeIngredients)
                                        .ThenInclude(ri => ri.Ingredient)
                                        .ThenInclude(i => i.IngredientStock));
        }
    }
}
