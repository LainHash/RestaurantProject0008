using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Identity;
using Restaurant.Domain.Informations.Personnel.Employees;

namespace Restaurant.Domain.Entities.Personnel
{
    public partial class Employee : SoftDeletableEntity
    {
        public DateOnly HiredDate { get; private set; }
        public decimal BaseSalary { get; private set; }
        public string Status { get; private set; } = string.Empty;

        public Guid PositionId { get; private set; }
        public Guid? ManagerId { get; private set; }

        public Guid UserId { get; private set; }
        public Guid? ProfileId { get; private set; }

        public virtual Position Position { get; private set; } = null!;
        public virtual Employee? Manager { get; private set; }
        public virtual ICollection<Employee> Subordinates { get; private set; } = new List<Employee>();
        public virtual User User { get; private set; } = null!;
        public virtual Profile? Profile { get; private set; }
    }

    public partial class Employee
    {
        public Employee() { }
        public Employee(CreateEmployeeInformation information)
        {
            HiredDate = information.HiredDate;
            BaseSalary = information.BaseSalary;
            Status = information.Status;
            PositionId = information.PositionId;
            ManagerId = information.ManagerId;
            UserId = information.UserId;
        }

        public void CompleteProfile(Guid profileId)
        {
            ProfileId = profileId;
        }
    }
}
