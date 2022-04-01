using Tasky.SaaSService.Localization;
using Volo.Abp.Application.Services;

namespace Tasky.SaaSService;

public abstract class SaaSServiceAppService : ApplicationService
{
    protected SaaSServiceAppService()
    {
        LocalizationResource = typeof(SaaSServiceResource);
        ObjectMapperContext = typeof(SaaSServiceApplicationModule);
    }
}
