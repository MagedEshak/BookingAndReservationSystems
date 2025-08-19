using ReservationSystems.Dtos.Services;
using ReservationSystems.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystems.Dtos.Location
{
    public class LocationWithNavigationProperty
    {
        public LocationsDto LocationsDto { get; set; }
        public ICollection<ServicesDto>? ServicesDtos { get; set; } = new List<ServicesDto>();
    }
}
