using BookingAndReservationSystems.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace BookingAndReservationSystems.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BookingAndReservationSystemsEntityFrameworkCoreModule),
    typeof(BookingAndReservationSystemsApplicationContractsModule)
)]
public class BookingAndReservationSystemsDbMigratorModule : AbpModule
{
}
