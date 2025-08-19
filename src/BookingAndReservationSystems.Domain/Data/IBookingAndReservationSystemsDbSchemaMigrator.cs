using System.Threading.Tasks;

namespace BookingAndReservationSystems.Data;

public interface IBookingAndReservationSystemsDbSchemaMigrator
{
    Task MigrateAsync();
}
