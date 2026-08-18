using System;
using Volo.Abp.Application.Dtos;

namespace HospitalManagement.ExaminationNotes;

public class ExaminationNoteDto : FullAuditedEntityDto<Guid>
{
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public string Complaint { get; set; } = string.Empty;
    public string Diagnosis { get; set; } = string.Empty;
    public string Treatment { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public DateTime ExaminationDate { get; set; }
}
