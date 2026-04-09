using day02.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace day02.data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasOne(s => s.Department)
                   .WithMany(d => d.Students)
                   .HasForeignKey(s => s.DepartmentId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
