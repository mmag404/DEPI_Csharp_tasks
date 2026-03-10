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
    internal class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> L)
        {
            L.ToTable("Loans");

            // Composite Key
            L.HasKey(x => new { x.BookId, x.BorrowerId });

            L.Property(x => x.LoanDate)
             .IsRequired();

            // Book relation
            L.HasOne(x => x.Book)
             .WithMany(b => b.Loans)
             .HasForeignKey(x => x.BookId);

            // Borrower relation
            L.HasOne(x => x.Borrower)
             .WithMany(b => b.Loans)
             .HasForeignKey(x => x.BorrowerId);
        }
    }
}
