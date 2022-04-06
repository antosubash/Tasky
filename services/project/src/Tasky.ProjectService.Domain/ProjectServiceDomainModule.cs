using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Tasky.ProjectService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ProjectServiceDomainSharedModule)
)]
public class ProjectServiceDomainModule : AbpModule
{

}
