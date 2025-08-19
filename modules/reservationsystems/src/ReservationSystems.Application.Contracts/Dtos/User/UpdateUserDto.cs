using ReservationSystems.Dtos.Booking;
using ReservationSystems.Dtos.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystems.Dtos.User
{
    public class UpdateUserDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool? IsDeleted { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public ICollection<BookingDto>? BookingDtos { get; set; } = new List<BookingDto>();
        public ICollection<ReviewsDto>? ReviewsDtos { get; set; } = new List<ReviewsDto>();
    }
}
