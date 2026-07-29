using Volo.Abp.Modularity;

namespace HospitalManagement;

/* Inherit from this class for your domain layer tests. */
public abstract class HospitalManagementDomainTestBase<TStartupModule> : HospitalManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
