using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagement.Doctors;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace HospitalManagement.Web.Pages.Doctors;

public class IndexModel : HospitalManagementPageModel
{
    private readonly IDoctorAppService _doctorAppService;

    public List<DoctorDto> Doctors { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? SearchTerm { get; set; }

    public IndexModel(IDoctorAppService doctorAppService)
    {
        _doctorAppService = doctorAppService;
    }

    public async Task OnGetAsync()
    {
        var result = await _doctorAppService.GetListAsync(
            new PagedAndSortedResultRequestDto
            {
                MaxResultCount = 100,
                Sorting = "FirstName"
            }
        );

        var doctors = result.Items.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(SearchTerm))
        {
            var searchText = SearchTerm.Trim();

            doctors = doctors.Where(doctor =>
                doctor.FirstName.Contains(
                    searchText,
                    StringComparison.OrdinalIgnoreCase
                ) ||
                doctor.LastName.Contains(
                    searchText,
                    StringComparison.OrdinalIgnoreCase
                ) ||
                doctor.Specialty.Contains(
                    searchText,
                    StringComparison.OrdinalIgnoreCase
                ) ||
                doctor.PhoneNumber.Contains(searchText)
            );
        }

        Doctors = doctors.ToList();
    }

    public async Task<IActionResult> OnPostDeleteAsync(Guid id)
    {
        await _doctorAppService.DeleteAsync(id);
        return RedirectToPage();
    }
}