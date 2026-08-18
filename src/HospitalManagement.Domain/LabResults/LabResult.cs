using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace HospitalManagement.LabResults;

// Bir hastaya ait laboratuvar tahlil sonucunu temsil eder.
public class LabResult : FullAuditedAggregateRoot<Guid>
{
    public Guid PatientId { get; set; }

    public string TestName { get; set; } = string.Empty;

    public string ResultValue { get; set; } = string.Empty;

    public string Unit { get; set; } = string.Empty;

    public string ReferenceRange { get; set; } = string.Empty;

    public string Status { get; set; } = "Normal";

    public DateTime ResultDate { get; set; }

    // EF Core için boş constructor.
    public LabResult()
    {
    }

    public LabResult(
        Guid id,
        Guid patientId,
        string testName,
        string resultValue,
        string unit,
        string referenceRange,
        string status,
        DateTime resultDate) : base(id)
    {
        PatientId = patientId;
        TestName = testName;
        ResultValue = resultValue;
        Unit = unit;
        ReferenceRange = referenceRange;
        Status = status;
        ResultDate = resultDate;
    }
}
