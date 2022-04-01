using Tasky.SaaSService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Tasky.SaaSService;

public abstract class SaaSServiceController : AbpControllerBase
{
    protected SaaSServiceController()
    {
        LocalizationResource = typeof(SaaSServiceResource);
    }
}
