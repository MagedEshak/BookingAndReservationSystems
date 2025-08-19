using ReservationSystems.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ReservationSystems;

public abstract class ReservationSystemsController : AbpControllerBase
{
    protected ReservationSystemsController()
    {
        LocalizationResource = typeof(ReservationSystemsResource);
    }
}
