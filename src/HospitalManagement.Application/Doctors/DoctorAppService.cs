using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HospitalManagement.Doctors;

public class DoctorAppService :
    CrudAppService<
        Doctor,
        DoctorDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateDoctorDto>,
    IDoctorAppService
{
    public DoctorAppService(IRepository<Doctor, Guid> repository)
        : base(repository)
    {
        ObjectMapperContext = typeof(HospitalManagementApplicationModule);
    }
}