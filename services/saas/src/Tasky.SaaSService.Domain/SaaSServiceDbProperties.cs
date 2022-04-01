namespace Tasky.SaaSService;

public static class SaaSServiceDbProperties
{
    public static string DbTablePrefix { get; set; } = "SaaSService";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "SaaSService";
}
