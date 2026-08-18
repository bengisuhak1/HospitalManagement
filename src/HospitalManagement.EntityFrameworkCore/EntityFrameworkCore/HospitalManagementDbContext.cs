using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using HospitalManagement.Patients;
using HospitalManagement.Doctors;
using HospitalManagement.Appointments;
using HospitalManagement.LabResults;
using HospitalManagement.Prescriptions;
using HospitalManagement.ExaminationNotes;
namespace HospitalManagement.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class HospitalManagementDbContext :
    AbpDbContext<HospitalManagementDbContext>,
    ITenantManagementDbContext,
    IIdentityDbContext
{
   public DbSet<Patient> Patients { get; set; }
public DbSet<Doctor> Doctors { get; set; }
public DbSet<Appointment> Appointments { get; set; }
public DbSet<LabResult> LabResults { get; set; }
public DbSet<Prescription> Prescriptions { get; set; }
public DbSet<ExaminationNote> ExaminationNotes { get; set; }
    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext and ISaasDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public HospitalManagementDbContext(DbContextOptions<HospitalManagementDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureTenantManagement();

        builder.Entity<Patient>(patient =>
{
    // PostgreSQL'deki tablo adı
    patient.ToTable("Patients");

    // ABP'nin Id ve denetim alanlarını otomatik yapılandırır
    patient.ConfigureByConvention();

    patient.Property(x => x.IdentityNumber)
        .IsRequired()
        .HasMaxLength(11);

    patient.Property(x => x.FirstName)
        .IsRequired()
        .HasMaxLength(64);

    patient.Property(x => x.LastName)
        .IsRequired()
        .HasMaxLength(64);

    patient.Property(x => x.BirthDate)
        .IsRequired()
        .HasColumnType("date");

    patient.Property(x => x.PhoneNumber)
        .IsRequired()
        .HasMaxLength(20);

    // Aynı T.C. kimlik numarasıyla iki hasta kaydedilemez
    patient.HasIndex(x => x.IdentityNumber)
        .IsUnique();
});  builder.Entity<Doctor>(doctor =>
{
    doctor.ToTable("Doctors");

    doctor.ConfigureByConvention();

    doctor.Property(x => x.FirstName)
        .IsRequired()
        .HasMaxLength(64);

    doctor.Property(x => x.LastName)
        .IsRequired()
        .HasMaxLength(64);

    doctor.Property(x => x.Specialty)
        .IsRequired()
        .HasMaxLength(100);

    doctor.Property(x => x.PhoneNumber)
        .IsRequired()
        .HasMaxLength(20);
});
builder.Entity<Appointment>(appointment =>
{
    appointment.ToTable("Appointments");

    appointment.ConfigureByConvention();

    appointment.Property(x => x.PatientId)
        .IsRequired();

    appointment.Property(x => x.DoctorId)
        .IsRequired();

    appointment.Property(x => x.AppointmentDate)
        .IsRequired();

    appointment.Property(x => x.Status)
        .IsRequired()
        .HasMaxLength(32);

    appointment.Property(x => x.Notes)
        .HasMaxLength(500);

    appointment.HasIndex(x => x.PatientId);
    appointment.HasIndex(x => x.DoctorId);
    appointment.HasIndex(x => x.AppointmentDate);
});
builder.Entity<LabResult>(labResult =>
{
    labResult.ToTable("LabResults");

    labResult.ConfigureByConvention();

    labResult.Property(x => x.PatientId)
        .IsRequired();

    labResult.Property(x => x.TestName)
        .IsRequired()
        .HasMaxLength(128);

    labResult.Property(x => x.ResultValue)
        .IsRequired()
        .HasMaxLength(64);

    labResult.Property(x => x.Unit)
        .HasMaxLength(32);

    labResult.Property(x => x.ReferenceRange)
        .HasMaxLength(64);

    labResult.Property(x => x.Status)
        .IsRequired()
        .HasMaxLength(32);

    labResult.Property(x => x.ResultDate)
        .IsRequired();

    labResult.HasIndex(x => x.PatientId);
    labResult.HasIndex(x => x.ResultDate);
});
builder.Entity<Prescription>(prescription =>
{
    prescription.ToTable("Prescriptions");

    prescription.ConfigureByConvention();

    prescription.Property(x => x.PatientId).IsRequired();
    prescription.Property(x => x.DoctorId).IsRequired();

    prescription.Property(x => x.MedicationName)
        .IsRequired()
        .HasMaxLength(128);

    prescription.Property(x => x.Dosage)
        .IsRequired()
        .HasMaxLength(64);

    prescription.Property(x => x.Frequency)
        .IsRequired()
        .HasMaxLength(64);

    prescription.Property(x => x.Duration)
        .IsRequired()
        .HasMaxLength(64);

    prescription.Property(x => x.Instructions)
        .HasMaxLength(500);

    prescription.Property(x => x.PrescriptionDate).IsRequired();

    prescription.HasIndex(x => x.PatientId);
    prescription.HasIndex(x => x.DoctorId);
    prescription.HasIndex(x => x.PrescriptionDate);
});
builder.Entity<ExaminationNote>(examinationNote =>
{
    examinationNote.ToTable("ExaminationNotes");

    examinationNote.ConfigureByConvention();

    examinationNote.Property(x => x.PatientId).IsRequired();
    examinationNote.Property(x => x.DoctorId).IsRequired();

    examinationNote.Property(x => x.Complaint)
        .IsRequired()
        .HasMaxLength(500);

    examinationNote.Property(x => x.Diagnosis)
        .IsRequired()
        .HasMaxLength(500);

    examinationNote.Property(x => x.Treatment)
        .IsRequired()
        .HasMaxLength(1000);

    examinationNote.Property(x => x.Notes)
        .HasMaxLength(1000);

    examinationNote.Property(x => x.ExaminationDate).IsRequired();

    examinationNote.HasIndex(x => x.PatientId);
    examinationNote.HasIndex(x => x.DoctorId);
    examinationNote.HasIndex(x => x.ExaminationDate);
});
    }
}
