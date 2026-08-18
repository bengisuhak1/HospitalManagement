using System.Threading.Tasks;
using HospitalManagement.Doctors;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Web.Pages.Doctors;

public class CreateModel : HospitalManagementPageModel
{
    private readonly IDoctorAppService _doctorAppService;

    [BindProperty]
    public CreateUpdateDoctorDto Doctor { get; set; } = new();

    public CreateModel(IDoctorAppService doctorAppService)
    {
        _doctorAppService = doctorAppService;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _doctorAppService.CreateAsync(Doctor);
        return RedirectToPage("./Index");
    }
}