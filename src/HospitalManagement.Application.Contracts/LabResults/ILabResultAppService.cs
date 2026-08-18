using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HospitalManagement.LabResults;

public interface ILabResultAppService :
    ICrudAppService<
        LabResultDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateLabResultDto>
{
}
