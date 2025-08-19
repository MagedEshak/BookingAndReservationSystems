using ReservationSystems.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReservationSystems.Models
{
    public class Locations : Entity<Guid>, ISoftDelete, IMultiTenant, IHasConcurrencyStamp
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Guid? TenantId { get; set; }
        public bool IsDeleted { get; set; }
        public string ConcurrencyStamp { get; set; }
        public ICollection<Services> Services { get; set; } = new List<Services>();
        public Locations() { }
        public Locations(string name,
                   string address,
                    string city,
                    string country,
                    Guid? tenantId,
                    bool isDeleted,
                    string concurrencyStamp
            )
        {
            Name = name;
            Address = address;
            City = city;
            Country = country;
            TenantId = tenantId;
            IsDeleted = isDeleted;
            ConcurrencyStamp = concurrencyStamp;
            Services = new List<Services>();
        }
    }
}
