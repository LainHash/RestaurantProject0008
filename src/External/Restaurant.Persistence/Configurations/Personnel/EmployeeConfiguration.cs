using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Entities.Personnel;

namespace Restaurant.Persistence.Configurations.Personnel
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.HiredDate)
                .IsRequired();

            builder.Property(x => x.PositionId) 
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            // Relationships
            builder.HasOne(x => x.User)
                .WithOne(x => x.Employee)
                .HasForeignKey<Employee>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.PersonalInformation)
                .WithOne(x => x.Employee)
                .HasForeignKey<Employee>(x => x.PersonalInformationId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            builder.HasOne(x => x.Manager)
                .WithMany(x => x.Subordinates)
                .HasForeignKey(x => x.ManagerId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            // Soft delete filter
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
