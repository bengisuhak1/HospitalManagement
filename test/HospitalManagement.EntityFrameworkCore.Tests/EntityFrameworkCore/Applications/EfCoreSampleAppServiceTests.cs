using HospitalManagement.Samples;
using Xunit;

namespace HospitalManagement.EntityFrameworkCore.Applications;

[Collection(HospitalManagementTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<HospitalManagementEntityFrameworkCoreTestModule>
{

}
