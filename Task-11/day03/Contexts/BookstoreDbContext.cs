using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using day03.Models;
using Microsoft.EntityFrameworkCore;

namespace day03.Contexts
{
    internal class BookstoreDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=BookstoreDB;Trusted_Connection=True;TrustServerCertificate=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(b => b.Title)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(b => b.Price)
                      .HasColumnType("decimal(8,2)");

                entity.Property(b => b.PublishedDate)
                      .IsRequired(false);
            });
        }

        public DbSet<Author>Authors { get; set; }
        public DbSet<Book> Books { get; set; }

    }
}
