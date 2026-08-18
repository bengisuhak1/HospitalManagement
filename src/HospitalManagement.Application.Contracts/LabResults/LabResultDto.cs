using System;
using Volo.Abp.Application.Dtos;

namespace HospitalManagement.LabResults;

public class LabResultDto : FullAuditedEntityDto<Guid>
{
    public Guid PatientId { get; set; }
    public string TestName { get; set; } = string.Empty;
    public string ResultValue { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;
    public string ReferenceRange { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime ResultDate { get; set; }
}
