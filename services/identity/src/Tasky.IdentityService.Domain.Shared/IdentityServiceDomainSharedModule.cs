using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Tasky.IdentityService.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;

namespace Tasky.IdentityService;

[DependsOn(
    typeof(AbpValidationModule)
)]
[DependsOn(typeof(AbpIdentityDomainSharedModule))]
    [DependsOn(typeof(AbpIdentityServerDomainSharedModule))]
    public class IdentityServiceDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<IdentityServiceDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<IdentityServiceResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/IdentityService");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("IdentityService", typeof(IdentityServiceResource));
        });
    }
}
