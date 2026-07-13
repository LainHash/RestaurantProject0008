using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Personnel;
using Restaurant.Contract.DTOs.Personnel.Employees;

namespace Restaurant.Application.Features.Personnel.Employees.Commands.CompleteProfile
{
    internal class CompleteEmployeeProfileCommandHandler
        : IRequestHandler<CompleteEmployeeProfileCommand, Result<EmployeeResponse>>
    {
        private readonly IEmployeeService _employeeService;

        public CompleteEmployeeProfileCommandHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<Result<EmployeeResponse>> Handle(CompleteEmployeeProfileCommand request, CancellationToken cancellationToken)
        {
            var specification = new CompleteEmployeeProfileSpecification(request);
            var response = await _employeeService.CompleteProfileAsync(specification, cancellationToken);
            return response;
        }
    }
}
