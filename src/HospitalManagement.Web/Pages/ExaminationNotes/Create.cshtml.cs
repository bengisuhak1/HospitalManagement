using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagement.Doctors;
using HospitalManagement.ExaminationNotes;
using HospitalManagement.Patients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;

namespace HospitalManagement.Web.Pages.ExaminationNotes;

public class CreateModel : HospitalManagementPageModel
{
    private readonly IExaminationNoteAppService _examinationNoteAppService;
    private readonly IPatientAppService _patientAppService;
    private readonly IDoctorAppService _doctorAppService;

    [BindProperty]
    public CreateUpdateExaminationNoteDto ExaminationNote { get; set; } = new();

    public List<SelectListItem> PatientOptions { get; set; } = new();
    public List<SelectListItem> DoctorOptions { get; set; } = new();

    public CreateModel(
        IExaminationNoteAppService examinationNoteAppService,
        IPatientAppService patientAppService,
        IDoctorAppService doctorAppService)
    {
        _examinationNoteAppService = examinationNoteAppService;
        _patientAppService = patientAppService;
        _doctorAppService = doctorAppService;
    }

    public async Task OnGetAsync()
    {
        ExaminationNote.ExaminationDate = DateTime.Now;
        if (Guid.TryParse(Request.Cookies["SelectedDoctorId"], out var doctorId))
        {
            ExaminationNote.DoctorId = doctorId;
        }

        await LoadOptionsAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadOptionsAsync();
            return Page();
        }

        await _examinationNoteAppService.CreateAsync(ExaminationNote);
        return RedirectToPage("./Index");
    }

    private async Task LoadOptionsAsync()
    {
        var input = new PagedAndSortedResultRequestDto
        {
            MaxResultCount = 100,
            Sorting = "FirstName"
        };
        var patients = await _patientAppService.GetListAsync(input);
        var doctors = await _doctorAppService.GetListAsync(input);

        PatientOptions = patients.Items.Select(patient => new SelectListItem(
            $"{patient.FirstName} {patient.LastName}",
            patient.Id.ToString())).ToList();
        DoctorOptions = doctors.Items.Select(doctor => new SelectListItem(
            $"{doctor.FirstName} {doctor.LastName} - {doctor.Specialty}",
            doctor.Id.ToString())).ToList();
    }
}
