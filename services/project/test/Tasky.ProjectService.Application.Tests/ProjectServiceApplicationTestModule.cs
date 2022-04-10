using Volo.Abp.Modularity;

namespace Tasky.ProjectService;

[DependsOn(
    typeof(ProjectServiceApplicationModule),
    typeof(ProjectServiceDomainTestModule)
    )]
public class ProjectServiceApplicationTestModule : AbpModule
{

}
