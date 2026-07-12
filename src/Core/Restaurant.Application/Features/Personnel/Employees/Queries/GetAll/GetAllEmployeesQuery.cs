using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Personnel.Employees;

namespace Restaurant.Application.Features.Personnel.Employees.Queries.GetAll
{
    public record GetAllEmployeesQuery
        : IRequest<Result<IEnumerable<EmployeeResponse>>>
    {
    }
}
