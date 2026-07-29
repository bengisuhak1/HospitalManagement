using System;
using Volo.Abp.Application.Dtos;

namespace HospitalManagement.Patients;

// Hasta bilgilerini API'ye veya ekrana taşır.
public class PatientDto : FullAuditedEntityDto<Guid>
{
    public string IdentityNumber { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;
}
