using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HospitalManagement.Appointments;

// Bir hasta ile doktor arasındaki randevuyu temsil eder.
public class Appointment : FullAuditedAggregateRoot<Guid>
{
    // Randevunun ait olduğu hasta
    public Guid PatientId { get; set; }

    // Randevunun ait olduğu doktor
    public Guid DoctorId { get; set; }

    // Randevunun tarih ve saati
    public DateTime AppointmentDate { get; set; }

    // Bekliyor, Tamamlandı veya İptal
    public string Status { get; set; } = "Bekliyor";

    // Doktorun randevuyla ilgili kısa notu
    public string Notes { get; set; } = string.Empty;

    // EF Core için
    public Appointment()
    {
    }

    public Appointment(
        Guid id,
        Guid patientId,
        Guid doctorId,
        DateTime appointmentDate,
        string status,
        string notes) : base(id)
    {
        PatientId = patientId;
        DoctorId = doctorId;
        AppointmentDate = appointmentDate;
        Status = status;
        Notes = notes;
    }
}