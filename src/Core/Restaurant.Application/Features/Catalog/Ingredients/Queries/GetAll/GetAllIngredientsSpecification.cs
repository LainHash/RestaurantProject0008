using Restaurant.Application.Common.Enums;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Catalog.Ingredients.Queries.GetAll
{
    public class GetAllIngredientsSpecification : BaseSpecification<Ingredient>
    {
        public GetAllIngredientsSpecification(GetAllIngredientsQuery query)
        {
            AddInclude(i => i.Category);
            AddInclude(i => i.IngredientStock);

            // Criteria: filter theo Keyword và CategoryId
            bool hasKeyword = !string.IsNullOrWhiteSpace(query.Keyword);
            bool hasCategoryId = !string.IsNullOrWhiteSpace(query.CategoryId);

            if (hasKeyword && hasCategoryId)
            {
                Criteria = i => i.Name.ToLower().Contains(query.Keyword!.ToLower()) &&
                                i.CategoryId.ToString() == query.CategoryId;
            }
            else if (hasKeyword)
            {
                Criteria = i => i.Name.ToLower().Contains(query.Keyword!.ToLower());
            }
            else if (hasCategoryId)
            {
                Criteria = i => i.CategoryId.ToString() == query.CategoryId;
            }

            // OrderBy
            switch (query.SortBy)
            {
                case nameof(SortType.NameAsc):
                    ApplyOrderBy(i => i.Name);
                    break;
                case nameof(SortType.NameDesc):
                    ApplyOrderByDescending(i => i.Name);
                    break;
                case nameof(SortType.CreatedAtAsc):
                    ApplyOrderBy(i => i.CreatedAt);
                    break;
                default:
                    ApplyOrderByDescending(i => i.CreatedAt);
                    break;
            }

            // Paging
            ApplyPaging((query.IndexPage - 1) * query.PageSize, query.PageSize);
        }
    }
}

