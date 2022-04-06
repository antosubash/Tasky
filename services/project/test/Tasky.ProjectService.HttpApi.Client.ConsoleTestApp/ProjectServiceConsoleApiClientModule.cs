using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Tasky.ProjectService;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ProjectServiceHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class ProjectServiceConsoleApiClientModule : AbpModule
{

}
