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
    public class ReviewsConfiguration : IEntityTypeConfiguration<Reviews>
    {
        public void Configure(EntityTypeBuilder<Reviews> builder)
        {
            builder.ToTable("Reviews");
            builder.ConfigureByConvention();

            builder.HasOne<User>(u => u.Users)
                           .WithMany(b => b.Reviews)
                           .HasForeignKey(b => b.UserID)
                           .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Services>(u => u.Services)
                .WithMany(b => b.Reviews)
                .HasForeignKey(b => b.ServiceID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
