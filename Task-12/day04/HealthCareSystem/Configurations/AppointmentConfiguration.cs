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
    internal class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> A)
        {
            A.ToTable("Appointments");

            // Composite Key
            A.HasKey(x => new { x.PatientId, x.DoctorId });

            A.Property(x => x.AppointmentDate)
             .IsRequired();

            A.HasOne(x => x.Patient)
             .WithMany(p => p.Appointments)
             .HasForeignKey(x => x.PatientId);

            A.HasOne(x => x.Doctor)
             .WithMany(d => d.Appointments)
             .HasForeignKey(x => x.DoctorId);
        }
    }
}
