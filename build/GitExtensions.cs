using Nuke.Common.Git;
using Nuke.Common.Utilities;

public static class GitExtensions
{
    public static bool IsOnIssueBranch(this GitRepository repository)
    {
        return (repository.Branch?.StartsWithOrdinalIgnoreCase("issue/") ?? false) ||
               (repository.Branch?.StartsWithOrdinalIgnoreCase("issues/") ?? false);
    }
}