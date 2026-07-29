using Microsoft.Extensions.Localization;
using HospitalManagement.Localization;
using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace HospitalManagement.Web;

[Dependency(ReplaceServices = true)]
public class HospitalManagementBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<HospitalManagementResource> _localizer;

    public HospitalManagementBrandingProvider(IStringLocalizer<HospitalManagementResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
