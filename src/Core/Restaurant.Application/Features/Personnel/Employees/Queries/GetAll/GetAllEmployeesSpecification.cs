using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Personnel;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Personnel.Employees.Queries.GetAll
{
    public class GetAllEmployeesSpecification
        : BaseSpecification<Employee>
    {
        public GetAllEmployeesSpecification(GetAllEmployeesQuery query)
        {
            AddInclude(x => x.Profile!);
            AddInclude(x => x.Position);
            AddIncludeAggregator(x => x.Include(e => e.User)
                                        .ThenInclude(u => u.Role));
        }
    }
}
