using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HospitalManagement.Prescriptions;

public interface IPrescriptionAppService :
    ICrudAppService<
        PrescriptionDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdatePrescriptionDto>
{
}
