using ReservationSystems.Dtos.Booking;
using ReservationSystems.Dtos.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystems.Dtos.User
{
    public class UserWithNavigtionProperty
    {
        public UserDto UserDto { get; set; }
        public ICollection<BookingDto>? BookingDtos { get; set; }=new List<BookingDto>();
        public ICollection<ReviewsDto>? ReviewsDtos { get; set; }=new List<ReviewsDto>();
    }
}
