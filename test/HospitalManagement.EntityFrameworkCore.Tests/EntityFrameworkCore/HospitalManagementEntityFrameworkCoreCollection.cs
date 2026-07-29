using Xunit;

namespace HospitalManagement.EntityFrameworkCore;

[CollectionDefinition(HospitalManagementTestConsts.CollectionDefinitionName)]
public class HospitalManagementEntityFrameworkCoreCollection : ICollectionFixture<HospitalManagementEntityFrameworkCoreFixture>
{

}
