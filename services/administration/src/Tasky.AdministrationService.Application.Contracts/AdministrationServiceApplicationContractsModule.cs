using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;
using Volo.Abp.FeatureManagement;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;

namespace Tasky.AdministrationService;

[DependsOn(
    typeof(AdministrationServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
[DependsOn(typeof(AbpFeatureManagementApplicationContractsModule))]
    [DependsOn(typeof(AbpPermissionManagementApplicationContractsModule))]
    [DependsOn(typeof(AbpSettingManagementApplicationContractsModule))]
    public class AdministrationServiceApplicationContractsModule : AbpModule
{

}
