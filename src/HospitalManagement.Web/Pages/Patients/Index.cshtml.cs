
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagement.Patients;
using Volo.Abp.Application.Dtos;

namespace HospitalManagement.Web.Pages.Patients;

public class IndexModel : HospitalManagementPageModel
{
    // Backend'deki hasta işlemlerine ulaşmamızı sağlar.
    private readonly IPatientAppService _patientAppService;

    // Sayfada göstereceğimiz hasta listesi.
    public List<PatientDto> Patients { get; set; } = new();

    // ABP, IPatientAppService nesnesini otomatik olarak buraya verir.
    public IndexModel(IPatientAppService patientAppService)
    {
        _patientAppService = patientAppService;
    }

    // /Patients sayfası açıldığında otomatik çalışır.
    public async Task OnGetAsync()
    {
        var result = await _patientAppService.GetListAsync(
            new PagedAndSortedResultRequestDto
            {
                MaxResultCount = 100,
                Sorting = "FirstName"
            }
        );

        Patients = result.Items.ToList();
    }


    public async Task<IActionResult> OnPostDeleteAsync(Guid id)
{
    await _patientAppService.DeleteAsync(id);
    return RedirectToPage();
}
}