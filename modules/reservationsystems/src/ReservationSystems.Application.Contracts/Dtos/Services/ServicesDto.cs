using ReservationSystems.Dtos.Booking;
using ReservationSystems.Dtos.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystems.Dtos.Services
{
    public class ServicesDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? LocationsCountry { get; set; }
        public bool? IsDeleted { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public ICollection<BookingDto>? BookingDtos { get; set; } = new List<BookingDto>();
        public ICollection<ReviewsDto>? ReviewsDtos { get; set; } = new List<ReviewsDto>();
    }
}
