using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Configurations
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> A)
        {
            A.ToTable("Authors");

            A.HasKey(x => x.Id);

            A.Property(x => x.Name)
             .IsRequired()
             .HasColumnType("varchar")
             .HasMaxLength(100);

            A.Property(x => x.BirthDate)
             .IsRequired();

            // One-to-Many
            A.HasMany(x => x.Books)
             .WithOne(b => b.Author)
             .HasForeignKey(b => b.AuthorId);
        }
    }
}
