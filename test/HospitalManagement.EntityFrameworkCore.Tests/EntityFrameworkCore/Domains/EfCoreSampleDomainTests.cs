using HospitalManagement.Samples;
using Xunit;

namespace HospitalManagement.EntityFrameworkCore.Domains;

[Collection(HospitalManagementTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<HospitalManagementEntityFrameworkCoreTestModule>
{

}
