using Volo.Abp.Modularity;

namespace BookingAndReservationSystems;

public abstract class BookingAndReservationSystemsApplicationTestBase<TStartupModule> : BookingAndReservationSystemsTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
