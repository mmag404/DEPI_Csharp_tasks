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
    internal class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> OD)
        {
            OD.ToTable("OrderDetails");

            // Composite Key
            OD.HasKey(x => new { x.OrderId, x.ProductId });

            OD.Property(x => x.Quantity)
                .IsRequired();

            // Order -> OrderDetails
            OD.HasOne(x => x.Order)
              .WithMany(o => o.OrderDetails)
              .HasForeignKey(x => x.OrderId);

            // Product -> OrderDetails
            OD.HasOne(x => x.Product)
              .WithMany(p => p.OrderDetails)
              .HasForeignKey(x => x.ProductId);
        }
    }
}
