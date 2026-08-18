using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Prescriptions;

public class CreateUpdatePrescriptionDto
{
    [Required]
    public Guid PatientId { get; set; }

    [Required]
    public Guid DoctorId { get; set; }

    [Required]
    [StringLength(128)]
    public string MedicationName { get; set; } = string.Empty;

    [Required]
    [StringLength(64)]
    public string Dosage { get; set; } = string.Empty;

    [Required]
    [StringLength(64)]
    public string Frequency { get; set; } = string.Empty;

    [Required]
    [StringLength(64)]
    public string Duration { get; set; } = string.Empty;

    [StringLength(500)]
    public string Instructions { get; set; } = string.Empty;

    [Required]
    public DateTime PrescriptionDate { get; set; }
}
