using Restaurant.Domain.Entities.Territory;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Territory.Areas.Queries.GetAll
{
    public class GetAllAreasSpecification : BaseSpecification<Area>
    {
        public GetAllAreasSpecification(GetAllAreasQuery query)
        {
            AddInclude(a => a.RestaurantTables);
        }
    }
}
