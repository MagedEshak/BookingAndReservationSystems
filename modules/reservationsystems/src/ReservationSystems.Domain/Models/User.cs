using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace ReservationSystems.Models
{
    public class User : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid? TenantId { get; set; }
        public ICollection<Bookings> Bookings { get; set; } = new List<Bookings>();
        public ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();

        public User() { }
        public User(string name,
                    string email,
                    string phone,
                    Guid? tenantId,
                     bool isDeleted,
                    string concurrencyStamp
            )
        {
            Name = name;
            Email = email;
            Phone = phone;
            TenantId = tenantId;
            IsDeleted = isDeleted;
            ConcurrencyStamp = concurrencyStamp;
            Bookings = new List<Bookings>();

        }
    }
}
