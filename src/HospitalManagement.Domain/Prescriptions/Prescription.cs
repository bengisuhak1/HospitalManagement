using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HospitalManagement.Prescriptions;

// Bir hastaya doktor tarafından yazılan ilaç reçetesini temsil eder.
public class Prescription : FullAuditedAggregateRoot<Guid>
{
    public Guid PatientId { get; set; }

    public Guid DoctorId { get; set; }

    public string MedicationName { get; set; } = string.Empty;

    public string Dosage { get; set; } = string.Empty;

    public string Frequency { get; set; } = string.Empty;

    public string Duration { get; set; } = string.Empty;

    public string Instructions { get; set; } = string.Empty;

    public DateTime PrescriptionDate { get; set; }

    // EF Core için boş constructor.
    public Prescription()
    {
    }

    public Prescription(
        Guid id,
        Guid patientId,
        Guid doctorId,
        string medicationName,
        string dosage,
        string frequency,
        string duration,
        string instructions,
        DateTime prescriptionDate) : base(id)
    {
        PatientId = patientId;
        DoctorId = doctorId;
        MedicationName = medicationName;
        Dosage = dosage;
        Frequency = frequency;
        Duration = duration;
        Instructions = instructions;
        PrescriptionDate = prescriptionDate;
    }
}
