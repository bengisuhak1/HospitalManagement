using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;
using HospitalManagement.Patients;

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