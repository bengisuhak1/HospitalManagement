using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.LabResults;

public class CreateUpdateLabResultDto
{
    [Required]
    public Guid PatientId { get; set; }

    [Required]
    [StringLength(128)]
    public string TestName { get; set; } = string.Empty;

    [Required]
    [StringLength(64)]
    public string ResultValue { get; set; } = string.Empty;

    [StringLength(32)]
    public string Unit { get; set; } = string.Empty;

    [StringLength(64)]
    public string ReferenceRange { get; set; } = string.Empty;

    [Required]
    [StringLength(32)]
    public string Status { get; set; } = "Normal";

    [Required]
    public DateTime ResultDate { get; set; }
}
