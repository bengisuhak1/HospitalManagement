using Volo.Abp.Modularity;

namespace HospitalManagement;

public abstract class HospitalManagementApplicationTestBase<TStartupModule> : HospitalManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
