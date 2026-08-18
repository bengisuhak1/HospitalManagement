using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagement.LabResults;
using HospitalManagement.Patients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;

namespace HospitalManagement.Web.Pages.LabResults;

public class CreateModel : HospitalManagementPageModel
{
    private readonly ILabResultAppService _labResultAppService;
    private readonly IPatientAppService _patientAppService;

    [BindProperty]
    public CreateUpdateLabResultDto LabResult { get; set; } = new();

    public List<SelectListItem> PatientOptions { get; set; } = new();

    public CreateModel(
        ILabResultAppService labResultAppService,
        IPatientAppService patientAppService)
    {
        _labResultAppService = labResultAppService;
        _patientAppService = patientAppService;
    }

    public async Task OnGetAsync()
    {
        LabResult.ResultDate = DateTime.Now;
        await LoadPatientsAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadPatientsAsync();
            return Page();
        }

        await _labResultAppService.CreateAsync(LabResult);
        return RedirectToPage("./Index");
    }

    private async Task LoadPatientsAsync()
    {
        var patients = await _patientAppService.GetListAsync(
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
    }
}
