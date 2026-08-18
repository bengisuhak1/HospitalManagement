using System;
using System.Threading.Tasks;
using HospitalManagement.Doctors;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Web.Pages.Doctors;

public class EditModel : HospitalManagementPageModel
{
    private readonly IDoctorAppService _doctorAppService;

    [BindProperty]
    public CreateUpdateDoctorDto Doctor { get; set; } = new();

    public EditModel(IDoctorAppService doctorAppService)
    {
        _doctorAppService = doctorAppService;
    }

    public async Task OnGetAsync(Guid id)
    {
        var doctor = await _doctorAppService.GetAsync(id);

        Doctor = new CreateUpdateDoctorDto
        {
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            Specialty = doctor.Specialty,
            PhoneNumber = doctor.PhoneNumber
        };
    }

    public async Task<IActionResult> OnPostAsync(Guid id)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _doctorAppService.UpdateAsync(id, Doctor);
        return RedirectToPage("./Index");
    }
}