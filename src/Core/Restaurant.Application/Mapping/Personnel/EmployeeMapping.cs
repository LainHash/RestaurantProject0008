using Restaurant.Contract.DTOs.Personnel.Employees;
using Restaurant.Domain.Informations.Personnel.Employees;

namespace Restaurant.Application.Mapping.Personnel
{
    public static class EmployeeMapping
    {
        public static CreateEmployeeInformation ToInfo(this CreateEmployeeRequest request, Guid userId)
        {
            return new CreateEmployeeInformation(
                userId,
                request.HiredDate,
                request.BaseSalary,
                request.Status,
                request.PositionId,
                request.ManagerId);
        }
    }
}
