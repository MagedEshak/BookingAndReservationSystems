using BookingAndReservationSystems.Localization;
using Volo.Abp.Application.Services;

namespace BookingAndReservationSystems;

/* Inherit your application services from this class.
 */
public abstract class BookingAndReservationSystemsAppService : ApplicationService
{
    protected BookingAndReservationSystemsAppService()
    {
        LocalizationResource = typeof(BookingAndReservationSystemsResource);
    }
}
