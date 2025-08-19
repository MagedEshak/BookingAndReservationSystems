using Microsoft.EntityFrameworkCore;
using ReservationSystems.Configuration;
using ReservationSystems.Models;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ReservationSystems.EntityFrameworkCore;

[ConnectionStringName(ReservationSystemsDbProperties.ConnectionStringName)]
public class ReservationSystemsDbContext : AbpDbContext<ReservationSystemsDbContext>, IReservationSystemsDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */
    public DbSet<User> User { get; set; }
    public DbSet<Services> Services { get; set; }
    public DbSet<Bookings> Bookings { get; set; }
    public DbSet<Locations> Locations { get; set; }
    public DbSet<Reviews> Reviews { get; set; }
    public ReservationSystemsDbContext(DbContextOptions<ReservationSystemsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureReservationSystems();
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new BookingConfugration());
        builder.ApplyConfiguration(new ServicesConfiguration());
        builder.ApplyConfiguration(new LocationConfugration());
        builder.ApplyConfiguration(new ReviewsConfiguration());
    }
}
