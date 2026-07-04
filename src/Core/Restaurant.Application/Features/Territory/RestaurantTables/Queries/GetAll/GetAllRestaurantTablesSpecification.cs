using Restaurant.Domain.Entities.Territory;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Territory.RestaurantTables.Queries.GetAll
{
    public class GetAllRestaurantTablesSpecification : BaseSpecification<RestaurantTable>
    {
        public GetAllRestaurantTablesSpecification(GetAllRestaurantTablesQuery query)
        {
        }
    }
}
