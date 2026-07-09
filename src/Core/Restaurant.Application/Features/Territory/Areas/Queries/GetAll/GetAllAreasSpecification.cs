using Restaurant.Application.Common.Enums;
using Restaurant.Domain.Entities.Territory;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Territory.Areas.Queries.GetAll
{
    public class GetAllAreasSpecification : BaseSpecification<Area>
    {
        public GetAllAreasSpecification(GetAllAreasQuery query)
        {
            AddInclude(a => a.RestaurantTables);

            // Criteria: filter theo Keyword (tên khu vực)
            if (!string.IsNullOrWhiteSpace(query.Keyword))
            {
                Criteria = a => a.Name.ToLower().Contains(query.Keyword!.ToLower());
            }

            // OrderBy
            switch (query.SortBy)
            {
                case nameof(SortType.NameAsc):
                    ApplyOrderBy(a => a.Name);
                    break;
                case nameof(SortType.NameDesc):
                    ApplyOrderByDescending(a => a.Name);
                    break;
                case nameof(SortType.CreatedAtAsc):
                    ApplyOrderBy(a => a.CreatedAt);
                    break;
                default:
                    ApplyOrderByDescending(a => a.CreatedAt);
                    break;
            }

            // Paging
            ApplyPaging((query.IndexPage - 1) * query.PageSize, query.PageSize);
        }
    }
}

