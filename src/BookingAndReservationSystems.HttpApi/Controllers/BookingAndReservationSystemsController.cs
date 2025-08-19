using BookingAndReservationSystems.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BookingAndReservationSystems.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BookingAndReservationSystemsController : AbpControllerBase
{
    protected BookingAndReservationSystemsController()
    {
        LocalizationResource = typeof(BookingAndReservationSystemsResource);
    }
}
