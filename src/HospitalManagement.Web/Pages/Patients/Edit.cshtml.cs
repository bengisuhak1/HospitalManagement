using System;
using System.Threading.Tasks;
using HospitalManagement.Patients;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Web.Pages.Patients;

public class EditModel : HospitalManagementPageModel
{
    private readonly IPatientAppService _patientAppService;

    [BindProperty]
    public CreateUpdatePatientDto Patient { get; set; } = new();

    public EditModel(IPatientAppService patientAppService)
    {
        _patientAppService = patientAppService;
    }

    public async Task OnGetAsync(Guid id)
    {
        var patient = await _patientAppService.GetAsync(id);

        Patient.IdentityNumber = patient.IdentityNumber;
        Patient.FirstName = patient.FirstName;
        Patient.LastName = patient.LastName;
        Patient.BirthDate = patient.BirthDate;
        Patient.PhoneNumber = patient.PhoneNumber;
    }

    public async Task<IActionResult> OnPostAsync(Guid id)
    {
        await _patientAppService.UpdateAsync(id, Patient);
        return RedirectToPage("./Index");
    }
}