using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Personnel.Employees;

namespace Restaurant.Application.Features.Personnel.Employees.Queries.GetById
{
    public record GetEmployeeByIdQuery(Guid Id)
        : IRequest<Result<EmployeeResponse>>
    {
    }
}
