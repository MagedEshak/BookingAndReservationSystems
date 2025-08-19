using Volo.Abp.Modularity;

namespace BookingAndReservationSystems;

/* Inherit from this class for your domain layer tests. */
public abstract class BookingAndReservationSystemsDomainTestBase<TStartupModule> : BookingAndReservationSystemsTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
