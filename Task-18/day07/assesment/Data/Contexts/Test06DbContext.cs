using Microsoft.EntityFrameworkCore;
using assesment.Models;
using assesment.Data.Configurations;

namespace assesment.Data.Contexts
{
    public class Test06DbContext : DbContext
    {
        // DbSet (represents table)
        public DbSet<TaskItem> TaskItems { get; set; }

        // Configure connection 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=.;Initial Catalog=Test06;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"
            );
        }

        // Apply Fluent API configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.ApplyConfigurationsFromAssembly(typeof(Test06DbContext).Assembly);
        }
    }
}