using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using day04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace day04.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> P)
        {
            P.ToTable("Products");

            P.HasKey(x => x.Id);

            P.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(150);

            P.Property(x => x.Price)
                .HasColumnType("decimal(10,2)")
                .IsRequired();
        }
    }
}
