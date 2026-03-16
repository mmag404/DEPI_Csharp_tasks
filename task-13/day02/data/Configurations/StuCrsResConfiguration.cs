using day02.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace day02.data.Configurations
{
    public class StuCrsResConfiguration : IEntityTypeConfiguration<StuCrsRes>
    {
        public void Configure(EntityTypeBuilder<StuCrsRes> builder)
        {
            builder.HasKey(x => new { x.StudentId, x.CourseId });

            builder.HasOne(x => x.Student)
                   .WithMany(s => s.StuCrsResults)
                   .HasForeignKey(x => x.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Course)
                   .WithMany(c => c.StuCrsResults)
                   .HasForeignKey(x => x.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
