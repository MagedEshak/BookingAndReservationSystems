using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystems.Enums
{
    [Flags]
    public enum Status
    {
        Pending = 1,
        Confirmed = 2,
        Cancelled = 3
    }
}
