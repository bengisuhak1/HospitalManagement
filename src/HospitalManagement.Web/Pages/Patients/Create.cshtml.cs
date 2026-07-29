using System.Threading.Tasks;
using HospitalManagement.Patients;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Web.Pages.Patients;

public class CreateModel : HospitalManagementPageModel
{
    private readonly IPatientAppService _patientAppService;

    // Formdaki bilgileri bu nesnede toplayacağız.
    [BindProperty]
    public CreateUpdatePatientDto Patient { get; set; } = new();

    public CreateModel(IPatientAppService patientAppService)
    {
        _patientAppService = patientAppService;
    }

    // Kullanıcı formu gönderdiğinde çalışır.
    public async Task<IActionResult> OnPostAsync()
    {
        // Formdan gelen hasta bilgilerini backend'e gönderir.
        await _patientAppService.CreateAsync(Patient);

        // Kayıt tamamlanınca hasta listesine geri döner.
        return RedirectToPage("./Index");
    }
}
