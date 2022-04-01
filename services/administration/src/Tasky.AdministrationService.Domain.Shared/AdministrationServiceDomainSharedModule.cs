using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Tasky.AdministrationService.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.AuditLogging;
using Volo.Abp.FeatureManagement;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;

namespace Tasky.AdministrationService;

[DependsOn(
    typeof(AbpValidationModule)
)]
[DependsOn(typeof(AbpAuditLoggingDomainSharedModule))]
    [DependsOn(typeof(AbpFeatureManagementDomainSharedModule))]
    [DependsOn(typeof(AbpPermissionManagementDomainSharedModule))]
    [DependsOn(typeof(AbpSettingManagementDomainSharedModule))]
    public class AdministrationServiceDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AdministrationServiceDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<AdministrationServiceResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/AdministrationService");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("AdministrationService", typeof(AdministrationServiceResource));
        });
    }
}
