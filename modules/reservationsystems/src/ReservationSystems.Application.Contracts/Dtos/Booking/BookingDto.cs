
using ReservationSystems.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystems.Dtos.Booking
{
    public class BookingDto
    {
        public DateTime Date { get; set; }
        public Status Status { get; set; }
        public Guid UserID { get; set; }
        public Guid ServiceID { get; set; }
        public bool IsDeleted { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}
