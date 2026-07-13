using Microsoft.EntityFrameworkCore;
using Restaurant.Contract.DTOs.Personnel.Employees;
using Restaurant.Domain.Entities.Personnel;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Personnel.Employees.Commands.CompleteProfile
{
    public class CompleteEmployeeProfileSpecification
        : BaseSpecification<Employee>
    {
        public Guid UserId { get; set; }
        public CompleteEmployeeProfileRequest Body { get; set; }
        public CompleteEmployeeProfileSpecification(CompleteEmployeeProfileCommand command)
        {
            Criteria = e => e.UserId == UserId;
            Body = command.Body;

            AddInclude(x => x.Profile!);
            AddInclude(x => x.Position);
            AddIncludeAggregator(x => x.Include(e => e.User)
                                        .ThenInclude(u => u.Role));
        }
    }
}
