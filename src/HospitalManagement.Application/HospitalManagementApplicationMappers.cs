using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;
using HospitalManagement.Patients;
using HospitalManagement.Doctors;
using HospitalManagement.Appointments;
using HospitalManagement.LabResults;
using HospitalManagement.Prescriptions;
using HospitalManagement.ExaminationNotes;
namespace HospitalManagement;

[Mapper]
public partial class HospitalManagementApplicationMappers
{
    /* You can configure your Mapperly mapping configuration here.
     * Alternatively, you can split your mapping configurations
     * into multiple mapper classes for a better organization. */
}
[Mapper]
public partial class PatientToPatientDtoMapper
    : MapperBase<Patient, PatientDto>
{
    public override partial PatientDto Map(Patient source);

    public override partial void Map(Patient source, PatientDto destination);
}

[Mapper]
public partial class CreateUpdatePatientDtoToPatientMapper
    : MapperBase<CreateUpdatePatientDto, Patient>
{
    public override partial Patient Map(CreateUpdatePatientDto source);

    public override partial void Map(
        CreateUpdatePatientDto source,
        Patient destination
    );
}
[Mapper]
public partial class DoctorToDoctorDtoMapper
    : MapperBase<Doctor, DoctorDto>
{
    public override partial DoctorDto Map(Doctor source);

    public override partial void Map(
        Doctor source,
        DoctorDto destination
    );
}

[Mapper]
public partial class CreateUpdateDoctorDtoToDoctorMapper
    : MapperBase<CreateUpdateDoctorDto, Doctor>
{
    public override partial Doctor Map(CreateUpdateDoctorDto source);

    public override partial void Map(
        CreateUpdateDoctorDto source,
        Doctor destination
    );
}
[Mapper]
public partial class AppointmentToAppointmentDtoMapper
    : MapperBase<Appointment, AppointmentDto>
{
    public override partial AppointmentDto Map(Appointment source);

    public override partial void Map(
        Appointment source,
        AppointmentDto destination
    );
}

[Mapper]
public partial class CreateUpdateAppointmentDtoToAppointmentMapper
    : MapperBase<CreateUpdateAppointmentDto, Appointment>
{
    public override partial Appointment Map(
        CreateUpdateAppointmentDto source
    );

    public override partial void Map(
        CreateUpdateAppointmentDto source,
        Appointment destination
    );
}

[Mapper]
public partial class LabResultToLabResultDtoMapper
    : MapperBase<LabResult, LabResultDto>
{
    public override partial LabResultDto Map(LabResult source);

    public override partial void Map(
        LabResult source,
        LabResultDto destination
    );
}

[Mapper]
public partial class CreateUpdateLabResultDtoToLabResultMapper
    : MapperBase<CreateUpdateLabResultDto, LabResult>
{
    public override partial LabResult Map(CreateUpdateLabResultDto source);

    public override partial void Map(
        CreateUpdateLabResultDto source,
        LabResult destination
    );
}

[Mapper]
public partial class PrescriptionToPrescriptionDtoMapper
    : MapperBase<Prescription, PrescriptionDto>
{
    public override partial PrescriptionDto Map(Prescription source);

    public override partial void Map(
        Prescription source,
        PrescriptionDto destination
    );
}

[Mapper]
public partial class CreateUpdatePrescriptionDtoToPrescriptionMapper
    : MapperBase<CreateUpdatePrescriptionDto, Prescription>
{
    public override partial Prescription Map(CreateUpdatePrescriptionDto source);

    public override partial void Map(
        CreateUpdatePrescriptionDto source,
        Prescription destination
    );
}

[Mapper]
public partial class ExaminationNoteToExaminationNoteDtoMapper
    : MapperBase<ExaminationNote, ExaminationNoteDto>
{
    public override partial ExaminationNoteDto Map(ExaminationNote source);

    public override partial void Map(
        ExaminationNote source,
        ExaminationNoteDto destination
    );
}

[Mapper]
public partial class CreateUpdateExaminationNoteDtoToExaminationNoteMapper
    : MapperBase<CreateUpdateExaminationNoteDto, ExaminationNote>
{
    public override partial ExaminationNote Map(CreateUpdateExaminationNoteDto source);

    public override partial void Map(
        CreateUpdateExaminationNoteDto source,
        ExaminationNote destination
    );
}
