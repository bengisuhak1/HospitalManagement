using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagement.Doctors;
using HospitalManagement.ExaminationNotes;
using HospitalManagement.Patients;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace HospitalManagement.Web.Pages.ExaminationNotes;

public class IndexModel : HospitalManagementPageModel
{
    private readonly IExaminationNoteAppService _examinationNoteAppService;
    private readonly IPatientAppService _patientAppService;
    private readonly IDoctorAppService _doctorAppService;

    public List<ExaminationNoteDto> ExaminationNotes { get; set; } = new();
    public Dictionary<Guid, string> PatientNames { get; set; } = new();
    public Dictionary<Guid, string> DoctorNames { get; set; } = new();

    public IndexModel(
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
        var input = new PagedAndSortedResultRequestDto { MaxResultCount = 100 };
        var notes = await _examinationNoteAppService.GetListAsync(
            new PagedAndSortedResultRequestDto
            {
                MaxResultCount = 100,
                Sorting = "ExaminationDate desc"
            });
        var patients = await _patientAppService.GetListAsync(input);
        var doctors = await _doctorAppService.GetListAsync(input);

        ExaminationNotes = notes.Items.ToList();
        PatientNames = patients.Items.ToDictionary(
            patient => patient.Id,
            patient => $"{patient.FirstName} {patient.LastName}");
        DoctorNames = doctors.Items.ToDictionary(
            doctor => doctor.Id,
            doctor => $"{doctor.FirstName} {doctor.LastName}");
    }

    public async Task<IActionResult> OnPostDeleteAsync(Guid id)
    {
        await _examinationNoteAppService.DeleteAsync(id);
        return RedirectToPage();
    }
}
