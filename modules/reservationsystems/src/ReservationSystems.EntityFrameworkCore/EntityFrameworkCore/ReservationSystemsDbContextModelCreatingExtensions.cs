using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using ReservationSystems.Models;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ReservationSystems.EntityFrameworkCore;

public static class ReservationSystemsDbContextModelCreatingExtensions
{
    public static void ConfigureReservationSystems(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:*/

        builder.Entity<User>(u =>
        {
            //Configure table & schema name
            //b.ToTable(ReservationSystemsDbProperties.DbTablePrefix + "Questions", ReservationSystemsDbProperties.DbSchema);
            u.ConfigureByConvention();
            u.HasIndex(e => e.Email).IsUnique();
            u.HasIndex(p => p.Phone).IsUnique();
        });

        builder.Entity<Services>(s =>
        {
            //Configure table & schema name
            //b.ToTable(ReservationSystemsDbProperties.DbTablePrefix + "Questions", ReservationSystemsDbProperties.DbSchema);
            s.ConfigureByConvention();
            s.Property(p => p.Price)
            .HasColumnType("decimal(18,2)");
        });
    }
}
