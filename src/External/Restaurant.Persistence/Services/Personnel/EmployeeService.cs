using Restaurant.Application.Features.Personnel.Employees.Queries.GetAll;
using Restaurant.Application.Features.Personnel.Employees.Queries.GetById;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Personnel;
using Restaurant.Contract.DTOs.Personnel.Employees;
using Restaurant.Domain.Entities.Personnel;
using Restaurant.Domain.Repositories.Personnel;
using System.Net;

namespace Restaurant.Persistence.Services.Personnel
{
    internal class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Result<IEnumerable<EmployeeResponse>>> GetAllAsync(GetAllEmployeesSpecification specification, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.ToListAsync(specification, cancellationToken);

            var response = employees.Select(x => new EmployeeResponse(x));
            return Result<IEnumerable<EmployeeResponse>>
                .Succeed(response, Success<Employee>.Retrieved);
        }

        public async Task<Result<EmployeeResponse>> GetByIdAsync(GetEmployeeByIdSpecification specification, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.FindAsync(specification, cancellationToken);
            if(employee is null)
            {
                return Result<EmployeeResponse>
                    .Fail(Error<Employee>.NotFound, HttpStatusCode.NotFound);
            }

            var response = new EmployeeResponse(employee);
            return Result<EmployeeResponse>
                .Succeed(response, Success<Employee>.Retrieved);
        }
    }
}
