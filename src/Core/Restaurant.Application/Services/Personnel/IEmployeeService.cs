using Restaurant.Contract.DTOs.Personnel.Employees;

namespace Restaurant.Application.Services.Personnel
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResponse>> GetAllAsync();
    }
}
