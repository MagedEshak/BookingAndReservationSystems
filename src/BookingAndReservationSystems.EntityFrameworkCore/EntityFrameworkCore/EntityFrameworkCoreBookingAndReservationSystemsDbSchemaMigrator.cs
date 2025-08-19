using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookingAndReservationSystems.Data;
using Volo.Abp.DependencyInjection;

namespace BookingAndReservationSystems.EntityFrameworkCore;

public class EntityFrameworkCoreBookingAndReservationSystemsDbSchemaMigrator
    : IBookingAndReservationSystemsDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreBookingAndReservationSystemsDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the BookingAndReservationSystemsDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BookingAndReservationSystemsDbContext>()
            .Database
            .MigrateAsync();
    }
}
