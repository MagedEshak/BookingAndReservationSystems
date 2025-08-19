using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BookingAndReservationSystems.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class BookingAndReservationSystemsDbContextFactory : IDesignTimeDbContextFactory<BookingAndReservationSystemsDbContext>
{

    public BookingAndReservationSystemsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        BookingAndReservationSystemsEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<BookingAndReservationSystemsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new BookingAndReservationSystemsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BookingAndReservationSystems.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
