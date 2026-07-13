namespace Restaurant.Domain.Informations.Personnel.Employees
{
    public sealed record CreateEmployeeInformation(
        Guid UserId,
        DateOnly HiredDate,
        decimal BaseSalary,
        string Status,
        Guid PositionId,
        Guid? ManagerId);
}
