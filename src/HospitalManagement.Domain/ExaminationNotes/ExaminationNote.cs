using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HospitalManagement.ExaminationNotes;

// Doktorun bir hasta muayenesi sırasında oluşturduğu klinik notu temsil eder.
public class ExaminationNote : FullAuditedAggregateRoot<Guid>
{
    public Guid PatientId { get; set; }

    public Guid DoctorId { get; set; }

    public string Complaint { get; set; } = string.Empty;

    public string Diagnosis { get; set; } = string.Empty;

    public string Treatment { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;

    public DateTime ExaminationDate { get; set; }

    // EF Core için boş constructor.
    public ExaminationNote()
    {
    }

    public ExaminationNote(
        Guid id,
        Guid patientId,
        Guid doctorId,
        string complaint,
        string diagnosis,
        string treatment,
        string notes,
        DateTime examinationDate) : base(id)
    {
        PatientId = patientId;
        DoctorId = doctorId;
        Complaint = complaint;
        Diagnosis = diagnosis;
        Treatment = treatment;
        Notes = notes;
        ExaminationDate = examinationDate;
    }
}
