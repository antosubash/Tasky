using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.AuditLogging;
using Volo.Abp.FeatureManagement;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;

namespace Tasky.AdministrationService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AdministrationServiceDomainSharedModule)
)]
[DependsOn(typeof(AbpAuditLoggingDomainModule))]
    [DependsOn(typeof(AbpFeatureManagementDomainModule))]
    [DependsOn(typeof(AbpPermissionManagementDomainModule))]
    [DependsOn(typeof(AbpSettingManagementDomainModule))]
    public class AdministrationServiceDomainModule : AbpModule
{

}
