using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Tasky.ProjectService.EntityFrameworkCore;

public class ProjectServiceHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<ProjectServiceDbContext>
{
    public ProjectServiceDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ProjectServiceDbContext>()
            .UseNpgsql(configuration.GetConnectionString("ProjectService"));

        return new ProjectServiceDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
