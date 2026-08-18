using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagement.Appointments;
using HospitalManagement.Doctors;
using HospitalManagement.ExaminationNotes;
using HospitalManagement.LabResults;
using HospitalManagement.Patients;
using HospitalManagement.Prescriptions;
using Volo.Abp.Application.Dtos;

namespace HospitalManagement.Web.Pages.Patients;

public class DetailsModel : HospitalManagementPageModel
{
    private readonly IPatientAppService _patientAppService;
    private readonly IDoctorAppService _doctorAppService;
    private readonly IAppointmentAppService _appointmentAppService;
    private readonly ILabResultAppService _labResultAppService;
    private readonly IPrescriptionAppService _prescriptionAppService;
    private readonly IExaminationNoteAppService _examinationNoteAppService;

    public PatientDto Patient { get; set; } = new();
    public List<AppointmentDto> Appointments { get; set; } = new();
    public List<LabResultDto> LabResults { get; set; } = new();
    public List<PrescriptionDto> Prescriptions { get; set; } = new();
    public List<ExaminationNoteDto> ExaminationNotes { get; set; } = new();
    public Dictionary<Guid, string> DoctorNames { get; set; } = new();

    public DetailsModel(
        IPatientAppService patientAppService,
        IDoctorAppService doctorAppService,
        IAppointmentAppService appointmentAppService,
        ILabResultAppService labResultAppService,
        IPrescriptionAppService prescriptionAppService,
        IExaminationNoteAppService examinationNoteAppService)
    {
        _patientAppService = patientAppService;
        _doctorAppService = doctorAppService;
        _appointmentAppService = appointmentAppService;
        _labResultAppService = labResultAppService;
        _prescriptionAppService = prescriptionAppService;
        _examinationNoteAppService = examinationNoteAppService;
    }

    public async Task OnGetAsync(Guid id)
    {
        Patient = await _patientAppService.GetAsync(id);
        var input = new PagedAndSortedResultRequestDto { MaxResultCount = 100 };

        var doctors = await _doctorAppService.GetListAsync(input);
        var appointments = await _appointmentAppService.GetListAsync(input);
        var labResults = await _labResultAppService.GetListAsync(input);
        var prescriptions = await _prescriptionAppService.GetListAsync(input);
        var notes = await _examinationNoteAppService.GetListAsync(input);

        DoctorNames = doctors.Items.ToDictionary(
            doctor => doctor.Id,
            doctor => $"{doctor.FirstName} {doctor.LastName}");
        Appointments = appointments.Items.Where(item => item.PatientId == id).ToList();
        LabResults = labResults.Items.Where(item => item.PatientId == id).ToList();
        Prescriptions = prescriptions.Items.Where(item => item.PatientId == id).ToList();
        ExaminationNotes = notes.Items.Where(item => item.PatientId == id).ToList();
    }
}
