using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HospitalManagement.LabResults;

public class LabResultAppService :
    CrudAppService<
        LabResult,
        LabResultDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateLabResultDto>,
    ILabResultAppService
{
    public LabResultAppService(IRepository<LabResult, Guid> repository)
        : base(repository)
    {
        ObjectMapperContext = typeof(HospitalManagementApplicationModule);
    }
}
