using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagement.Doctors;
using HospitalManagement.Patients;
using HospitalManagement.Prescriptions;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace HospitalManagement.Web.Pages.Prescriptions;

public class IndexModel : HospitalManagementPageModel
{
    private readonly IPrescriptionAppService _prescriptionAppService;
    private readonly IPatientAppService _patientAppService;
    private readonly IDoctorAppService _doctorAppService;

    public List<PrescriptionDto> Prescriptions { get; set; } = new();
    public Dictionary<Guid, string> PatientNames { get; set; } = new();
    public Dictionary<Guid, string> DoctorNames { get; set; } = new();

    public IndexModel(
        IPrescriptionAppService prescriptionAppService,
        IPatientAppService patientAppService,
        IDoctorAppService doctorAppService)
    {
        _prescriptionAppService = prescriptionAppService;
        _patientAppService = patientAppService;
        _doctorAppService = doctorAppService;
    }

    public async Task OnGetAsync()
    {
        var input = new PagedAndSortedResultRequestDto { MaxResultCount = 100 };
        var prescriptions = await _prescriptionAppService.GetListAsync(
            new PagedAndSortedResultRequestDto
            {
                MaxResultCount = 100,
                Sorting = "PrescriptionDate desc"
            });
        var patients = await _patientAppService.GetListAsync(input);
        var doctors = await _doctorAppService.GetListAsync(input);

        Prescriptions = prescriptions.Items.ToList();
        PatientNames = patients.Items.ToDictionary(
            patient => patient.Id,
            patient => $"{patient.FirstName} {patient.LastName}");
        DoctorNames = doctors.Items.ToDictionary(
            doctor => doctor.Id,
            doctor => $"{doctor.FirstName} {doctor.LastName}");
    }

    public async Task<IActionResult> OnPostDeleteAsync(Guid id)
    {
        await _prescriptionAppService.DeleteAsync(id);
        return RedirectToPage();
    }
}
