using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Enums;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Production.Recipes.Queries.GetAll
{
    public class GetAllRecipesSpecification : BaseSpecification<Recipe>
    {
        public GetAllRecipesSpecification(GetAllRecipesQuery query)
        {
            AddInclude(r => r.Product);
            AddInclude(r => r.RecipeSteps);
            AddIncludeAggregator(x => x.Include(r => r.RecipeIngredients)
                                        .ThenInclude(ri => ri.Ingredient)
                                        .ThenInclude(i => i.Category));
            AddIncludeAggregator(x => x.Include(r => r.RecipeIngredients)
                                        .ThenInclude(ri => ri.Ingredient)
                                        .ThenInclude(i => i.IngredientStock));

            // Criteria: filter theo Keyword (tên recipe hoặc tên product)
            if (!string.IsNullOrWhiteSpace(query.Keyword))
            {
                Criteria = r => r.Product.Name.ToLower().Contains(query.Keyword!.ToLower());
            }

            // OrderBy
            switch (query.SortBy)
            {
                case nameof(SortType.NameAsc):
                    ApplyOrderBy(r => r.Product.Name);
                    break;
                case nameof(SortType.NameDesc):
                    ApplyOrderByDescending(r => r.Product.Name);
                    break;
                case nameof(SortType.CreatedAtAsc):
                    ApplyOrderBy(r => r.CreatedAt);
                    break;
                default:
                    ApplyOrderByDescending(r => r.CreatedAt);
                    break;
            }

            // Paging
            ApplyPaging((query.IndexPage - 1) * query.PageSize, query.PageSize);
        }
    }
}

