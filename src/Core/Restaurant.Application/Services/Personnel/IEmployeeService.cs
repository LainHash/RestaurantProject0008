using Restaurant.Application.Features.Personnel.Employees.Commands.Create;
using Restaurant.Application.Features.Personnel.Employees.Queries.GetAll;
using Restaurant.Application.Features.Personnel.Employees.Queries.GetById;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Personnel.Employees;

namespace Restaurant.Application.Services.Personnel
{
    public interface IEmployeeService
    {
        Task<Result<IEnumerable<EmployeeResponse>>> 
            GetAllAsync(GetAllEmployeesSpecification specification, CancellationToken cancellationToken);

        Task<Result<EmployeeResponse>>
            GetByIdAsync(GetEmployeeByIdSpecification specification, CancellationToken cancellationToken);

        Task<Result<EmployeeResponse>>
            CreateEmployeeAsync(CreateEmployeeSpecification specification, CancellationToken cancellationToken);
    }
}
