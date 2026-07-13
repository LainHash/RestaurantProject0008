using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Personnel;
using Restaurant.Contract.DTOs.Personnel.Employees;

namespace Restaurant.Application.Features.Personnel.Employees.Commands.Create
{
    internal class CreateEmployeeCommandHandler
        : IRequestHandler<CreateEmployeeCommand, Result<EmployeeResponse>>
    {
        private readonly IEmployeeService _employeeService;

        public CreateEmployeeCommandHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<Result<EmployeeResponse>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var specification = new CreateEmployeeSpecification(request);
            var response = await _employeeService.CreateAsync(specification, cancellationToken);
            return response;
        }
    }
}
