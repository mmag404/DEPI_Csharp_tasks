using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using assesment.Models; // adjust namespace if needed

namespace assesment.Data.Configurations
{
    public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            // Primary Key (optional since EF detects Id automatically)
            builder.HasKey(t => t.Id);

            // Title max length 100 + required
            builder.Property(t => t.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            // Description max length 500
            builder.Property(t => t.Description)
                   .HasMaxLength(500);

            // Default value for CreatedAt (DATABASE LEVEL 🔥)
            builder.Property(t => t.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}