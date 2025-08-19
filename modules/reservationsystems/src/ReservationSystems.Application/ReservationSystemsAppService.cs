using ReservationSystems.Localization;
using Volo.Abp.Application.Services;

namespace ReservationSystems;

public abstract class ReservationSystemsAppService : ApplicationService
{
    protected ReservationSystemsAppService()
    {
        LocalizationResource = typeof(ReservationSystemsResource);
        ObjectMapperContext = typeof(ReservationSystemsApplicationModule);
    }
}
