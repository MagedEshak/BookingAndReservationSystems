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
    public class LocationConfugration : IEntityTypeConfiguration<Locations>
    {
        public void Configure(EntityTypeBuilder<Locations> builder)
        {
            builder.ToTable("Locations");
            builder.ConfigureByConvention();

            builder.HasMany<Services>(b => b.Services)
                     .WithOne(u => u.Locations)
                     .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
