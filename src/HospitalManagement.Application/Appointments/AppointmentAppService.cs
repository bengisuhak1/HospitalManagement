using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HospitalManagement.Appointments;

public class AppointmentAppService :
    CrudAppService<
        Appointment,
        AppointmentDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateAppointmentDto>,
    IAppointmentAppService
{
    public AppointmentAppService(
        IRepository<Appointment, Guid> repository)
        : base(repository)
    {
        ObjectMapperContext =
            typeof(HospitalManagementApplicationModule);
    }

    public override async Task<AppointmentDto> CreateAsync(
        CreateUpdateAppointmentDto input)
    {
        if (input.AppointmentDate <= DateTime.Now)
        {
            throw new UserFriendlyException(
                "Geçmiş tarih veya saate randevu oluşturulamaz.");
        }

        var minuteStart = new DateTime(
            input.AppointmentDate.Year,
            input.AppointmentDate.Month,
            input.AppointmentDate.Day,
            input.AppointmentDate.Hour,
            input.AppointmentDate.Minute,
            0,
            input.AppointmentDate.Kind);
        var minuteEnd = minuteStart.AddMinutes(1);

        var hasConflict = await Repository.AnyAsync(appointment =>
            appointment.DoctorId == input.DoctorId &&
            appointment.Status != "İptal" &&
            appointment.AppointmentDate >= minuteStart &&
            appointment.AppointmentDate < minuteEnd);

        if (hasConflict)
        {
            throw new UserFriendlyException(
                "Bu doktorun seçilen tarih ve saatte başka bir randevusu var.");
        }

        return await base.CreateAsync(input);
    }
}
