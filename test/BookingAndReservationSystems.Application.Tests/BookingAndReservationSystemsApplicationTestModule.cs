using Volo.Abp.Modularity;

namespace BookingAndReservationSystems;

[DependsOn(
    typeof(BookingAndReservationSystemsApplicationModule),
    typeof(BookingAndReservationSystemsDomainTestModule)
)]
public class BookingAndReservationSystemsApplicationTestModule : AbpModule
{

}
