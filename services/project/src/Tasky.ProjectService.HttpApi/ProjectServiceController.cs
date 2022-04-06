using Tasky.ProjectService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Tasky.ProjectService;

public abstract class ProjectServiceController : AbpControllerBase
{
    protected ProjectServiceController()
    {
        LocalizationResource = typeof(ProjectServiceResource);
    }
}
