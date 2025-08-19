using ReservationSystems.Dtos.Booking;
using ReservationSystems.Dtos.Services;
using ReservationSystems.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystems.Dtos.Reviews
{
    public class ReviewsWithNavigationProperty
    {
        public ReviewsDto ReviewsDto { get; set; }
        public UserDto? UserDto { get; set; }
        public ServicesDto? ServicesDto  { get; set; }
     
    }
}
