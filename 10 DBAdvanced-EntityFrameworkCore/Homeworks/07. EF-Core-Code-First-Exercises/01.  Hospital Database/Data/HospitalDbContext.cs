using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PatientMedicament> Prescriptions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        public HospitalDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region patientConstraints

            builder.Entity<Patient>()
                .HasKey(p => p.PatientId);

            builder.Entity<Patient>()
                .Property(p => p.FirstName)
                .IsUnicode()
                .HasMaxLength(50);

            builder.Entity<Patient>()
                .Property(p => p.LastName)
                .IsUnicode()
                .HasMaxLength(50);

            builder.Entity<Patient>()
                .Property(p => p.Address)
                .HasMaxLength(250)
                .IsUnicode();

            builder.Entity<Patient>()
                .Property(p => p.Email)
                .HasMaxLength(80);

            builder.Entity<Patient>()
                .HasMany(p => p.Visitations)
                .WithOne(v => v.Patient)
                .HasForeignKey(v => v.PatientId);

            builder.Entity<Patient>()
                .HasMany(p => p.Diagnoses)
                .WithOne(d => d.Patient)
                .HasForeignKey(d => d.PatientId);

            builder.Entity<Patient>() //not 2 sure about this
                .HasMany(p => p.Prescriptions);

            #endregion

            #region visitationConstraints

            builder.Entity<Visitation>()
                .HasKey(v => v.VisitationId);

            builder.Entity<Visitation>()
                .Property(v => v.Comments)
                .HasMaxLength(250)
                .IsUnicode();

            builder.Entity<Visitation>()
                .HasOne(v => v.Doctor)
                .WithMany(d => d.Visitations)
                .HasForeignKey(v => v.VisitationId);

            #endregion

            #region diagnoseConstraints

            builder.Entity<Diagnose>()
                .HasKey(d => d.DiagnoseId);

            builder.Entity<Diagnose>()
                .Property(d => d.Name)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Entity<Diagnose>()
                .Property(d => d.Comments)
                .HasMaxLength(250)
                .IsUnicode();

            builder.Entity<Diagnose>() //to test with this and without this
                .HasOne(d => d.Patient)
                .WithMany(p => p.Diagnoses);

            #endregion

            #region medicamentConstraints

            builder.Entity<Medicament>()
                .HasKey(m => m.MedicamentId);


            builder.Entity<Medicament>()
                .Property(m => m.Name)
                .HasMaxLength(50)
                .IsUnicode();

            #endregion

            #region doctorConstraints

            builder.Entity<Doctor>()
                .HasKey(d => d.DoctorId);

            builder.Entity<Doctor>()
                .Property(p => p.Name)
                .IsUnicode()
                .HasMaxLength(100);

            builder.Entity<Doctor>()
                .Property(p => p.Specialty)
                .IsUnicode()
                .HasMaxLength(100);

            builder.Entity<Doctor>()
                .HasMany(d => d.Visitations)
                .WithOne(v => v.Doctor)
                .HasForeignKey(v => v.DoctorId);

            #endregion
            

            builder.Entity<PatientMedicament>()
                .ToTable("PatientsMedicaments")
                .HasKey(pm => new { pm.PatientId, pm.MedicamentId });

        }

    }
}