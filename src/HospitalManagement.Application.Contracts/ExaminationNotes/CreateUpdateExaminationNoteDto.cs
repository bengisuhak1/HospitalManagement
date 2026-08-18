using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.ExaminationNotes;

public class CreateUpdateExaminationNoteDto
{
    [Required]
    public Guid PatientId { get; set; }

    [Required]
    public Guid DoctorId { get; set; }

    [Required]
    [StringLength(500)]
    public string Complaint { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string Diagnosis { get; set; } = string.Empty;

    [Required]
    [StringLength(1000)]
    public string Treatment { get; set; } = string.Empty;

    [StringLength(1000)]
    public string Notes { get; set; } = string.Empty;

    [Required]
    public DateTime ExaminationDate { get; set; }
}
