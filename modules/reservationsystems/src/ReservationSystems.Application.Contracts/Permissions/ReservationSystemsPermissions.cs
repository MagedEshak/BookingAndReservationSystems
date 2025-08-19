using Volo.Abp.Reflection;

namespace ReservationSystems.Permissions;

public class ReservationSystemsPermissions
{
    public const string GroupName = "ReservationSystems";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ReservationSystemsPermissions));
    }
}
