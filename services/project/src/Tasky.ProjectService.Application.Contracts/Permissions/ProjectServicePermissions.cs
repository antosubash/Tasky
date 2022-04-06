using Volo.Abp.Reflection;

namespace Tasky.ProjectService.Permissions;

public class ProjectServicePermissions
{
    public const string GroupName = "ProjectService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ProjectServicePermissions));
    }
}
