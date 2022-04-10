using Tasky.ProjectService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Tasky.ProjectService.Permissions;

public class ProjectServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var projectGroup = context.AddGroup(ProjectServicePermissions.GroupName, L("Permission:ProjectService"));
        var projectPermission = projectGroup.AddPermission(ProjectServicePermissions.Project.Default, L("Permission:ProjectService:Default"));
        projectPermission.AddChild(ProjectServicePermissions.Project.Create);
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProjectServiceResource>(name);
    }
}
