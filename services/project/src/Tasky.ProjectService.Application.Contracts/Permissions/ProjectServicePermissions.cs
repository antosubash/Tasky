using Volo.Abp.Reflection;

namespace Tasky.ProjectService.Permissions;

public class ProjectServicePermissions
{
    public const string GroupName = "ProjectService";

    public static class Project
    {
        public const string Default = GroupName + ".Project";
        public const string Create = Default + ".Create";
    }

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ProjectServicePermissions));
    }
}
