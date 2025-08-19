using ReservationSystems.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystems.Dtos.Reviews
{
    public class ReviewsDto
    {
        public Rating? Rating { get; set; }
        public string? Comment { get; set; }
        public Guid? UserID { get; set; }
        public Guid? ServiceID { get; set; }
        public Guid? TenantId { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
