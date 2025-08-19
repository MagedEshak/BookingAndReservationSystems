using ReservationSystems.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystems.Dtos.Booking
{
    public class UpdateBookingDto
    {
        public Guid? ID { get; set; }
        public DateTime? Date { get; set; }
        public Status? Status { get; set; }
        public Guid? UserID { get; set; }
        public Guid? ServiceID { get; set; }
        public Guid? TenantId { get; set; }
        public string? ConcurrencyStamp { get; set; }
    }
}
