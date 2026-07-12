using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Personnel;
using Restaurant.Contract.DTOs.Personnel.Employees;

namespace Restaurant.Application.Features.Personnel.Employees.Queries.GetById
{
    internal class GetEmployeeByIdQueryHandler
        : IRequestHandler<GetEmployeeByIdQuery, Result<EmployeeResponse>>
    {
        private readonly IEmployeeService _employeeService;

        public GetEmployeeByIdQueryHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<Result<EmployeeResponse>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetEmployeeByIdSpecification(request);
            var response = await _employeeService.GetByIdAsync(specification, cancellationToken);
            return response;
        }
    }
}
