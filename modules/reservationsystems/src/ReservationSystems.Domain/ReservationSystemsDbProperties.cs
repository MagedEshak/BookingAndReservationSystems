namespace ReservationSystems;

public static class ReservationSystemsDbProperties
{
    public static string DbTablePrefix { get; set; } = "ReservationSystems";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "ReservationSystems";
}
