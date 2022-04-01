using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Tasky.SaaSService.EntityFrameworkCore;

[ConnectionStringName(SaaSServiceDbProperties.ConnectionStringName)]
public interface ISaaSServiceDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
