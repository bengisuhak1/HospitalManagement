
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
    // Kullanıcının arama kutusuna yazdığı metin.
[BindProperty(SupportsGet = true)]
public string? SearchTerm { get; set; }

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

    var patients = result.Items.AsEnumerable();

    if (!string.IsNullOrWhiteSpace(SearchTerm))
    {
        var searchText = SearchTerm.Trim();

        patients = patients.Where(patient =>
            patient.FirstName.Contains(
                searchText,
                StringComparison.OrdinalIgnoreCase
            ) ||
            patient.LastName.Contains(
                searchText,
                StringComparison.OrdinalIgnoreCase
            ) ||
            patient.IdentityNumber.Contains(searchText) ||
            patient.PhoneNumber.Contains(searchText)
        );
    }

    Patients = patients.ToList();
}

    public async Task<IActionResult> OnPostDeleteAsync(Guid id)
{
    await _patientAppService.DeleteAsync(id);
    return RedirectToPage();
}
}