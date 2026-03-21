using day02.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace day02.data.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(t => t.Salary)
                   .HasColumnType("decimal(18,2)");

            builder.HasOne(t => t.Course)
                   .WithMany(c => c.Teachers)
                   .HasForeignKey(t => t.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Department)
                   .WithMany(d => d.Teachers)
                   .HasForeignKey(t => t.DepartmentId)
                   .OnDelete(DeleteBehavior.NoAction); // FIX
        }
    }
}
