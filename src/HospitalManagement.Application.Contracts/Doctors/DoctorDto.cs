using System;
using Volo.Abp.Application.Dtos;

namespace HospitalManagement.Doctors;

public class DoctorDto : FullAuditedEntityDto<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}