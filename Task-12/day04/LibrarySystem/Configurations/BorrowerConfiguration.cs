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
    internal class BorrowerConfiguration : IEntityTypeConfiguration<Borrower>
    {
        public void Configure(EntityTypeBuilder<Borrower> B)
        {
            B.ToTable("Borrowers");

            B.HasKey(x => x.Id);

            B.Property(x => x.Name)
             .IsRequired()
             .HasColumnType("varchar")
             .HasMaxLength(100);

            B.Property(x => x.MembershipDate)
             .IsRequired();
        }
    }
}
