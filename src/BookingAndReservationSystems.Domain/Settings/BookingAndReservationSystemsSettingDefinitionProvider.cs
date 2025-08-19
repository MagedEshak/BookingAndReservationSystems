using Volo.Abp.Settings;

namespace BookingAndReservationSystems.Settings;

public class BookingAndReservationSystemsSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BookingAndReservationSystemsSettings.MySetting1));
    }
}
