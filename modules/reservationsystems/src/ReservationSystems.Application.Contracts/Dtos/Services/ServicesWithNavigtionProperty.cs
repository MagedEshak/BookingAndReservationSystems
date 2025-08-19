using ReservationSystems.Dtos.Booking;
using ReservationSystems.Dtos.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystems.Dtos.Services
{
    public class ServicesWithNavigtionProperty
    {
        public ServicesDto ServicesDto { get; set; }
        public ICollection<BookingDto>? Booking { get; set; } = new List<BookingDto>();
        public ICollection<ReviewsDto>? ReviewsDtos { get; set; } = new List<ReviewsDto>();
    }
}
