using ReservationSystems.Dtos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystems.Dtos.Location
{
    public class LocationsDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public bool? IsDeleted { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public ICollection<ServicesDto>? ServicesDtos { get; set; } = new List<ServicesDto>();
    }
}
