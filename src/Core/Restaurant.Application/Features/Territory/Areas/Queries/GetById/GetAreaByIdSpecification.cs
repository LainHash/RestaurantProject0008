using Restaurant.Domain.Entities.Territory;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Territory.Areas.Queries.GetById
{
    public class GetAreaByIdSpecification : BaseSpecification<Area>
    {
        public GetAreaByIdSpecification(GetAreaByIdQuery query)
        {
            Criteria = a => a.Id == query.Id;
            AddInclude(a => a.RestaurantTables);
        }
    }
}
