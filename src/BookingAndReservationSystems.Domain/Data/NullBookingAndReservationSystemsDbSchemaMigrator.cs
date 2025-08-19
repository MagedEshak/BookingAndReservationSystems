using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BookingAndReservationSystems.Data;

/* This is used if database provider does't define
 * IBookingAndReservationSystemsDbSchemaMigrator implementation.
 */
public class NullBookingAndReservationSystemsDbSchemaMigrator : IBookingAndReservationSystemsDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
