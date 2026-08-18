using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagement.Appointments;
using HospitalManagement.Doctors;
using HospitalManagement.Patients;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace HospitalManagement.Web.Pages.Appointments;

public class IndexModel : HospitalManagementPageModel
{
    private readonly IAppointmentAppService _appointmentAppService;
    private readonly IPatientAppService _patientAppService;
    private readonly IDoctorAppService _doctorAppService;

    public List<AppointmentDto> Appointments { get; set; } = new();

    public Dictionary<Guid, string> PatientNames { get; set; } = new();

    public Dictionary<Guid, string> DoctorNames { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public DateTime? SelectedDate { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? SelectedStatus { get; set; }

    public IndexModel(
        IAppointmentAppService appointmentAppService,
        IPatientAppService patientAppService,
        IDoctorAppService doctorAppService)
    {
        _appointmentAppService = appointmentAppService;
        _patientAppService = patientAppService;
        _doctorAppService = doctorAppService;
    }

    public async Task OnGetAsync()
    {
        var appointments =
            await _appointmentAppService.GetListAsync(
                new PagedAndSortedResultRequestDto
                {
                    MaxResultCount = 100,
                    Sorting = "AppointmentDate"
                });

        var patients =
            await _patientAppService.GetListAsync(
                new PagedAndSortedResultRequestDto
                {
                    MaxResultCount = 100
                });

        var doctors =
            await _doctorAppService.GetListAsync(
                new PagedAndSortedResultRequestDto
                {
                    MaxResultCount = 100
                });

        Guid.TryParse(Request.Cookies["SelectedDoctorId"], out var selectedDoctorId);

        Appointments = appointments.Items
            .Where(appointment =>
                selectedDoctorId == Guid.Empty ||
                appointment.DoctorId == selectedDoctorId)
            .Where(appointment =>
                !SelectedDate.HasValue ||
                appointment.AppointmentDate.Date == SelectedDate.Value.Date)
            .Where(appointment =>
                string.IsNullOrWhiteSpace(SelectedStatus) ||
                appointment.Status == SelectedStatus)
            .ToList();

        PatientNames = patients.Items.ToDictionary(
            patient => patient.Id,
            patient => $"{patient.FirstName} {patient.LastName}");

        DoctorNames = doctors.Items.ToDictionary(
            doctor => doctor.Id,
            doctor => $"{doctor.FirstName} {doctor.LastName}");
    }

    public async Task<IActionResult> OnPostCancelAsync(Guid id)
    {
        var appointment = await _appointmentAppService.GetAsync(id);

        await _appointmentAppService.UpdateAsync(
            id,
            new CreateUpdateAppointmentDto
            {
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                AppointmentDate = appointment.AppointmentDate,
                Status = "İptal",
                Notes = appointment.Notes
            });

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostCompleteAsync(Guid id)
    {
        var appointment = await _appointmentAppService.GetAsync(id);

        await _appointmentAppService.UpdateAsync(
            id,
            new CreateUpdateAppointmentDto
            {
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                AppointmentDate = appointment.AppointmentDate,
                Status = "Tamamlandı",
                Notes = appointment.Notes
            });

        return RedirectToPage();
    }
}
