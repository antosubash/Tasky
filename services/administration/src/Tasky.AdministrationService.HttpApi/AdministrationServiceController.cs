using Tasky.AdministrationService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Tasky.AdministrationService;

public abstract class AdministrationServiceController : AbpControllerBase
{
    protected AdministrationServiceController()
    {
        LocalizationResource = typeof(AdministrationServiceResource);
    }
}
