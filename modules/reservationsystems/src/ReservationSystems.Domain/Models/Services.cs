using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace ReservationSystems.Models
{
    public class Services : Entity<Guid>, ISoftDelete, IMultiTenant,IHasConcurrencyStamp
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid LocationID { get; set; }
        public Locations Locations { get; set; }
        public bool IsDeleted {get; set;}
        public Guid? TenantId { get; set;}
        public string ConcurrencyStamp { get; set; }
        public ICollection<Bookings> Bookings { get; set; } = new List<Bookings>();
        public ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();
    }
}
