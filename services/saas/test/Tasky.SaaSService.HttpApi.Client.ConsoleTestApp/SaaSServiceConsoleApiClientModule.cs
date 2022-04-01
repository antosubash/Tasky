using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Tasky.SaaSService;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SaaSServiceHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class SaaSServiceConsoleApiClientModule : AbpModule
{

}
