using ReservationSystems.Dtos.Services;
using ReservationSystems.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystems.Dtos.Booking
{
    public class BookingWithNavigationProperty
    {
        public BookingDto BookingDto { get; set; }
        public UserDto? UserDto { get; set; }
        public ServicesDto? ServicesDto { get; set; }
    }
}
