using Microsoft.AspNet.Identity.EntityFramework;
using ReservationSystems.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReservationSystems.Models
{
    public class Reviews : Entity<Guid>, ISoftDelete, IMultiTenant, IHasConcurrencyStamp
    {
        public Rating Rating { get; set; }
        public string Comment { get; set; }
        public Guid UserID { get; set; }
        public User Users { get; set; }
        public Guid ServiceID { get; set; }
        public Services Services { get; set; }
        public Guid? TenantId { get; set; }
        public string ConcurrencyStamp { get; set; }
        public bool IsDeleted { get; set; }

        public Reviews() { }
        public Reviews(Rating rating,
                   string comment,
                    Guid userID,
                    Guid serviceID,
                    Guid? tenantId,
                    bool isDeleted,
                    string concurrencyStamp
            )
        {
            Rating = rating;
            Comment = comment;
            UserID = userID;
            ServiceID = serviceID;
            TenantId = tenantId;
            IsDeleted = isDeleted;
            ConcurrencyStamp = concurrencyStamp;
        }
    }
}
