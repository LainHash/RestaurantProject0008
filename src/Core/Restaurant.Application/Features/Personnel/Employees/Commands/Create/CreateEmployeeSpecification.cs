using Microsoft.EntityFrameworkCore;
using Restaurant.Contract.DTOs.Personnel.Employees;
using Restaurant.Domain.Entities.Personnel;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Personnel.Employees.Commands.Create
{
    public class CreateEmployeeSpecification
        : BaseSpecification<Employee>
    {
        public CreateEmployeeRequest Body { get; set; }
        public CreateEmployeeSpecification(CreateEmployeeCommand command)
        {
            Body = command.Body;

            AddInclude(x => x.Profile!);
            AddInclude(x => x.Position);
            AddIncludeAggregator(x => x.Include(e => e.User)
                                        .ThenInclude(u => u.Role));
        }

        public void ApplyCriteria(Guid id)
        {
            Criteria = p => p.Id == id;
        }
    }
}
