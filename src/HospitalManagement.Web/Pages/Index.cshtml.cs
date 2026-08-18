using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagement.Doctors;
using HospitalManagement.Patients;
using HospitalManagement.Appointments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace HospitalManagement.Web.Pages;

public class IndexModel : HospitalManagementPageModel
{
    private readonly IDoctorAppService _doctorAppService;
    private readonly IPatientAppService _patientAppService;
    private readonly IAppointmentAppService _appointmentAppService;

    public List<DoctorDto> Doctors { get; set; } = new();
    public long PatientCount { get; set; }
    public long DoctorCount { get; set; }
    public long AppointmentCount { get; set; }

    public IndexModel(
        IDoctorAppService doctorAppService,
        IPatientAppService patientAppService,
        IAppointmentAppService appointmentAppService)
    {
        _doctorAppService = doctorAppService;
        _patientAppService = patientAppService;
        _appointmentAppService = appointmentAppService;
    }

    public async Task OnGetAsync()
    {
        var result = await _doctorAppService.GetListAsync(
            new PagedAndSortedResultRequestDto
            {
                MaxResultCount = 100,
                Sorting = "FirstName"
            });

        Doctors = result.Items.ToList();

        var countRequest = new PagedAndSortedResultRequestDto { MaxResultCount = 1 };
        var patients = await _patientAppService.GetListAsync(countRequest);
        var appointments = await _appointmentAppService.GetListAsync(countRequest);

        PatientCount = patients.TotalCount;
        DoctorCount = result.TotalCount;
        AppointmentCount = appointments.TotalCount;
    }

    public IActionResult OnPostSelectDoctor(Guid doctorId, string doctorName)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            SameSite = SameSiteMode.Lax,
            Expires = DateTimeOffset.Now.AddHours(8)
        };

        Response.Cookies.Append("SelectedDoctorId", doctorId.ToString(), cookieOptions);
        Response.Cookies.Append("SelectedDoctorName", doctorName, cookieOptions);

        return RedirectToPage("/Patients/Index");
    }
}
