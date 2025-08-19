using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ReservationSystems.Configuration
{
    public class ServicesConfiguration : IEntityTypeConfiguration<Services>
    {
        public void Configure(EntityTypeBuilder<Services> builder)
        {
            builder.ToTable("Services");
            builder.ConfigureByConvention();

            builder.HasOne<Locations>(u => u.Locations)
                .WithMany(b => b.Services)
                .HasForeignKey(b => b.LocationID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany<Bookings>(b => b.Bookings)
                    .WithOne(u => u.Services)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany<Reviews>(b => b.Reviews)
                    .WithOne(u => u.Services)
                    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
