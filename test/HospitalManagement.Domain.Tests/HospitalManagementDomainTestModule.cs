using Volo.Abp.Modularity;

namespace HospitalManagement;

[DependsOn(
    typeof(HospitalManagementDomainModule),
    typeof(HospitalManagementTestBaseModule)
)]
public class HospitalManagementDomainTestModule : AbpModule
{

}
