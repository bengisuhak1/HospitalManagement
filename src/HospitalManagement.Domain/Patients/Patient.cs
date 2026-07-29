using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HospitalManagement.Patients;

// Veritabanındaki bir hastayı temsil eder.
public class Patient : FullAuditedAggregateRoot<Guid>
{
    // Hastanın T.C. kimlik numarası
    public string IdentityNumber { get; set; } = string.Empty;

    // Hastanın adı
    public string FirstName { get; set; } = string.Empty;

    // Hastanın soyadı
    public string LastName { get; set; } = string.Empty;

    // Hastanın doğum tarihi
    public DateTime BirthDate { get; set; }

    // Hastanın telefon numarası
    public string PhoneNumber { get; set; } = string.Empty;
    // EF Core için
public Patient()
{
}
public Patient(
    Guid id,
    string identityNumber,
    string firstName,
    string lastName,
    DateTime birthDate,
    string phoneNumber) : base(id)
{
    IdentityNumber = identityNumber;
    FirstName = firstName;
    LastName = lastName;
    BirthDate = birthDate;
    PhoneNumber = phoneNumber;
}
}