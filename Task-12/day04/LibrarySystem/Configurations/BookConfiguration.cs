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
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> B)
        {
            B.ToTable("Books");

            B.HasKey(x => x.Id);

            B.Property(x => x.Title)
             .IsRequired()
             .HasColumnType("varchar")
             .HasMaxLength(200);

            B.Property(x => x.ISBN)
             .HasColumnType("varchar")
             .HasMaxLength(20);
        }
    }
}
