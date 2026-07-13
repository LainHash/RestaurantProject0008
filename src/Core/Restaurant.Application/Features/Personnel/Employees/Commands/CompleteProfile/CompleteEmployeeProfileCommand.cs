using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Personnel.Employees;

namespace Restaurant.Application.Features.Personnel.Employees.Commands.CompleteProfile
{
    public record CompleteEmployeeProfileCommand(Guid UserId, CompleteEmployeeProfileRequest Body)
        : IRequest<Result<EmployeeResponse>>
    {
    }
}
