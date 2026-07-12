using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Personnel;
using Restaurant.Contract.DTOs.Personnel.Employees;

namespace Restaurant.Application.Features.Personnel.Employees.Queries.GetAll
{
    internal class GetAllEmployeesQueryHandler
        : IRequestHandler<GetAllEmployeesQuery, Result<IEnumerable<EmployeeResponse>>>
    {
        private readonly IEmployeeService _employeeService;

        public GetAllEmployeesQueryHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<Result<IEnumerable<EmployeeResponse>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllEmployeesSpecification(request);
            var response = await _employeeService.GetAllAsync(specification, cancellationToken);
            return response;
        }
    }
}
