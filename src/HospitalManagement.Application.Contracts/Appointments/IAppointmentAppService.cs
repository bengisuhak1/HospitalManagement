using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HospitalManagement.Appointments;

public interface IAppointmentAppService :
    ICrudAppService<
        AppointmentDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateAppointmentDto>
{
}