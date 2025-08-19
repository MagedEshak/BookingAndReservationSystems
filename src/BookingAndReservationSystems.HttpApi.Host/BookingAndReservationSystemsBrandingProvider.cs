using Microsoft.Extensions.Localization;
using BookingAndReservationSystems.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace BookingAndReservationSystems;

[Dependency(ReplaceServices = true)]
public class BookingAndReservationSystemsBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<BookingAndReservationSystemsResource> _localizer;

    public BookingAndReservationSystemsBrandingProvider(IStringLocalizer<BookingAndReservationSystemsResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
