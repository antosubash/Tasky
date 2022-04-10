using Tasky.ProjectService.Localization;
using Volo.Abp.Application.Services;

namespace Tasky.ProjectService;

public abstract class ProjectServiceAppService : ApplicationService
{
    protected ProjectServiceAppService()
    {
        LocalizationResource = typeof(ProjectServiceResource);
        ObjectMapperContext = typeof(ProjectServiceApplicationModule);
    }
}
