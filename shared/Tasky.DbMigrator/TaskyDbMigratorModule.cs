using Tasky.AdministrationService;
using Tasky.AdministrationService.EntityFrameworkCore;
using Tasky.IdentityService;
using Tasky.IdentityService.EntityFrameworkCore;
using Tasky.ProjectService;
using Tasky.ProjectService.EntityFrameworkCore;
using Tasky.SaaSService;
using Tasky.SaaSService.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Tasky.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(SaaSServiceEntityFrameworkCoreModule),
    typeof(SaaSServiceApplicationContractsModule),
    typeof(ProjectServiceEntityFrameworkCoreModule),
    typeof(ProjectServiceApplicationContractsModule)
    )]
public class TaskyDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
