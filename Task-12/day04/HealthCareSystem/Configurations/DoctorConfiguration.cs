using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem.Configurations
{
    internal class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> D)
        {
            D.ToTable("Doctors");

            D.HasKey(x => x.Id);

            D.Property(x => x.Name)
             .IsRequired()
             .HasColumnType("varchar")
             .HasMaxLength(100);

            D.Property(x => x.Specialization)
             .HasColumnType("varchar")
             .HasMaxLength(100);
        }
    }
}
