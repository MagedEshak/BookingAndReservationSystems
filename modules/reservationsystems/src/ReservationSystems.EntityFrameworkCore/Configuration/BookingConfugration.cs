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
    public class BookingConfugration : IEntityTypeConfiguration<Bookings>
    {
        public void Configure(EntityTypeBuilder<Bookings> builder)
        {
            builder.ToTable("Bookings");
            builder.ConfigureByConvention();

            builder.HasOne<User>(u=>u.Users)
                .WithMany(b=>b.Bookings)
                .HasForeignKey(b=>b.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Services>(u=>u.Services)
                .WithMany(b=>b.Bookings)
                .HasForeignKey(b=>b.ServiceID)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
