using MediatR;
using Restaurant.Application.Common.Enums;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Catalog.Categories.Queries.GetAll
{
    public class GetAllCategoriesSpecification : BaseSpecification<Category>
    {
        public GetAllCategoriesSpecification(GetAllCategoriesQuery query)
        {
            if (!string.IsNullOrWhiteSpace(query.Keyword))
            {
                Criteria = c => c.Name.ToLower()
                                    .Contains(query.Keyword.ToLower());
            }

            switch (query.SortBy)
            {
                case nameof(SortType.CreatedAtAsc):
                    ApplyOrderBy(c => c.CreatedAt);
                    break;
                case nameof(SortType.NameAsc):
                    ApplyOrderBy(c => c.Name);
                    break;
                case nameof(SortType.NameDesc):
                    ApplyOrderByDescending(c => c.Name);
                    break;
                default:
                    ApplyOrderByDescending(c => c.CreatedAt);
                    break;
            }

            ApplyPaging((query.IndexPage - 1) * query.PageSize, query.PageSize);
        }
    }
}
