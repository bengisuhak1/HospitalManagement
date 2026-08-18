using System;
using Volo.Abp.Application.Dtos;

namespace HospitalManagement.Prescriptions;

public class PrescriptionDto : FullAuditedEntityDto<Guid>
{
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public string MedicationName { get; set; } = string.Empty;
    public string Dosage { get; set; } = string.Empty;
    public string Frequency { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
    public string Instructions { get; set; } = string.Empty;
    public DateTime PrescriptionDate { get; set; }
}
