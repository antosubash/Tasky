using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Tasky.ProjectService.EntityFrameworkCore
{
    public class ProjectServiceDbContextFactory : IDesignTimeDbContextFactory<ProjectServiceDbContext>
    {
        public ProjectServiceDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ProjectServiceDbContext>()
                .UseNpgsql(GetConnectionStringFromConfiguration());

            return new ProjectServiceDbContext(builder.Options);
        }

        private static string GetConnectionStringFromConfiguration()
        {
            return BuildConfiguration()
                .GetConnectionString(ProjectServiceDbProperties.ConnectionStringName);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(
                    Path.Combine(
                        Directory.GetParent(Directory.GetCurrentDirectory())?.Parent!.FullName!,
                        $"host{Path.DirectorySeparatorChar}Tasky.ProjectService.HttpApi.Host"
                    )
                )
                .AddJsonFile("appsettings.json", false);

            return builder.Build();
        }
    }
}
