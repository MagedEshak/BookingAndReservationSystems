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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.ConfigureByConvention();

            builder.HasMany<Bookings>(b=>b.Bookings)
                .WithOne(u=>u.Users)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany<Reviews>(r=>r.Reviews)
                .WithOne(u=>u.Users)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
