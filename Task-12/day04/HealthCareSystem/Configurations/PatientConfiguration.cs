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
    internal class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> P)
        {
            P.ToTable("Patients");

            P.HasKey(x => x.Id);

            P.Property(x => x.Name)
             .IsRequired()
             .HasColumnType("varchar")
             .HasMaxLength(100);

            P.Property(x => x.DateOfBirth)
             .IsRequired();
        }
    }
}
