using System;
using Volo.Abp.Application.Dtos;

namespace HospitalManagement.Appointments;

// Randevu bilgilerini API, web ve mobile taşır.
public class AppointmentDto : FullAuditedEntityDto<Guid>
{
    public Guid PatientId { get; set; }

    public Guid DoctorId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string Status { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;
}