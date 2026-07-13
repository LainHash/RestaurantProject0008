using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Personnel.Employees;

namespace Restaurant.Application.Features.Personnel.Employees.Commands.Create
{
    public record CreateEmployeeCommand(CreateEmployeeRequest Body)
        : IRequest<Result<EmployeeResponse>>
    {
    }
}
