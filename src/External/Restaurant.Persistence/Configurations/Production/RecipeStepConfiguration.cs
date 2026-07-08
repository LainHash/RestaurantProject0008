using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities.Production;

namespace Restaurant.Persistence.Configurations.Production
{
    internal class RecipeStepConfiguration : IEntityTypeConfiguration<RecipeStep>
    {
        public void Configure(EntityTypeBuilder<RecipeStep> builder)
        {
            builder.HasKey(rs => rs.Id);

            builder.Property(rs => rs.RecipeId)
                .IsRequired();

            builder.Property(rs => rs.StepNumber)
                .IsRequired();

            builder.Property(rs => rs.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(rs => rs.DurationSeconds)
                .IsRequired();

            // Relationship
            builder.HasOne(rs => rs.Recipe)
                .WithMany(r => r.RecipeSteps)
                .HasForeignKey(rs => rs.RecipeId)
                .HasPrincipalKey(r => r.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
