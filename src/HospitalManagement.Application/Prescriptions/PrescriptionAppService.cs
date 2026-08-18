using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HospitalManagement.Prescriptions;

public class PrescriptionAppService :
    CrudAppService<
        Prescription,
        PrescriptionDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdatePrescriptionDto>,
    IPrescriptionAppService
{
    public PrescriptionAppService(IRepository<Prescription, Guid> repository)
        : base(repository)
    {
        ObjectMapperContext = typeof(HospitalManagementApplicationModule);
    }
}
