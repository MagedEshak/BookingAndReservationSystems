using BookingAndReservationSystems.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace BookingAndReservationSystems.Permissions;

public class BookingAndReservationSystemsPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BookingAndReservationSystemsPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(BookingAndReservationSystemsPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BookingAndReservationSystemsResource>(name);
    }
}
