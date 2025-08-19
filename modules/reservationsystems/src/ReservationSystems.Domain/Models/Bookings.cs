using ReservationSystems.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace ReservationSystems.Models
{
    public class Bookings : FullAuditedEntity<Guid>, IMultiTenant, IHasConcurrencyStamp
    {
        public DateTime Date { get; set; }
        public Status Status { get; set; }
        public Guid UserID { get; set; }
        public User Users { get; set; }
        public Guid ServiceID { get; set; }
        public Services Services { get; set; }
        public Guid? TenantId { get; set; }
        public string ConcurrencyStamp { get; set; }
        public Bookings() { }
        public Bookings(DateTime date,
                    Status status,
                    Guid userID,
                    Guid serviceID,
                    Guid? tenantId,
                    bool isDeleted,
                    string concurrencyStamp
            )
        {
            Date = date;
            Status = status;
            UserID = userID;
            ServiceID = serviceID;
            TenantId = tenantId;
            IsDeleted = isDeleted;
            ConcurrencyStamp = concurrencyStamp;
        }
    }
}
