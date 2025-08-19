using Volo.Abp.Modularity;

namespace BookingAndReservationSystems;

[DependsOn(
    typeof(BookingAndReservationSystemsDomainModule),
    typeof(BookingAndReservationSystemsTestBaseModule)
)]
public class BookingAndReservationSystemsDomainTestModule : AbpModule
{

}
