using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Appointments;

public class CreateUpdateAppointmentDto
{
    [Required]
    public Guid PatientId { get; set; }

    [Required]
    public Guid DoctorId { get; set; }

    [Required]
    public DateTime AppointmentDate { get; set; }

    [Required]
    [StringLength(32)]
    public string Status { get; set; } = "Bekliyor";

    [StringLength(500)]
    public string Notes { get; set; } = string.Empty;
}