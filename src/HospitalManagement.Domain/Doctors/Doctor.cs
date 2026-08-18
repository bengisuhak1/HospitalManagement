using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HospitalManagement.Doctors;

// Veritabanındaki bir doktoru temsil eder.
public class Doctor : FullAuditedAggregateRoot<Guid>
{
    // Doktorun adı
    public string FirstName { get; set; } = string.Empty;

    // Doktorun soyadı
    public string LastName { get; set; } = string.Empty;

    // Doktorun branşı
    public string Specialty { get; set; } = string.Empty;

    // Doktorun telefon numarası
    public string PhoneNumber { get; set; } = string.Empty;

    // EF Core için boş constructor
    public Doctor()
    {
    }

    // Yeni doktor oluşturmak için kullanılan constructor
    public Doctor(
        Guid id,
        string firstName,
        string lastName,
        string specialty,
        string phoneNumber) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Specialty = specialty;
        PhoneNumber = phoneNumber;
    }
}