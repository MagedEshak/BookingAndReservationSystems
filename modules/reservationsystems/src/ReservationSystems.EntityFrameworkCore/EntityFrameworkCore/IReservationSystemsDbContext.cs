using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ReservationSystems.EntityFrameworkCore;

[ConnectionStringName(ReservationSystemsDbProperties.ConnectionStringName)]
public interface IReservationSystemsDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
