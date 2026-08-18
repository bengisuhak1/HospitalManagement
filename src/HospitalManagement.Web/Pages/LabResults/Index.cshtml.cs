using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagement.LabResults;
using HospitalManagement.Patients;
using Volo.Abp.Application.Dtos;

namespace HospitalManagement.Web.Pages.LabResults;

public class IndexModel : HospitalManagementPageModel
{
    private readonly ILabResultAppService _labResultAppService;
    private readonly IPatientAppService _patientAppService;

    public List<LabResultDto> LabResults { get; set; } = new();

    public Dictionary<Guid, string> PatientNames { get; set; } = new();

    public IndexModel(
        ILabResultAppService labResultAppService,
        IPatientAppService patientAppService)
    {
        _labResultAppService = labResultAppService;
        _patientAppService = patientAppService;
    }

    public async Task OnGetAsync()
    {
        var labResults = await _labResultAppService.GetListAsync(
            new PagedAndSortedResultRequestDto
            {
                MaxResultCount = 100,
                Sorting = "ResultDate desc"
            });

        var patients = await _patientAppService.GetListAsync(
            new PagedAndSortedResultRequestDto { MaxResultCount = 100 });

        LabResults = labResults.Items.ToList();
        PatientNames = patients.Items.ToDictionary(
            patient => patient.Id,
            patient => $"{patient.FirstName} {patient.LastName}");
    }
}
