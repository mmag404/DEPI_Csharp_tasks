using day02.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace day02.data.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasOne(c => c.Department)
                   .WithMany(d => d.Courses)
                   .HasForeignKey(c => c.DepartmentId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
