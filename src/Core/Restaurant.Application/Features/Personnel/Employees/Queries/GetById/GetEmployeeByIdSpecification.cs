using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Personnel;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Personnel.Employees.Queries.GetById
{
    public class GetEmployeeByIdSpecification
        : BaseSpecification<Employee>
    {
        public GetEmployeeByIdSpecification(GetEmployeeByIdQuery query)
        {
            Criteria = e => e.Id == query.Id;

            AddInclude(x => x.Profile!);
            AddInclude(x => x.Position);
            AddIncludeAggregator(x => x.Include(e => e.User)
                                        .ThenInclude(u => u.Role));
        }
    }
}
