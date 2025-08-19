using ReservationSystems.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ReservationSystems.Permissions;

public class ReservationSystemsPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ReservationSystemsPermissions.GroupName, L("Permission:ReservationSystems"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ReservationSystemsResource>(name);
    }
}
