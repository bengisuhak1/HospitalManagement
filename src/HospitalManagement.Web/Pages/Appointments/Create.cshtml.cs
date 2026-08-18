using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagement.Appointments;
using HospitalManagement.Doctors;
using HospitalManagement.Patients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace HospitalManagement.Web.Pages.Appointments;

public class CreateModel : HospitalManagementPageModel
{
    private readonly IAppointmentAppService _appointmentAppService;
    private readonly IPatientAppService _patientAppService;
    private readonly IDoctorAppService _doctorAppService;

    [BindProperty]
    public CreateUpdateAppointmentDto Appointment { get; set; } = new();

    public List<SelectListItem> PatientOptions { get; set; } = new();
    public List<SelectListItem> DoctorOptions { get; set; } = new();

    public CreateModel(
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
        await LoadOptionsAsync();

        if (Guid.TryParse(Request.Cookies["SelectedDoctorId"], out var selectedDoctorId) &&
            DoctorOptions.Any(option => option.Value == selectedDoctorId.ToString()))
        {
            Appointment.DoctorId = selectedDoctorId;
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadOptionsAsync();
            return Page();
        }

        try
        {
            await _appointmentAppService.CreateAsync(Appointment);
            return RedirectToPage("./Index");
        }
        catch (UserFriendlyException exception)
        {
            ModelState.AddModelError(string.Empty, exception.Message);
            await LoadOptionsAsync();
            return Page();
        }
    }

    private async Task LoadOptionsAsync()
    {
        var patients = await _patientAppService.GetListAsync(
            new PagedAndSortedResultRequestDto
            {
                MaxResultCount = 100,
                Sorting = "FirstName"
            });

        var doctors = await _doctorAppService.GetListAsync(
            new PagedAndSortedResultRequestDto
            {
                MaxResultCount = 100,
                Sorting = "FirstName"
            });

        PatientOptions = patients.Items
            .Select(patient => new SelectListItem(
                $"{patient.FirstName} {patient.LastName}",
                patient.Id.ToString()))
            .ToList();

        DoctorOptions = doctors.Items
            .Select(doctor => new SelectListItem(
                $"{doctor.FirstName} {doctor.LastName} - {doctor.Specialty}",
                doctor.Id.ToString()))
            .ToList();
    }
}
