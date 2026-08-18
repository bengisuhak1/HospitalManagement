using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HospitalManagement.Doctors;

public interface IDoctorAppService :
    ICrudAppService<
        DoctorDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateDoctorDto>
{
}